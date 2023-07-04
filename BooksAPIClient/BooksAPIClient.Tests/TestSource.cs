namespace BooksAPIClient.Tests
{
    public partial class BookManagerTests
    {
        class TestSource : IDataSource
        {
            public BooksResult GetResult(string search)
            {
                var br = new BooksResult();
                var items = new List<Item>();
                items.Add(new Item());
                items.Add(new Item());
                items.Add(new Item());
                items[0].volumeInfo = new Volumeinfo();
                items[1].volumeInfo = new Volumeinfo();
                items[2].volumeInfo = new Volumeinfo();
                br.items = items.ToArray();
                return br;
            }
        }
    }
}