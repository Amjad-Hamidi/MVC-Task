using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
      public int Id { get; set; }
        [DataType("varchar")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;/*ملاحظة : هي بكل الحالات ريكوايرد من سي شارب ستة واطلع , لكن هاي معناها انو بس بالسي شارب منقله تخفش رح يكون الها قيمة , اما في الداتا بيس عالاكيد في حتى بدونها*/
        [DataType("varchar")]   //or : [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        public string Password { get; set; } = null!;
    }
}
