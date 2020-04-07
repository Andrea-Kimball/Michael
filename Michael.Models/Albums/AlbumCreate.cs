using Michael.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Albums
{
    public class AlbumCreate
    {
        [ForeignKey("MJE")]
        public int EraId { get; set; }
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        
        
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
