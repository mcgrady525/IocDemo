using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IocDemo.IService;

namespace IocDemo.ServiceFactory
{
    public class ServiceFactory
    {
        /// <summary>
        /// 依据service名称创建实例
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        private static object GetInstance(string serviceName, string directoryName = "")
        {
            string configName = System.Configuration.ConfigurationManager.AppSettings["IocDemo.ServiceAccess"];
            if (string.IsNullOrEmpty(configName))
            {
                throw new Exception("还没有配置IocDemo.ServiceAccess!");
            }

            StringBuilder sbClassName = new StringBuilder(configName);
            if (!string.IsNullOrEmpty(directoryName))
            {
                sbClassName.Append("." + directoryName);
            }
            sbClassName.Append("." + serviceName);

            //加载程序集
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(configName);

            //创建指定类型的对象实例
            return assembly.CreateInstance(sbClassName.ToString());
        }

        public static ITestService GetTestService()
        {
            return GetInstance("TestService") as ITestService;
        }

    }
}
