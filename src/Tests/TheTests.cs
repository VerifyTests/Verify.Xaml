using System.Windows.Controls;
using Tests;

[STAThreadExecutor]
public class TheTests
{
    #region Window

    [Test]
    public async Task WindowUsage()
    {
        var window = new MyWindow();
        await Verify(window);
    }

    #endregion

    #region Page

    [Test]
    public async Task Page()
    {
        var page = new MyPage();
        await Verify(page);
    }

    #endregion

    #region UserControl

    [Test]
    public async Task UserControl()
    {
        var userControl = new MyUserControl();
        await Verify(userControl);
    }

    #endregion

    [Test]
    public async Task ContextMenuUsage()
    {
        var menu = new ContextMenu();
        menu.Items.Add(new MenuItem { Header = "Open" });
        menu.Items.Add(new MenuItem { Header = "Exit" });
        await Verify(menu);
    }

    [Test]
    public async Task ToolTipUsage()
    {
        var toolTip = new ToolTip { Content = "The tip" };
        await Verify(toolTip);
    }

    [Test]
    public async Task DataTemplateWindow()
    {
        var window = new DataTemplateWindow();
        await Verify(window);
    }
}