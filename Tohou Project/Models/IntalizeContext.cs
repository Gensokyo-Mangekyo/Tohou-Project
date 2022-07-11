using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tohou_Project.Models
{
    public static class IntalizeContext
    {

        private static int infoMangaid = 1;

        private static void AddNewObjectDatabase(InfoMangaContext context, object obj,string name)
        {
            if (!context.infoManga.Any())
            {
                context.Add(obj);
                foreach (var item in new PathRepository().chapters[name])
                {
                    context.Add(new AlreadyRed() { AlreadyPageRed = false, InfoMangaGetId = infoMangaid, chapter = item.Value });
                }
                infoMangaid++;
                context.SaveChanges();
            }

        }


        public static void Intiliaze(InfoMangaContext context)
        {
            var exampl = new InfoManga()
            {
                Name = "Seasonal Dream Vision",
                decsription = "Synopsis: 東方紫香花　～ Seasonal Dream Vision (Touhou Shikouhana, Violet Flowers and Incense of the East)\n" +
                              "is a semi-official Touhou fanbook. It is quite similar to Bohemian Archive in Japanese Red, as it features\n" +
                              "manga, a music CD, and a story by ZUN, all about Gensokyo. It ranges from drama to comedy, all focused on\n" +
                              "the strange world Touhou takes place in.",
                Image = "Vision.png",
            };
            //    if (!context.infoManga.Any())
            //    {
            //        int infoMangaid = 0;
            //        var exampl = new InfoManga() {
            //            Name = "Seasonal Dream Vision",
            //            decsription = "Synopsis: 東方紫香花　～ Seasonal Dream Vision (Touhou Shikouhana, Violet Flowers and Incense of the East)\n" +
            //                      "is a semi-official Touhou fanbook. It is quite similar to Bohemian Archive in Japanese Red, as it features\n" +
            //                      "manga, a music CD, and a story by ZUN, all about Gensokyo. It ranges from drama to comedy, all focused on\n" +
            //                      "the strange world Touhou takes place in.",
            //            Image = "Vision.png",
            //        };
            //        context.Add(exampl);
            //        infoMangaid++;

            //        foreach (var item in new PathRepository().chapters["Seasonal Dream Vision"])
            //        {
            //            context.Add(new AlreadyRed() { AlreadyPageRed = false,InfoMangaGetId = infoMangaid ,chapter = item.Value});
            //        }
            //       context.SaveChanges();


            //    }
            AddNewObjectDatabase(context, exampl, exampl.Name);
        }

    }
}
