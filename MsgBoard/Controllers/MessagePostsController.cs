using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MsgBoard.Data;
using MsgBoard.Models;

namespace MsgBoard.Controllers
{
    public class MessagePostsController : Controller
    {
        private readonly MessageBoardContext _context;

        public MessagePostsController(MessageBoardContext context)
        {
            _context = context;
        }

        // GET: MessagePosts
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Index","Home",await _context.MessagePost.ToListAsync());
        }

        // GET: MessagePosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagePost = await _context.MessagePost
                .FirstOrDefaultAsync(m => m.ID == id);
            if (messagePost == null)
            {
                return NotFound();
            }

            return View(messagePost);
        }

        // GET: MessagePosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MessagePosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DatePosted")] MessagePost messagePost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(messagePost);
                await _context.SaveChangesAsync();
                ViewBag.MessagePost = messagePost;
            }
            return View(messagePost);
        }

        // GET: MessagePosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagePost = await _context.MessagePost
                .FirstOrDefaultAsync(m => m.ID == id);
            if (messagePost == null)
            {
                return NotFound();
            }

            return View(messagePost);
        }

       

        // POST: MessagePosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var messagePost = await _context.MessagePost.FindAsync(id);
            _context.MessagePost.Remove(messagePost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessagePostExists(int id)
        {
            return _context.MessagePost.Any(e => e.ID == id);
        }
    }
}
