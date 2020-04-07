using Michael.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Data
{
    
    public class Era
    {
        [Key]
        public int EraId { get;set; }
        public string Name{ get; set; }

        [Required]
        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    }
}
