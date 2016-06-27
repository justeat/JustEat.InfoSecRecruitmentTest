using System;
using System.Collections.Generic;
using InfoSecTechTest.Models;

namespace InfoSecTechTest.DAL
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            var articles = new List<Article>
            {
                new Article{Title="Article1",Body="Blah Blah Blah"},
                new Article{Title="Article2",Body="Blah Blah Blah"},
                new Article{Title="Article3",Body="Blah Blah Blah"},
            };

            articles.ForEach(s => context.Articles.Add(s));
            context.SaveChanges();
        }
    }
}