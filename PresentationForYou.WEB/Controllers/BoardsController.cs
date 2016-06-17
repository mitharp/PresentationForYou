using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PresentationForYou.WEB.Models;
using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;

namespace PresentationForYou.WEB.Controllers
{
    public class BoardsController : Controller
    {
        IService<BoardDTO> boardService;
        IEnumerable<Board> Boards;
        public BoardsController()
        {

        }
        public BoardsController(IService<BoardDTO> boardService)
        {
            this.boardService = boardService;
            IEnumerable<BoardDTO> board = boardService.GetAll();
            Boards = board.Select(a => new Board
            {
                Id = a.Id,
                Height = a.Height,
                Name = a.Name,
                Type = a.Type,
                Width = a.Width
            }).ToList();
        }
        // GET: Boards
        public ActionResult Index()
        {
            return View(Boards);
        }

        // GET: Boards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var boardDTO = boardService.Get(id);
            if (boardDTO == null)
            {
                return HttpNotFound();
            }
            return View(new Board
            {
                Id = boardDTO.Id,
                Height = boardDTO.Height,
                Name = boardDTO.Name,
                Type = boardDTO.Type,
                Width = boardDTO.Width
            });
        }

        // GET: Boards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Height,Width")] Board board)
        {
            if (ModelState.IsValid)
            {
                boardService.Add(new BoardDTO
                {
                    Id = board.Id,
                    Height = board.Height,
                    Name = board.Name,
                    Type = board.Type,
                    Width = board.Width
                });
                return RedirectToAction("Index");
            }

            return View(board);
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var boardDTO = boardService.Get(id);
            Board board = new Models.Board
            {
                Id = boardDTO.Id,
                Height = boardDTO.Height,
                Name = boardDTO.Name,
                Type = boardDTO.Type,
                Width = boardDTO.Width
            };
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Height,Width")] Board board)
        {
            if (ModelState.IsValid)
            {
                boardService.Edit(new BoardDTO
                {
                    Id = board.Id,
                    Height = board.Height,
                    Name = board.Name,
                    Type = board.Type,
                    Width = board.Width
                });
                return RedirectToAction("Index");
            }
            return View(board);
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardDTO boardDTO = boardService.Get(id);
            Board board = new Board()
            {
                Id = boardDTO.Id,
                Height = boardDTO.Height,
                Name = boardDTO.Name,
                Type = boardDTO.Type,
                Width = boardDTO.Width
            };
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            boardService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                boardService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}