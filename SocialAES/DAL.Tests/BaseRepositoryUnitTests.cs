using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DAL.Tests;

    public class BaseRepositoryUnitTests
    {
    [Fact]
    public void Create_InputPostInstance_CalledAddMethodOfDBSetWithPostInstance() 
    {
        //Arrange
        DbContextOptions options = new DbContextOptionsBuilder<SocialAESContext>()
            .Options;
        var mockContext = new Mock<SocialAESContext>(options);
        var mockDbSet = new Mock<DbSet<Post>>();
        mockContext
           .Setup(context =>
           context.Set<Post>(
                 ))
           .Returns(mockDbSet.Object);
        var repository = new TestPostRepository(mockContext.Object);
        Post expectedPost = new Mock<Post>().Object;

        //Act
        repository.Create(expectedPost);
        //Assert
        mockDbSet.Verify(
            dbSet => dbSet.Add(
                expectedPost
                ), Times.Once());
    }
    [Fact]
    public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
    {
        // Arrange
        DbContextOptions options = new DbContextOptionsBuilder<SocialAESContext>()
        .Options;
        var mockContext = new Mock<SocialAESContext>(options);
        var mockDbSet = new Mock<DbSet<Post>>();
        mockContext
        .Setup(context =>
        context.Set<Post>(
        ))
        .Returns(mockDbSet.Object);
        Post expectedPost = new Post() { postID = 1 };
        mockDbSet.Setup(mock => mock.Find(expectedPost.postID))
        .Returns(expectedPost);
        var repository = new TestPostRepository(mockContext.Object);
        //Act
        var actualPost = repository.Get(expectedPost.postID);
        // Assert
        mockDbSet.Verify(
        dbSet => dbSet.Find(
        expectedPost.postID
        ), Times.Once());
        Assert.Equal(expectedPost, actualPost);
    }
    [Fact]
    public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
    {
        // Arrange
        DbContextOptions options = new DbContextOptionsBuilder<SocialAESContext>()
        .Options;
        var mockContext = new Mock<SocialAESContext>(options);
        var mockDbSet = new Mock<DbSet<Post>>();
        mockContext
        .Setup(context =>
        context.Set<Post>(
        ))
        .Returns(mockDbSet.Object);
        var repository = new TestPostRepository(mockContext.Object);
        Post expectedPost = new Post() { postID = 1 };
        mockDbSet.Setup(mock => mock.Find(expectedPost.postID))
        .Returns(expectedPost);
        //Act
        repository.Delete(expectedPost.postID);
        // Assert
        mockDbSet.Verify(
        dbSet => dbSet.Find(
        expectedPost.postID
        ), Times.Once());
        mockDbSet.Verify(
        dbSet => dbSet.Remove(
        expectedPost
        ), Times.Once());
    }
}

