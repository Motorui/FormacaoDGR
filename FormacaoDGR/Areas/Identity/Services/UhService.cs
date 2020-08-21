using Microsoft.EntityFrameworkCore;
using FormacaoDGR.Areas.Identity.Models;
using FormacaoDGR.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormacaoDGR.Areas.Identity.Services
{
    public interface IUhService
    {
        IList<Uh> GetAllUhs();
        Uh GetUh(Guid id);
        Uh AddUh(Uh uh);
        Uh UpdateUh(Uh uh);
        Uh DeleteUh(Uh uh);
    }

    public class UhService : IUhService
    {
        private readonly ApplicationDbContext _db;

        public UhService(ApplicationDbContext context)
        {
            _db = context;
        }

        public IList<Uh> GetAllUhs()
        {
            IList<Uh> uhs = _db.Uhs.ToList();
            return uhs;
        }

        public Uh GetUh(Guid id)
        {
            Uh uh = _db.Uhs.Find(id);
            return uh;
        }

        public Uh AddUh(Uh uh)
        {
            _db.Uhs.Add(uh);
            _db.SaveChanges();
            return uh;
        }

        public Uh UpdateUh(Uh uh)
        {
            //_db.Uhs.Update(uh);
            _db.Entry(uh).State = EntityState.Modified;
            _db.SaveChanges();
            return uh;
        }

        public Uh DeleteUh(Uh uh)
        {
            _db.Uhs.Remove(uh);
            _db.SaveChanges();
            return uh;
        }

    }
}
