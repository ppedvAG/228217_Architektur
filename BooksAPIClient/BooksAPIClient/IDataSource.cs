namespace BooksAPIClient
{
    internal interface IDataSource
    {
        BooksResult GetResult(string search);
    }
}
