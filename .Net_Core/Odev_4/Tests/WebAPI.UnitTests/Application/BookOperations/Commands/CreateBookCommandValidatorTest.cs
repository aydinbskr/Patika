using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPI.Application.BookOperations.Commands.CreateBookCommand;
using WebAPI.Application.BookOperations.Commands;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.UnitTests.TestsSetup;
using WebAPI.Validators;

namespace WebAPI.UnitTests.Application.BookOperations.Commands
{
    public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        
        [Theory]
        [InlineData("Lord of",0,0)]
        [InlineData("Lord of", 0, 1)]
        [InlineData("", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData(" ", 100, 1)]
        public void WhenIvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title,int pagecount, int genreId)
        {
            CreateBookCommand createBookCommand = new CreateBookCommand(null);
            createBookCommand.Model = new CreateBookModel 
            { 
                Title = title,
                PageCount = pagecount,
                GenreId = genreId,
                PublishDate = DateTime.Now.AddYears(-1)
            };

            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(createBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand createBookCommand = new CreateBookCommand(null);
            createBookCommand.Model = new CreateBookModel
            {
                Title = "Lord Of rings",
                PageCount = 100,
                GenreId = 1,
                PublishDate = DateTime.Now.Date
            };

            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(createBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand createBookCommand = new CreateBookCommand(null);
            createBookCommand.Model = new CreateBookModel
            {
                Title = "Lord Of rings",
                PageCount = 100,
                GenreId = 1,
                PublishDate = DateTime.Now.Date.AddYears(-1)
            };

            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(createBookCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
