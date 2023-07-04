using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace BooksAPIClient.Tests
{
    public class MainWindowTests
    {

        [Fact]
        public void Click_on_search_should_display_10_books_in_grid()
        {
            var path = typeof(MainWindow).Assembly.Location.Replace(".dll", ".exe");

            var app = FlaUI.Core.Application.Launch(path);

            using (var auto = new UIA3Automation())
            {
                var win = app.GetMainWindow(auto);
                win.WaitUntilClickable();

                var btn = win.FindFirstDescendant(x => x.ByClassName("Button")).AsButton();
                btn.Click();

                var grid = win.FindFirstDescendant(x => x.ByClassName("DataGrid")).AsGrid();

                Assert.Equal(10, grid.Rows.Count());
            }

            app.Close();
        }
    }
}
