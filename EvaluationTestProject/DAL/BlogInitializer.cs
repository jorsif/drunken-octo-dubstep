using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationTestProject.Models;

namespace EvaluationTestProject.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var blogs = new List<Blog>
            {
                new Blog { BlogId = 1, Name = "Blog 1", Description = "This is the first test blog", CreatedDate = DateTime.Parse("2014-08-01") },
                new Blog { BlogId = 2, Name = "Blog 2", Description = "This is the second test blog", CreatedDate = DateTime.Parse("2013-12-12") },
                new Blog { BlogId = 3, Name = "Blog 3", Description = "This is the third test blog", CreatedDate = DateTime.Parse("2000-01-01") }
            };
            blogs.ForEach(x => context.Blogs.Add(x));
            context.SaveChanges();
        }
    }
}