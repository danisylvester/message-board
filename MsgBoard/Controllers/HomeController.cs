using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MsgBoard.Data;
using MsgBoard.Models;
using MsgBoard.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MsgBoard.Controllers
{
    public class HomeController : Controller
    {

        private readonly MessageBoardContext _context;

        public HomeController(MessageBoardContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            MessageBoardViewModel viewModel = new MessageBoardViewModel();
            viewModel.Posts = await _context.MessagePost.ToListAsync();
            viewModel.Responses = await _context.MessageResponse.ToListAsync();
            return View(viewModel);
        }

    }
}
