using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.BookOperations.Queries;
using WebAPI.UnitTests.TestsSetup;
using WebAPI.Validators;

namespace WebAPI.UnitTests.Application.BookOperations.Queries
{
    public class GetBookDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenIvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId)
        {
            GetBookDetailQuery getBookDetailQuery = new GetBookDetailQuery(null);
            getBookDetailQuery.BookId = bookId;

            GetBookValidator validator = new GetBookValidator();
            var result = validator.Validate(getBookDetailQuery);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            GetBookDetailQuery getBookDetailQuery = new GetBookDetailQuery(null);
            getBookDetailQuery.BookId = 1;

            GetBookValidator validator = new GetBookValidator();
            var result = validator.Validate(getBookDetailQuery);

            result.Errors.Count.Should().Be(0);
        }
    }
}
