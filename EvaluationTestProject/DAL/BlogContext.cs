using System.Data.Entity;
using EvaluationTestProject.Models;


namespace EvaluationTestProject.DAL
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
}