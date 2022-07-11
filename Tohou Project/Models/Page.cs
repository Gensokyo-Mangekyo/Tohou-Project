using System;
using System.Collections.Generic;

namespace Tohou_Project.Models
{
    public class Page
    {
        public int chapter { get; set; }

        public IEnumerable<string> pages { get; set; }

    }
}
