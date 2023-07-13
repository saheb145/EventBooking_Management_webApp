using CoreLogic.Services;
namespace CoreTests
{
    public class BookEventTest
    {
        BookEventService bookEventService;
        [SetUp]
        public void Setup()
        {
            bookEventService = new BookEventService();

        }

        [Test]
        public void Test2()
        {
            var res = bookEventService.GetAllEventDetails();
            var count = res.Count();
            Assert.IsTrue(count > 0);
        }
    }
}