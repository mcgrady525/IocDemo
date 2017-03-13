using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocDemo.IService;
using IocDemo.IDao;

namespace IocDemo.Service
{
    public class Test1Service: ITest1Service
    {
        //注入dao
        private readonly ITest1Dao _test1Dao;
        private readonly ITestDao _testDao;

        public Test1Service(ITest1Dao test1Dao, ITestDao testDao)
        {
            _test1Dao = test1Dao;
            _testDao = testDao;
        }

        public string Test()
        {
            return _test1Dao.Test();
        }
    }
}
