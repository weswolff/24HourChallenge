﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Data
{
    class Reply : Comment
    {
        public Comment ReplyComment { get; set; }
    }
}
