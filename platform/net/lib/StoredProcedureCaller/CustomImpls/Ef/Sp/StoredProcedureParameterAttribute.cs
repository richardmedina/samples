using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomImpls.Ef.Sp
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StoredProcedureParameterAttribute : Attribute
    {
        public string Name { get; set; } = default!;
    }
}
