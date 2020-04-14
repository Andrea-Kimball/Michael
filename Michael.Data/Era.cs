using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Michael.Data
{

    public class Era
    {
        [Key]
        public int EraId { get; set; }
        public string EraName { get; set; }       

        public virtual IEnumerable<Album> Albums { get; set; } //= new List<Album>();

    }
}
