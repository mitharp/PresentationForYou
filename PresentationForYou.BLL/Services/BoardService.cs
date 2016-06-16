using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PresentationForYou.BLL.Services
{
    public class BoardService : IService<BoardDTO>
    {
        IUnitOfWork Database { get; set; }

        public BoardService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(BoardDTO board)
        {
            Database.Boards.Create(new Board
            {
                Id = board.Id,
                Height = board.Height,
                Name = board.Name,
                Type = board.Type,
                Width = board.Width
            });
            Database.Save();
        }

        public void Dispose() { }

        public void Edit(BoardDTO board)
        {
            Database.Boards.Update(new Board
            {
                Id = board.Id,
                Height = board.Height,
                Name = board.Name,
                Type = board.Type,
                Width = board.Width
            });
            Database.Save();
        }

        public void Remove(int id)
        {
            Database.Boards.Delete(id);
            Database.Save();
        }

        public BoardDTO Get(int? id)
        {
            if (id == null)
                throw new Exception("ERROR");
            var board = Database.Boards.Get(id.Value);
            if (board == null)
                throw new Exception("ERROR");

            return new BoardDTO
            {
                Id = board.Id,
                Height = board.Height,
                Name = board.Name,
                Type = board.Type,
                Width = board.Width
            };
        }

        public IEnumerable<BoardDTO> GetAll()
        {
            List<BoardDTO> boardsDTO = new List<BoardDTO>();
            var boards = Database.Boards.GetAll();
            foreach (var board in boards)
                boardsDTO.Add(new BoardDTO
                {
                    Id = board.Id,
                    Height = board.Height,
                    Name = board.Name,
                    Type = board.Type,
                    Width = board.Width
                });
            return boardsDTO;
        }
    }
}