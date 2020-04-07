using Michael.Data;
using Michael.Models;
using Michael.Models.Albums;
using Michael.Models.Era;
using Michael.Models.Songs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Services
{
    public class AlbumService
    {

        private readonly ApplicationDbContext _ctx;
        private readonly string _userId;
        public AlbumService(string userId)
        {
            _ctx = new ApplicationDbContext();
            _userId = userId;

        }


        //CREATE
        public bool CreateAlbum(AlbumCreate model)
        {
            var entity = new Album()
            {
                Title = model.Title,
                Description = model.Description,
                
            };
            using (var _ctx = new ApplicationDbContext())
            {
                _ctx.Albums.Add(entity);
                return _ctx.SaveChanges() == 1;
            }
            
        }

        //Edit
        public bool EditAlbum(AlbumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Albums;
                return ctx.SaveChanges() == 1;
            }
        }
        //DELETE
        public bool DeleteAlbum(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                .Albums
                .Single(e => e.AlbumId == albumId);
                ctx.Albums.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //GET ALL ALBUMS
        public IEnumerable<AlbumListItem> GetAllAlbums()
        {
            //GET all Albums from db
            var entityList =  _ctx.Albums.ToList();

            //turn Albums into AlbumlistItems
            var AlbumList = entityList.Select(Album => new AlbumListItem
            {
                AlbumId = Album.AlbumId,
                Title = Album.Title,
                Description= Album.Description
            }).ToList();

            //return changed list
            return AlbumList;

            //GET BY ID
        }
        public async Task<AlbumDetail> GetAlbumByIdAsync(int AlbumId)
        {
            //Search Database by Id for Album
            var entity = await _ctx.Albums.FindAsync(AlbumId);
            if (entity == null)
                throw new Exception("No Album found.");
            //Turn the entity into the Detail

            var model = new AlbumDetail
            {
                AlbumId = entity.AlbumId,
                Title = entity.Title,
                Description = entity.Description,
               // Song = entity.Song,
                Song = entity.Songs.Select(song => new SongListItem
                {
                    SongId = song.SongId,
                    Title = song.Title,
                }).ToList(),

            };
//            foreach (var album in entity.Album)
//            {
//                model.Albums.Add(new EraListItem{


//                    AlbumId = album.AlbumId, 
//                EraId = album.EraId,
//});

                //return the detail model
                return model;
            }
    }
}
