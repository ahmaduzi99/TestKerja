using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestKerja.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Username Min 3 Huruf")]
        public string? username { get; set; }

        public string? email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "Telepon Min 11 Angka")]
        public string? phone { get; set; }

        [Required(ErrorMessage = "Password harus diisi.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password harus memenuhi persyaratan.")]
        public string? password { get; set; }

    }
}
