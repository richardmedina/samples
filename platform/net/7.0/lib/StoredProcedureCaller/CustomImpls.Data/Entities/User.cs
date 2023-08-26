using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomImpls.Data.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        public string Id { get; set; } = default!;
        public string FirtName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
