using CodeGenerator.Helper.DDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DDL.FileGenerator
{
    public class DDLBLLFileGenerator : BaseDDLFileGenerator
    {
        public override string DefaultFileName
        {
            get
            {
                return Parent.ClassName + "BLL" + ".cs";
            }
        }

        internal DDLBLLFileGenerator(DDLEntity parent) : base(parent) { }

        protected override string Generate(string targetNamespace, List<string> additionalNamespace = null)
        {
            throw new NotImplementedException();
        }
    }
}
