using System;
using System.Linq;
using System.Collections.Generic;   
using TechTalk.SpecFlow;
using Telerik.JustMock;
using NUnit.Framework;
using EvaluationTestProject.DAL;
using EvaluationTestProject.Models;

namespace EvaluationTestProject.Tests
{
    [Binding]
    public class SortingSteps
    {
        public BlogContext Db = new BlogContext();
        public List<Blog> FakeDb = new List<Blog>();    
        public Blog Result;

        [Given(@"I want to know the oldest blog from the following list of blogs")]
        public void GivenIWantToKnowTheOldestBlogFromTheFollowingListOfBlogs(Table table)
        {
            // Arrange            
            Mock.Arrange(() => Db.Blogs).ReturnsCollection(FakeDb);
            Mock.Arrange(() => Db.Blogs.Add(Arg.IsAny<Blog>())).DoInstead((Blog b) => FakeDb.Add(b));
            Mock.Arrange(() => Db.SaveChanges()).DoNothing();

            // Act
            foreach (var data in table.Rows)
            {
                var blog = new Blog { BlogId = int.Parse(data["BlogId"]), CreatedDate = DateTime.Parse(data["CreationDate"]) };
                Db.Blogs.Add(blog);
            }
            Db.SaveChanges();
            
            var min = Db.Blogs.Min(blog => blog.CreatedDate);
            Result = (from b in Db.Blogs
                     where b.CreatedDate == min
                     select b).First();
        }
        
        [Then(@"the result should be blog id (.*)")]
        public void ThenTheResultShouldBeBlogId(int id)
        {
            Assert.AreEqual(id, Result.BlogId);
        }
    }
}
