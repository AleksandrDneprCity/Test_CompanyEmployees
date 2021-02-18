using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_CompanyEmployees
{
    [Table("depart_content")]
    class ModelDepartContent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int id_depart { get; set; }
        public int id_employee { get; set; }
        [Column(TypeName ="date")]
        public DateTime date_transfer { get; set; }
        [Column(TypeName = "ntext")]
        public string position { get; set; }
    }
}
