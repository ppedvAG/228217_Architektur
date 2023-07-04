using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BooksAPIClient.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]


namespace BooksAPIClient
{
    internal class BooksManager
    {
        private readonly IDataSource source;
        private readonly string such;

        public BooksManager(IDataSource source, string such)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (string.IsNullOrWhiteSpace(such))
                throw new ArgumentNullException("such");

            this.source = source;
            this.such = such;
        }

        public IEnumerable<Volumeinfo> GetBooks()
        {
            return source.GetResult(such).items.Select(x => x.volumeInfo).ToList();
        }

        public int CountPages()
        {
            return source.GetResult(such).items.Sum(x => x.volumeInfo.pageCount);
        }
    }
}
