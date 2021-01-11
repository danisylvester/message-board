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

        // GET: Message Responses with Message Post ID
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



            //var post = await _context.MessagePost.FindAsync(id);
            
            //if (ModelState.IsValid)
            //{
            //    _context.Add(messageResponse);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(messageResponse);
        }

        // GET: MessageResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messageResponse = await _context.MessageResponse.FindAsync(id);
            if (messageResponse == null)
            {
                return NotFound();
            }
            return View(messageResponse);
        }

        // POST: MessageResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,DatePosted")] MessageResponse messageResponse)
        {
            if (id != messageResponse.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(messageResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageResponseExists(messageResponse.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(messageResponse);
        }

        // GET: MessageResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messageResponse = await _context.MessageResponse
                .FirstOrDefaultAsync(m => m.ID == id);
            if (messageResponse == null)
            {
                return NotFound();
            }

            return View(messageResponse);
        }

        // POST: MessageResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var messageResponse = await _context.MessageResponse.FindAsync(id);
            _context.MessageResponse.Remove(messageResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageResponseExists(int id)
        {
            return _context.MessageResponse.Any(e => e.ID == id);
        }
    }
}
