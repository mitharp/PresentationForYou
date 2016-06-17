using NUnit.Framework;
using PresentationForYou.WEB.Controllers;
using System.Web.Mvc;

namespace PresentationForYou.WEB.Tests.Controllers
{
    [TestFixture]
    public class BoardsControllerTest
    {
        [Test]
        public void IndexViewResultNotNull()
        {
            BoardsController controller = new BoardsController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexViewEqualIndexCshtml()
        {
            BoardsController controller = new BoardsController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void IndexStringInViewbag()
        {
            BoardsController controller = new BoardsController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Hello world!", result.ViewBag.Message);
        }
    }
}
