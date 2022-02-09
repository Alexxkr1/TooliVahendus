using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Toolivahendus2.Models
{
    public class TooliVahendus
    {
        public int Id { get; set; }
        public string Eesnimi { get; set; }
        public string Perekonnanimi { get; set; }
        public string Toon { get; set; }
        public int Tellimuskogus { get; set; }
        public string Firmanimi { get; set; }
        public string Firmaemail { get; set; }
        [Range(0, 20)]
        public int Valminudkogus { get; set; }=-0;

    }
}
