﻿using NUnit.Framework;
using PresentationForYou.WEB.Controllers;
using System.Web.Mvc;

namespace PresentationForYou.WEB.Tests.Controllers
{
    [TestFixture]
    public class ProjectorsControllerTest
    {
        [Test]
        public void IndexViewResultNotNull()
        {
            ProjectorsController controller = new ProjectorsController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexViewEqualIndexCshtml()
        {
            ProjectorsController controller = new ProjectorsController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void IndexStringInViewbag()
        {
            ProjectorsController controller = new ProjectorsController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.AreEqual("Hello world!", result.ViewBag.Message);
        }
    }
}
