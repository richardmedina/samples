using CustomImpls.Ef.Sp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomImpls.Tests.StoredProcedures
{
    [StoredProcedure(Name = "AddUser")]
    internal class AddUserStoredProcedure
    {
        [StoredProcedureParameter(Name = "@id")]
        public string Id { get; set; } = default!;
        [StoredProcedureParameter(Name = "@firstName")]
        public string FirstName { get; set; } = default!;
        [StoredProcedureParameter(Name = "@lastName")]
        public string LastName { get; set; } = default!;
    }
}
