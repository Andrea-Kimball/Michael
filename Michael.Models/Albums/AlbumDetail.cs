using Michael.Data;
using Michael.Models.Era;
using Michael.Models.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Albums
{
    public class AlbumDetail
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string AlbumDescription { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
