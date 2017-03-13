using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocDemo.IDao;

namespace IocDemo.Dao
{
    public class Test1Dao: ITest1Dao
    {
        public string Test()
        {
            return "bbb";
        }
    }
}
