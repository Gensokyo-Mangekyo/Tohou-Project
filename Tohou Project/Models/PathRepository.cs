using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using Tohou_Project.Extensions;
namespace Tohou_Project.Models
{
    public class PathRepository
    {
        public Dictionary<string, SortedList<SortChapterAndPage,string>> directories { get; private set; }
        public Dictionary<string, SortedList<int, string>> chapters { get; private set; }
        public PathRepository()
        {
            directories = new Dictionary<string, SortedList<SortChapterAndPage, string>>();
            chapters = new Dictionary<string, SortedList<int, string>>();
            directories.Add("Seasonal Dream Vision", GetList("DreamVision"));
            chapters.Add("Seasonal Dream Vision", GetListChapter("DreamVision"));
        }

        private SortedList<int,string> GetListChapter(string name)
        {
            var list = new SortedList<int, string>();
            foreach (var path in GetPathDirectories(name))
            {
                int number = int.Parse(path.Substring(path.LastIndexOf('\\') + 1).GetNumberStr());
                list.Add(number, $"Chapter {number+1}");
            }
            return list;
        }

        private SortedList<SortChapterAndPage,string> GetList(string name)
        {
            var list = new SortedList<SortChapterAndPage, string>();
            for (int i = 0; i < GetPathDirectories(name).Length; i++)
            {
                for (int j = 0; j < Directory.GetFiles(GetPathDirectories(name)[i]).Length; j++)
                {
                    int chapter = int.Parse(GetPathDirectories(name)[i].GetNumberStr());
                    int page = int.Parse(Directory.
                        GetFiles(GetPathDirectories(name)[i])[j].GetNumberStr());
                    list.Add(new SortChapterAndPage(chapter, page), Directory.GetFiles(GetPathDirectories(name)[i])[j]);
                }
            }
            return list;
        }

        private string[] GetPathDirectories(string name)
        {
            return Directory.GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DreamVision"));
        }
    }
}
