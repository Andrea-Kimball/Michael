using Michael.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Michael.Data
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AlbumDescription { get; set; }

        [ForeignKey("Category")]        
        public int EraId { get; set; }
        public virtual Era Category { get; set; }    

        public virtual ICollection<Song> Songs { get; set; }
        


    }
}