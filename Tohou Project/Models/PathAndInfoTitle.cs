using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tohou_Project.Models
{
    public class PathAndInfoTitle
    {
        public Dictionary<string, SortedList<int, string>> chapters { get; set; }
        public InfoManga InfoManga { get; set; }

        public bool BeginReading { get; set; }

        public int NotReadChapter { get; set; }
    }
}
