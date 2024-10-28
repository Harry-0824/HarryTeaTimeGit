using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeaTimeDemo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("類別名稱")]
        public string Name { get; set; }
        [DisplayName("顯示順序")]
        [Range(0, 100, ErrorMessage ="输入范围应在1~100之间")]
        public int DisplayOrder { get; set; }
    }
}
