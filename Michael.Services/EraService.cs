using Michael.Data;
using Michael.Models.Albums;
using Michael.Models.Era;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Services
{
    public class EraService
    {
        private readonly ApplicationDbContext _context;
        private readonly Guid _userId;
        public EraService()
        {
            _context = new ApplicationDbContext();
            //_userId = userId;

        }

        //CREATE
        public bool CreateEra(EraCreate model)
        {
            Era entity = new Era
            {
                EraId = model.EraId,
                EraName = model.EraName,
                Albums = model.Albums


            };
            _context.Eras.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //EDIT
        public bool UpdateEra(EraEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Eras
                        .Single(e => e.EraId == model.EraId);

                entity.EraName = model.EraName;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteEra(int eraId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Eras
                        .Single(e => e.EraId == eraId);

                ctx.Eras.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL
        public List<EraListItem> GetAllEras()
        {
            //GET all Eras from db
            var entityList = _context.Eras.ToList();

            //turn Eras into EralistItems
            var EraList = entityList.Select(Era => new EraListItem
            {
                EraId = Era.EraId,
                EraName = Era.EraName,
            }).ToList();
            //return changed list
            return EraList;
        }

        //GET BY ID
        public EraDetail GetEraById(int? eraId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Eras
                        .Single(e => e.EraId == eraId);
                return
                    new EraDetail
                    {
                        EraId = entity.EraId,
                        EraName = entity.EraName,
                        Albums = entity.Albums

                    };
            }

        }



    }
}
