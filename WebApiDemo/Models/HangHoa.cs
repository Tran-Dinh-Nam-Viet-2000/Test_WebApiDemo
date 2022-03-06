﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Models
{
    public class HangHoa
    {
        public string Name_HangHoa { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
    public  class MaHangHoa : HangHoa
    {
        public Guid Ma_HangHoa { get; set; }
    }
}
