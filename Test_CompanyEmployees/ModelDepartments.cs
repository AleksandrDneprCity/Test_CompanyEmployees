using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel

namespace Test_CompanyEmployees
{
    [Table("departments")]
    class ModelDepartments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Index("IX_departments_name")]
        [Required]
        public string name { get; set; }
        public int? parent_id { get; set; }
        [Index("IX_departments_date_creation")]
        public DateTime? date_creation { get; set; }
        [Index("IX_departments_date_closing")]
        public DateTime? date_closing { get; set; }
    }
}
