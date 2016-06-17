using NUnit.Framework;
using PresentationForYou.WEB.Controllers;
using System.Web.Mvc;

namespace PresentationForYou.WEB.Tests.Controllers
{
    [TestFixture]
    public class AuditoriesControllerTest
    {
        [Test]
        public void IndexViewResultNotNull()
        {
            AuditoriesController controller = new AuditoriesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexViewEqualIndexCshtml()
        {
            AuditoriesController controller = new AuditoriesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void IndexStringInViewbag()
        {
            AuditoriesController controller = new AuditoriesController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Hello world!", result.ViewBag.Message);
        }
    }
}
