using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary1.Entities;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class LibraryService : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Result<bool> GetRandomGT60()
        {
            var result = new Result<bool>();
            var value = new Random().Next(100);
            result.Message = "value is " + value;
            result.Data = value > 60;
            return result;
        }

        public Result<Student> GetStudent()
        {
            Student student = new Student();
            student.Name = "Xia";
            student.Age = 25;
            Result<Student> result = new Result<Student>(student);
            return result;
        }



    }
}
