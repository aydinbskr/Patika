using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.BookOperations.Commands;
using WebAPI.UnitTests.TestsSetup;
using WebAPI.Validators;
using FluentAssertions;

namespace WebAPI.UnitTests.Application.BookOperations.Commands
{
    public class DeleteBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenIvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(null);
            deleteBookCommand.BookId = bookId;

            DeleteBookValidator validator = new DeleteBookValidator();
            var result = validator.Validate(deleteBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(null);
            deleteBookCommand.BookId = 1;

            DeleteBookValidator validator = new DeleteBookValidator();
            var result = validator.Validate(deleteBookCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
