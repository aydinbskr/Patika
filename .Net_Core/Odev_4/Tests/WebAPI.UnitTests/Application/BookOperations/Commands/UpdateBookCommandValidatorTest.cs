using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPI.Application.BookOperations.Commands.UpdateBookCommand;
using WebAPI.Application.BookOperations.Commands;
using WebAPI.UnitTests.TestsSetup;
using WebAPI.Validators;
using FluentAssertions;

namespace WebAPI.UnitTests.Application.BookOperations.Commands
{
    public class UpdateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("Lord of", 0, 0)]
        [InlineData("Lord of", 0, 1)]
        [InlineData("", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData(" ", 100, 1)]
        public void WhenIvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pagecount, int genreId)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(null);
            updateBookCommand.Model = new UpdateBookModel
            {
                Title = title,
                PageCount = pagecount,
                GenreId = genreId,
                PublishDate = DateTime.Now.AddYears(-1)
            };

            UpdateBookValidator validator = new UpdateBookValidator();
            var result = validator.Validate(updateBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(null);
            updateBookCommand.Model = new UpdateBookModel
            {
                Title = "Lord Of rings",
                PageCount = 100,
                GenreId = 1,
                PublishDate = DateTime.Now.Date
            };

            UpdateBookValidator validator = new UpdateBookValidator();
            var result = validator.Validate(updateBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(null);
            updateBookCommand.Model = new UpdateBookModel
            {
                Title = "Lord Of rings",
                PageCount = 100,
                GenreId = 1,
                PublishDate = DateTime.Now.Date.AddYears(-1)
            };
            updateBookCommand.BookId = 1;

            UpdateBookValidator validator = new UpdateBookValidator();
            var result = validator.Validate(updateBookCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
