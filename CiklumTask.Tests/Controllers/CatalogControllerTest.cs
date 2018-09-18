using System;
using CiklumTask.Controllers;
using CiklumTask.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;
using System.Collections.Generic;
using CiklumTask.Models;
using AutoMapper;
using CiklumTask.ViewModels;
using System.Linq;

namespace CiklumTask.Tests.Controllers
{
    [TestClass]
    public class CatalogControllerTest
    {
        private CatalogController controller;
        private ViewResult result;

        [TestInitialize]
        public void SetupContext()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductVM>()
                    .ForMember(vm => vm.Images, m => m.MapFrom(l => l.Pics.Select(p => p.url_pic).ToList()))
                    .ForMember(vm => vm.FrontImage, m => m.MapFrom(l => l.Pics.First().url_pic))
                    .ForMember(vm => vm.Price, m => m.MapFrom(l => l.price));
            });
        }

        [TestMethod]
        public void IndexViewResultNotNull()
        {
            controller = new CatalogController();
            result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            Mapper.Reset();
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            controller = new CatalogController();
            result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

            Mapper.Reset();
        }



        //[TestMethod]
        //public void IndexViewModelNotNull()
        //{
        //    var mock = new Mock<IUnitOfWork>();
        //    mock.Setup(a => a.ProductRepository.Get(1550)).Returns(new Product { Id = 1550 } );
        //    controller = new CatalogController(mock.Object);

        //    ViewResult result = controller.ViewDetails(1550) as ViewResult;

        //    Assert.AreEqual("Details", result.ViewName);

        //    Mapper.Reset();
        //}



        //[TestMethod]
        //public void IndexViewDetailsResultNotNull()
        //{
        //    result = controller.ViewDetails(1503) as ViewResult;
        //    Assert.IsNotNull(result);
        //}
        //[TestMethod]
        //public void IndexViewDetailsEqualIndexCshtml()
        //{
            
        //    var mock = new Mock<UnitOfWork>();
        //    mock.Setup(a => a.Product.GetAll()).Returns(new List<Product>());
        //    controller = new CatalogController(mock.Object);
        //    result = controller.ViewDetails(mock.Object) as ViewResult;
        //    Assert.AreEqual("Details", result.ViewName);
        //}
    }
}
