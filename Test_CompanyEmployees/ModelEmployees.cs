using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Test_CompanyEmployees
{
    [Table("employees")]
    public class ModelEmployees
    {
        public enum GenderText : byte { Женский = 0, Мужской };
        public enum GenderName : byte { FEMALE = 0, MALE };

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public int id { get; set; }
        [DisplayName("Имя")]
        [Index("IX_employees_name", Order = 0)]
        [Column(TypeName ="nvarchar")]
        [StringLength(16)]
        [Required]
        public string first_name { get; set; }
        [DisplayName("Отчество")]
        [Index("IX_employees_name", Order = 1)]
        [Column(TypeName = "nvarchar")]
        [StringLength(16)]
        [Required]
        public string middle_name { get; set; }
        [DisplayName("Фамилия")]
        [Index("IX_employees_name", Order = 2)]
        [Column(TypeName = "nvarchar")]
        [StringLength(16)]
        [Required]
        public string last_name { get; set; }
        [DisplayName("Табельный номер")]
        [Index("IX_employees_personel_uni", IsUnique = true)]
        [Column(TypeName = "nchar")]
        [StringLength(10)]
        [Required]
        public string personel_number { get; set; }
        [DisplayName("Пол")]
        [Column(TypeName ="TinyInt")]
        public GenderText gender { get; set; }
        [DisplayName("День рождения")]
        [Column(TypeName = "date")]
        public DateTime birth_day { get; set; }
        [DisplayName("Место рождения")]
        [Column(TypeName = "ntext")]
        public string birth_place { get; set; }
        [DisplayName("Налоговый номер")]
        [Index("IX_employees_tax_uni", IsUnique = true)]
        [Column(TypeName = "nchar")]
        [StringLength(10)]
        [Required]
        public string tax_number { get; set; }
        [DisplayName("Дата приёма")]
        [Index("IX_employees_date_employ")]
        [Column(TypeName = "date")]
        public DateTime? date_employment { get; set; }
        [DisplayName("Дата увольнения")]
        [Index("IX_employees_date_dismiss")]
        [Column(TypeName = "date")]
        public DateTime? date_dismissal { get; set; }
        [DisplayName("Причина увольнения")]
        [Column(TypeName = "ntext")]
        public string reason_dismissal { get; set; }
    }
}
