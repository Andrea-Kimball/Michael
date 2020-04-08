using Michael.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Albums
{
    public class AlbumEdit
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }

        [Display(Name ="Album Discription")]        
        public string AlbumDescription { get; set; }
        
        [ForeignKey("Era")]
        public int EraId { get; set; }
    }
}
