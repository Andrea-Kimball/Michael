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
        [ForeignKey("Era")]
        [Display(Name = "Era")]
        public int EraId { get; set; }
        public string Title { get; set; }

        [Required]
        [Display(Name ="Album Description")]
        public string AlbumDescription { get; set; }

        
        
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
