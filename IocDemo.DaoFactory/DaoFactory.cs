using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocDemo.IDao;

namespace IocDemo.DaoFactory
{
    /// <summary>
    /// Dao实例工厂
    /// </summary>
    public class DaoFactory
    {
        /// <summary>
        /// 依据dao名称创建实例
        /// </summary>
        /// <param name="daoName"></param>
        /// <returns></returns>
        private static object GetInstance(string daoName, string directoryName = "")
        {
            string configName = System.Configuration.ConfigurationManager.AppSettings["IocDemo.DaoAccess"];
            if (string.IsNullOrEmpty(configName))
            {
                throw new Exception("还没有配置IocDemo.DaoAccess!");
            }

            StringBuilder sbClassName = new StringBuilder(configName);
            if (!string.IsNullOrEmpty(directoryName))
            {
                sbClassName.Append("." + directoryName);
            }
            sbClassName.Append("." + daoName);

            //加载程序集
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(configName);

            //创建指定类型的对象实例
            return assembly.CreateInstance(sbClassName.ToString());
        }

        public static ITestDao GetTestDao()
        {
            return GetInstance("TestDao") as ITestDao;
        }

    }
}
