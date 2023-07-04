using System.Net.Http;

namespace BooksAPIClient
{
    class GoogleApiSource : IDataSource
    {
        public BooksResult GetResult(string search)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={search}";

            var http = new HttpClient();
            var json = http.GetStringAsync(url).Result;

            return System.Text.Json.JsonSerializer.Deserialize<BooksResult>(json);
        }
    }
}
