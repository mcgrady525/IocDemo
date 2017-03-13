using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocDemo.IDao;

namespace IocDemo.Dao
{
    public class TestDao: ITestDao
    {
        public string Test()
        {
            return "hello Ioc, from IcoDemo.Dao!";
        }
    }
}
