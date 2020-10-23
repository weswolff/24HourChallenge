using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Models
{
    public class PostEdit
    {
        public int PostId { get; set; }
        public string Comment { get; set; }
        public bool IsLiked { get; set; }
    }
}
