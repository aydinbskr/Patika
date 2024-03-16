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

namespace WebAPI.UnitTests.Application.BookOperations.Commands
{
    public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DeleteBookCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            

            DeleteBookCommand createBookCommand = new DeleteBookCommand(_context);
            createBookCommand.BookId = 1000;

            FluentActions
                .Invoking(() => createBookCommand.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeDeleted()
        {
            //Arrenge
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
            deleteBookCommand.BookId = 1;

            //Act
            FluentActions
                .Invoking(() => deleteBookCommand.Handle())
                .Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(b => b.Id == deleteBookCommand.BookId);
            book.Should().BeNull();

        }
    }
}
