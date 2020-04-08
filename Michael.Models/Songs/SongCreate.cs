using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Songs
{
    public class SongCreate
    {
        [ForeignKey("Category")]
        [Display(Name = "Album")]
        public int AlbumId { get; set; }
        public string Title { get; set; }

        
    }
}
