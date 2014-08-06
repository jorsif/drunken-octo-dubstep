using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EvaluationTestProject.Models;

namespace EvaluationTestProject.DAL
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
}