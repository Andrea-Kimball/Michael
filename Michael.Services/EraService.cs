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
        public EraService(Guid userId)
        {
            _context = new ApplicationDbContext();
            _userId = userId;

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
            return _context.SaveChanges() ==1;
             

        }


        //GET ALL
        public async Task<List<EraListItem>> GetAllErasAsync()
        {
            //GET all Eras from db
            var entityList = await _context.Eras.ToListAsync();

            //turn themeEras into EralistItems
            var EraList = entityList.Select(Era => new EraListItem
            {
                EraId = Era.EraId,
                EraName = Era.EraName,

            }).ToList();
            //return changed list
            return EraList;
        }

        //GET BY ID
        public async Task<EraDetail> GetEraByIdAsync(int EraId)
        {
            //Search Database by Id for Era
            var entity = await _context.Eras.FindAsync(EraId);
            if (entity == null)
                throw new Exception("No Era found.");
            //Turn the entity into the Detail

            var model = new EraDetail
            {
                EraId = entity.EraId,
                EraName = entity.EraName,
                Albums = entity.Albums
            };
            return model;
        }
    }
}
