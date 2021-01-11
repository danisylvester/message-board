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
    public class MessageResponsesController : Controller
    {
        private readonly MessageBoardContext _context;

        public MessageResponsesController(MessageBoardContext context)
        {
            _context = context;
        }

        // GET: All Responses for a Message Post
        public async Task<IActionResult> Index(int id)
        {
            var responses = await _context.MessageResponse
                .Where(r => r.MessagePost.ID == id).ToListAsync();
            if(responses == null)
            {
                return NotFound();
            }
            return View(responses);
        }

        // GET: MessageResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MessageResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, MessageResponse messageResponse)
        {
            if (ModelState.IsValid)
            {
                MessagePost messagePost = await _context.MessagePost.FirstOrDefaultAsync(post => post.ID == id);
                MessageResponse response = new MessageResponse
                {
                    Description = messageResponse.Description,
                    MessagePost = messagePost
                };
                _context.MessageResponse.Add(response);
                _context.SaveChanges();
                ViewBag.MessageResponse = response;

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
