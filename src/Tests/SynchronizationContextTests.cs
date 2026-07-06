using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

[Apartment(ApartmentState.STA)]
[TestFixture]
public class SynchronizationContextTests
{
    [Test]
    public async Task DoesNotDeadlockUnderPumplessSynchronizationContext()
    {
        var original = SynchronizationContext.Current;

        // Render a large, high-entropy image so the received-image write performs genuinely async IO.
        // Small control images fit the write buffer and flush synchronously, which would not exercise
        // the bug (the WPF sample controls' snapshots are only a few KB).
        var bitmap = new WriteableBitmap(800, 450, 96, 96, PixelFormats.Bgra32, null);
        var stride = bitmap.PixelWidth * 4;
        var pixels = new byte[stride * bitmap.PixelHeight];
        new Random(1).NextBytes(pixels);
        bitmap.WritePixels(new(0, 0, bitmap.PixelWidth, bitmap.PixelHeight), pixels, stride, 0);
        var image = new Image
        {
            Source = bitmap,
            Stretch = Stretch.Fill
        };

        // A UI SynchronizationContext with no running message pump, as exists during a test. Verify's
        // pipeline must run free of it (see SettingsTask.ToTask); otherwise the received-image write's
        // continuation is posted to a pump that never runs and the pipeline - and this test - hangs.
        SynchronizationContext.SetSynchronizationContext(new PumplessSynchronizationContext());
        Task task;
        try
        {
            task = Verify(image)
                .DisableDiff()
                .ToTask();
        }
        finally
        {
            // Restore so this test's own awaits below are not captured by the pumpless context.
            SynchronizationContext.SetSynchronizationContext(original);
        }

        var completed = await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(10)));

        Assert.That(completed, Is.SameAs(task), "WPF Verify deadlocked under a SynchronizationContext with no message pump.");

        // The new snapshot should fault (VerifyException); its type is internal to Verify, so just observe the fault.
        Exception? exception = null;
        try
        {
            await task;
        }
        catch (Exception e)
        {
            exception = e;
        }

        Assert.That(exception, Is.Not.Null, "Expected the new snapshot to throw.");
    }

    class PumplessSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback callback, object? state)
        {
            // No message pump: the continuation is queued but never dispatched.
        }
    }
}
