using NUnit.Framework;
using PresentationForYou.WEB.Controllers;
using System.Web.Mvc;

namespace PresentationForYou.WEB.Tests.Controllers
{
    [TestFixture]
    public class UsersControllerTest
    {
        [Test]
        public void IndexViewResultNotNull()
        {
            UsersController controller = new UsersController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexViewEqualIndexCshtml()
        {
            UsersController controller = new UsersController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void IndexStringInViewbag()
        {
            UsersController controller = new UsersController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Hello world!", result.ViewBag.Message);
        }
    }
}
