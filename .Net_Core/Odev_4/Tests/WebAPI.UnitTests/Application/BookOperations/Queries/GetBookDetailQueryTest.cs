using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPI.Application.BookOperations.Queries.GetBookDetailQuery;
using WebAPI.Application.BookOperations.Commands;
using WebAPI.UnitTests.TestsSetup;
using WebAPI.Validators;
using AutoMapper;
using FluentAssertions;
using WebAPI.Models;
using WebAPI.Application.BookOperations.Queries;

namespace WebAPI.UnitTests.Application.BookOperations.Queries
{
    public class GetBookDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            GetBookDetailQuery getBookDetailQuery = new GetBookDetailQuery(_context);
            getBookDetailQuery.BookId = 1000;

            FluentActions
                .Invoking(() => getBookDetailQuery.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeFetched()
        {
            //Arrenge
            GetBookDetailQuery getBookDetailQuery = new GetBookDetailQuery(_context);
            
            getBookDetailQuery.BookId = 1;

            //Act
            FluentActions
                .Invoking(() => getBookDetailQuery.Handle())
                .Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(b => b.Id == getBookDetailQuery.BookId);
            book.Should().NotBeNull();
       

        }
    }
}
