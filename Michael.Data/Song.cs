using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Michael.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        [Required]
        public string Title { get; set; }

        [ForeignKey("Albums")]
        public int? AlbumId { get; set; }
        //navigation property
        public virtual Album Albums { get; set; }

        public int ReleaseYear { get; set; }

        
    }
    
}