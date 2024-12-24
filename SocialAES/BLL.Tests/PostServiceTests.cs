﻿using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using Xunit;


namespace BLL.Tests;

public class PostServiceTests
{
    [Fact]
    public void Ctor_InputNull_ThrowArgumentNullException()
    {
        // Arrange
        IUnitOfWork? nullUnitOfWork = null;
        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(
            () => new PostService(nullUnitOfWork)
        );
    }

    [Fact]
    public void GetPosts_UserIsGuest_ThrowMethodAccessException()
    {
        // Arrange
        BaseUser user = new Guest(0, "test", "test");
        SecurityContext.SetUser(user);
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        IPostService postService = new PostService(mockUnitOfWork.Object);
        // Act
        // Assert
        Assert.Throws<MethodAccessException>(() => postService.GetPosts(0));
    }

    [Fact]
    public void GetPosts_PostFromDAL_CorrectMappingToPostDTO()
    {
        // Arrange
        BaseUser user = new Admin(1, "test", "test");
        SecurityContext.SetUser(user);
        var postService = GetPostService();
        // Act
        var actualPostDto = postService.GetPosts(0).First();
        // Assert
        Assert.True(
            actualPostDto.postID == 1
            && actualPostDto.userID == 1
            && actualPostDto.Text == "text"
            && actualPostDto.Date == "date"
        );
    }

    IPostService GetPostService()
    {
        var mockContext = new Mock<IUnitOfWork>();
        var expectedPost = new Post()
        {
            postID = 1,
            userID = 1,
            Text = "text",
            Date = "date"
        };
        var mockDbSet = new Mock<IPostRepository>();
        mockDbSet
            .Setup(z =>
                z.Find(
                    It.IsAny<Func<Post, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
            .Returns(
                new List<Post>() { expectedPost }
            );
        mockContext
            .Setup(context =>
                context.Posts)
            .Returns(mockDbSet.Object);
        IPostService postService = new PostService(mockContext.Object);
        return postService;
    }
}