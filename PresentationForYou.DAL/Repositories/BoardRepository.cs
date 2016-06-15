using PresentationForYou.DAL.EF;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;

namespace PresentationForYou.DAL.Repositories
{
    public class BoardRepository : IRepository<Board>
    {
        private PresentationForYouContext db;

        public BoardRepository(PresentationForYouContext context)
        {
            db = context;
        }

        public void Create(Board item)
        {
            db.Boards.Add(item);
        }

        public void Delete(int id)
        {
            db.Boards.Remove(Find(a => a.Id == id)?.FirstOrDefault());
        }

        public IEnumerable<Board> Find(Func<Board, bool> predicate) => db.Boards.Where(predicate).ToList();

        public Board Get(int id) => Find(a => a.Id == id).FirstOrDefault();

        public IEnumerable<Board> GetAll() => db.Boards;

        public void Update(Board item)
        {
            db.Boards.AddOrUpdate(item);
        }
    }
}