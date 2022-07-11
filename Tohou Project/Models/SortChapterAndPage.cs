using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Tohou_Project.Models
{
    public class SortChapterAndPage : IComparable
    {
        private int chapter, page;
        public SortChapterAndPage(int chapter, int page)
        {
            this.chapter = chapter;
            this.page = page;
        }

        public int CompareTo(object obj)
        {
            if (obj is SortChapterAndPage ob)
            {
                if (ob.chapter > chapter)
                    return -1;
                if (ob.chapter == chapter && ob.page > page)
                    return -1;
                return 1;
            }
            throw new ArgumentException();
        }
    }
}
