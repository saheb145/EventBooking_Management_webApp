using CoreLogic.Services;
namespace CoreTests
{
    public class UserTests
    {
        UserService userservice;
        [SetUp]
        public void Setup()
        {
            userservice = new UserService();
        }

        [Test]
        public void Test1()
        {
            var res = userservice.GetAll();
            var count = res.Count();
            Assert.IsTrue(count > 0);
        }
    }
}