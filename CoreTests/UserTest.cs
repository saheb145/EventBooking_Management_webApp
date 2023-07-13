using CoreLogic.Services;
namespace CoreTests
{
    public class UserTest
    {
        UserService userService;
        [SetUp]
        public void Setup()
        {
            userService=new UserService();

        }

        [Test]
        public void Test1()
        {
            var res = userService.GetAll();
            var count =res.Count();
            Assert.IsTrue(count > 0);
        }
    }
}