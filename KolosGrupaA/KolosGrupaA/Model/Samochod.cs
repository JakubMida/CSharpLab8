using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolosGrupaA.Model
{
    [Table("Samochody")]
    public class Samochod
    {
        [Key]
        public int SamochodId {  get; set; }
        public string Marka {  get; set; }
        public string Model {  get; set; }
        public int RokProdukcji {  get; set; }
        public int Przebieg { get; set; }

        public override string ToString()
        {
            return $"{Marka}, {Model}, {RokProdukcji}, przebieg = {Przebieg}";
        }
    }
}
