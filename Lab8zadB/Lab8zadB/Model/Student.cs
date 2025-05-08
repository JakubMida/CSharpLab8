using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8zadB.Model
{
    [Table("Studenci")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(20)]
        [Column("Imie")]
        public string Imię { get; set; }
        [MaxLength(20)]
        public string Nazwisko { get; set; }
        [Column(TypeName ="DECIMAL(2,1)")]
        public double? Ocena {get; set; }
        public byte Wiek { get; set; }


        public override string ToString()
        {
            return $"{Nazwisko}, Ocena = {Ocena:f1}";
        }
    }
}
