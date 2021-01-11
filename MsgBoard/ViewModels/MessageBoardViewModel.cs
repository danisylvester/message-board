using MsgBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsgBoard.ViewModels
{
    public class MessageBoardViewModel
    {
        public IEnumerable<MessagePost> Posts { get; set; }
        public IEnumerable<MessageResponse> Responses { get; set; }
    }
}
