using System;
using System.Web.Mvc;
using CiklumTask.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiklumTask.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;
        private ViewResult result;


        [TestMethod]
        public void IndexViewResultNotNull()
        {
            controller = new HomeController();
            result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AboutViewResultNotNull()
        {
            controller = new HomeController();
            result = controller.About() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ContactViewResultNotNull()
        {
            controller = new HomeController();
            result = controller.Contact() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            controller = new HomeController();
            result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void AboutViewEqualAboutCshtml()
        {
            controller = new HomeController();
            result = controller.About() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void ContactViewEqualAboutCshtml()
        {
            controller = new HomeController();
            result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewBag.Title);
        }

        [TestMethod]
        public void IndexViewEqualTitle()
        {
            controller = new HomeController();
            result = controller.Index() as ViewResult;
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }

        [TestMethod]
        public void AboutViewEqualTitle()
        {
            controller = new HomeController();
            result = controller.About() as ViewResult;
            Assert.AreEqual("About", result.ViewBag.Title);
        }

        [TestMethod]
        public void ContactViewEqualTitle()
        {
            controller = new HomeController();
            result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewName);
        }

        [TestMethod]
        public void ContactViewBagMessage()
        {
            controller = new HomeController();
            result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact page", result.ViewBag.Message);
        }

        [TestMethod]
        public void AboutViewBagMessage()
        {
            controller = new HomeController();
            result = controller.About() as ViewResult;
            Assert.AreEqual("Application description", result.ViewBag.Message);
        }

    }
}
