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

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
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
    }
}
