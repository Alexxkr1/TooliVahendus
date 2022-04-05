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
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Ainult tähed.")]
        public string Eesnimi { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Ainult tähed.")]
        public string Perekonnanimi { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Ainult tähed.")]
        public string Toon { get; set; }
        [Required]
        public int Tellimuskogus { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Ainult tähed.")]
        public string Firmanimi { get; set; }
        [Required]
        [StringLength(30)]
        [EmailAddress]
        public string Firmaemail { get; set; }
        [Range(0, 20)]
        public int Valminudkogus { get; set; }=-0;

    }
}
