using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Michael.Data
{

    public class Era
    {
        [Key]
        [Display(Name = "Era Id")]
        public int EraId { get; set; }

        [Display(Name = "Era Name")]
        public string EraName { get; set; }

        public virtual ICollection<Album> Albums { get; set; } //= new List<Album>();

    }
}
