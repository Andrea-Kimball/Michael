﻿using Michael.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Michael.Models.Era
{
    public class EraDetail
    {
        public int EraId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}