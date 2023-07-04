using Moq;
using System.Runtime.CompilerServices;

namespace BooksAPIClient.Tests
{
    public partial class BookManagerTests
    {
        [Fact]
        public void Ctor_should_throw_ArgumentNullEx_if_source_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new BooksManager(null, "test123"));
        }

        [Fact]
        public void Ctor_should_throw_ArgumentNullEx_if_search_is_null_or_empty()
        {

            Assert.Throws<ArgumentNullException>(() => new BooksManager(new TestSource(), null));
            Assert.Throws<ArgumentNullException>(() => new BooksManager(new TestSource(), ""));
            Assert.Throws<ArgumentNullException>(() => new BooksManager(new TestSource(), " "));
        }

        [Fact]
        public void GetBooks_should_return_3_test_volumeinfos()
        {
            var bm = new BooksManager(new TestSource(), "test123");

            var result = bm.GetBooks();

            Assert.Equal(3, result.Count());
        }


        [Fact]
        public void GetBooks_should_return_3_test_volumeinfos_moq()
        {
            var mock = new Mock<IDataSource>();
            mock.Setup(x => x.GetResult(It.IsAny<string>())).Returns(() =>
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
            });
            var bm = new BooksManager(mock.Object, "test123");

            var result = bm.GetBooks();

            Assert.Equal(3, result.Count());
            mock.Verify(x => x.GetResult(It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void CountPages_should_return_12()
        {
            var mock = new Mock<IDataSource>();
            mock.Setup(x => x.GetResult(It.IsAny<string>())).Returns(() =>
            {
                var br = new BooksResult();
                var items = new List<Item>();
                items.Add(new Item());
                items.Add(new Item());
                items.Add(new Item());
                items[0].volumeInfo = new Volumeinfo() { pageCount = 3 };
                items[1].volumeInfo = new Volumeinfo() { pageCount = 5 };
                items[2].volumeInfo = new Volumeinfo() { pageCount = 4 };
                br.items = items.ToArray();
                return br;
            });
            var bm = new BooksManager(mock.Object, "test123");

            var result = bm.CountPages();

            Assert.Equal(12, result);
            mock.Verify(x => x.GetResult(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}