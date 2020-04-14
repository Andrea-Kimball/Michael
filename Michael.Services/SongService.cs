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
        public SongService()
        {
            _context = new ApplicationDbContext();
        }

        //CREATE
        public bool AddSong(SongCreate model)
        {
            var entity = new Song
            {
                AlbumId = model.AlbumId,
                Title = model.Title,

            };
            _context.Songs.Add(entity);
            return _context.SaveChanges() == 1;

        }
        //EDIT
        public bool EditSong(SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.
                    Songs
                    .Single(s => s.SongId == model.SongId);
                entity.Title = model.Title;
                return ctx.SaveChanges() == 1;
            }
        }
        //DELETE
        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                .Songs
                .Single(e => e.SongId == songId);
                ctx.Songs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //GET ALL SONGS
        public IEnumerable<SongListItem> GetAllSongs()
        {
            //GET all Songs from db
            var entityList = _context.Songs.ToList();

            //turn Songs into SonglistItems
            var songList = entityList.Select(Song => new SongListItem
            {
                SongId = Song.SongId,
                Title = Song.Title,
            }).ToList();
            return songList;
        }

        //GET BY ID
        public SongDetail GetSongById(int? songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == songId);
                return
                    new SongDetail
                    {
                        SongId = entity.SongId,
                        Title = entity.Title,
                    };
            }

        }
        public SongDetail GetSongByAlbum(Album album)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.Category == album);
                return
                    new SongDetail
                    {
                        SongId = entity.SongId,
                        Title = entity.Title,
                    };
            }


        }
    }
}
