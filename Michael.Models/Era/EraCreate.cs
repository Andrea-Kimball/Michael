using Michael.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Era
{
    public class EraCreate
    {
        public int EraId { get; set; }
        [Display(Name ="Era Name")]
        public string EraName { get; set; }        
        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}
