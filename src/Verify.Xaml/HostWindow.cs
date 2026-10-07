using System.Windows;

namespace VerifyTests.Xaml;

public class HostWindow : Window
{
    // Built in code rather than XAML. Loading a XAML resource goes through Application.LoadComponent,
    // which is not thread-safe for a shared resource, and this window is constructed concurrently when
    // tests run in parallel on separate STA threads.
    public HostWindow()
    {
        Title = "HostWindow";
        Height = 450;
        Width = 800;
    }
}
