using System;
using System.Collections.Generic;
using InfoSecTechTest.Models;

namespace InfoSecTechTest.DAL
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseAlways<SiteContext>
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

            var users = new List<User>
            {
                new User{Username="admin",Password="jsj3l4"},
                new User{Username="superadmin",Password="rt5rf"}
            };

            users.ForEach(s => context.Users.Add(s));

            context.SaveChanges();
        }
    }
}