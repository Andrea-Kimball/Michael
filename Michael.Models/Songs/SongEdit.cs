using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Songs
{
    public class SongEdit
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
    }
}
