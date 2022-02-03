using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Toolivahendus2.Models
{
    public class ToolidValmistusel
    {
       public int Id { get; set; }
       public string Firmanimi { get; set; }
       [Required]
       public int ValminudKogus { get; set; } = -0;
    }
}
