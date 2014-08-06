using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvaluationTestProject.DAL;
using EvaluationTestProject.Models;

using NUnit.Framework.Constraints;
using NUnit.Framework;

using Telerik.JustMock;

namespace EvaluationTestProject.Tests
{
    [TestFixture]
    class BasicTests
    {
        [Test]
        public void AddRecord_NewBlog_BlogIsAdded()
        {
            var db = new BlogContext();
            var results = new List<Blog>();

            var blog = new Blog
            {
                BlogId = 100,
                Name = "new",
                Description = "a test blog",
                CreatedDate = DateTime.Now
            };

            // Arrange
            Mock.Arrange(() => db.Blogs.Add(blog)).DoInstead((Blog b) => results.Add(b));
            Mock.Arrange(() => db.SaveChanges()).DoNothing();

            // Act
            db.Blogs.Add(blog);
            db.SaveChanges();

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(100, results[0].BlogId);
        }

        //[Test]
        //public void AutoFail()
        //{
        //    // use this test to cause an auto failure for tests
        //    Assert.True(false);
        //}
    }
}
