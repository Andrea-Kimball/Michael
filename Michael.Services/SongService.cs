using Michael.Data;
using Michael.Models;
using Michael.Models.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Services
{
    public class SongService
    {
        private readonly ApplicationDbContext _context;
        public SongService(string userid)
        {
            _context = new ApplicationDbContext();
        }

        //Add a Song
        public async Task<bool> AddSongAsync(SongCreate model)
        {
            var entity = new Song
            {
                AlbumId = model.AlbumId,
                Title = model.Title,

            };
            _context.Songs.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;
        }
    }
}
