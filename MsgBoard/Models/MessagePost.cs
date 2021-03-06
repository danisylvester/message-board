using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MsgBoard.Models
{
    public class MessagePost
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        private DateTime datePosted = DateTime.Now;
        public DateTime DatePosted
        {
            get { return datePosted; }
            set { datePosted = value; }
        }
        public ICollection<MessageResponse> MessageResponses { get; set; }
    }
}
