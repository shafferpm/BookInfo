using BookInfo.API.Controllers;
using BookInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookInfo.API.Models;
using Xunit;
using BookInfo.API.Entities;
using AutoMapper;
using BookInfo.API.Profiles;
using Microsoft.OpenApi.Validations;

namespace BookInfo.Test
{
    public class AuthorsControllerTests
    {
        private readonly AuthorsController _authorsController;

        public AuthorsControllerTests()
        {
            var authorServiceMock = new Mock<IBookInfoRepository>();

            authorServiceMock.Setup(repo => repo.GetAuthorsAsync())
                .ReturnsAsync(new List<Author>()
                {
                    new Author("172-32-1176", "White", "Johnson", "408 496-7223")
                });

            var mapperConfiguration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookProfile>();
            });
            var mapper = new Mapper(mapperConfiguration);

            _authorsController = new AuthorsController(authorServiceMock.Object, mapper);
        }

        [Fact]
        public async Task GetAuthors_GetAction_MustReturnOkObjectResult()
        {
            // Arrange

            // Act
            var result = await _authorsController.GetAuthors();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<AuthorWithoutTitleDto>>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);            
        }

        [Fact]
        public async Task GetAuthors_GetAction_MustReturnNumberOfInputtedAuthors()
        {
            // Arrange

            // Act
            var result = await _authorsController.GetAuthors();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<AuthorWithoutTitleDto>>>(result);

            // Check if the number of authors returned is equal to the number of authors inputted
            Assert.Equal(1, 
                ((IEnumerable<AuthorWithoutTitleDto>)
                ((OkObjectResult)actionResult.Result).Value).Count());
        }

        [Fact]
        public async Task GetAuthor_GetAction_MustReturnOkObjectResultWithCorrectAmountOfInternalEmployees()
        {
            // Arrange

            // Act
            var result = await _authorsController.GetAuthors();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<AuthorWithoutTitleDto>>>(result);

            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            var dtos = Assert.IsAssignableFrom<IEnumerable<AuthorWithoutTitleDto>>(okObjectResult.Value);

            Assert.Equal(1, dtos.Count());
        }
    }
}
