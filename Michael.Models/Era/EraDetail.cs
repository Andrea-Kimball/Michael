using Michael.Data;
using Michael.Models.Albums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Era
{
    public class EraDetail
    {
        public int EraId { get; set; }
        [Display(Name ="Era Name")]
        public string EraName { get; set; }
        
        public virtual IEnumerable<Album> Albums { get; set; }
    }
}
