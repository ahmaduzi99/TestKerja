using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System;

namespace TestKerja.Models
{
    public class Registrasi
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public DateTime? RegDate { get; set; }
        public string? RegStatus { get; set; }
        public string? Name { get; set; }

        public string? gender { get; set; }

        public string? BirthPlace { get; set; }

        public DateTime? BrithDate { get; set; }

        public string? Adress { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? IdCard { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? CreateBy { get; set; }
    }
}
