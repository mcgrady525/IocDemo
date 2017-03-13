using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocDemo.IService;
using IocDemo.IDao;

namespace IocDemo.Service
{
    public class TestService : ITestService
    {
        //注入dao
        private readonly ITestDao _testDao;

        public TestService(ITestDao testDao)
        {
            _testDao = testDao;
        }

        public string Test()
        {
            return _testDao.Test();
        }
    }
}
