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
        public AlbumService()
        {
            _ctx = new ApplicationDbContext();
           // _userId = userId;

        }


        //CREATE
        public bool CreateAlbum(AlbumCreate model)
        {
            var entity = new Album()
            {
                Title = model.Title,
                AlbumDescription = model.AlbumDescription,
                
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
                var entity = ctx
                    .Albums
                    .Single(a=>a.AlbumId==model.AlbumId);
                entity.Title = model.Title;
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
            var albumList = entityList.Select(Album => new AlbumListItem
            {
                AlbumId = Album.AlbumId,
                Title = Album.Title,
                AlbumDescription= Album.AlbumDescription
            }).ToList();

            //return changed list
            return albumList;

            
        }

        //GET ALBUMS BY ID
        public AlbumDetail GetAlbumById(int? albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == albumId);
                return
                    new AlbumDetail
                    {
                        AlbumId = entity.AlbumId,
                        Title = entity.Title,
                        AlbumDescription = entity.AlbumDescription,
                        Songs = entity.Songs,

                    };
            }

        }

    }
}
