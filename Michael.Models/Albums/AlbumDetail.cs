using Michael.Data;
using Michael.Models.Era;
using Michael.Models.Songs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Albums
{
    public class AlbumDetail
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }

        [Display(Name ="Album Description")]
        public string AlbumDescription { get; set; }

        [ForeignKey("Category")]
        public int EraId { get; set; }
        

        
        public virtual IEnumerable<Song> Songs { get; set; } 
       // public virtual ICollection<Song> Songs { get; set; }
    }
}
