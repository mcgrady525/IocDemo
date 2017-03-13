using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocDemo.IService;

namespace IocDemo.Site.Controllers
{
    public class TestController : Controller
    {
        //注入service
        private readonly ITestService _testService;
        private readonly ITest1Service _test1Service;

        //构造函数
        public TestController(ITestService testService, ITest1Service test1Service)
        {
            _testService = testService;
            _test1Service = test1Service;
        }

        public ActionResult Index()
        {
            var rs = _testService.Test();
            var rs1 = _test1Service.Test();
            ViewBag.Message = rs;
            ViewBag.Message1 = rs1;

            return View();
        }
	}
}