using Microsoft.EntityFrameworkCore;
using MsgBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsgBoard.Data
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
            : base(options)
        {
        }

        public DbSet<MessagePost> MessagePost { get; set; }
        public DbSet<MessageResponse> MessageResponse { get; set; }
    }
}
