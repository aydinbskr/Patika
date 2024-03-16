using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPI.Application.BookOperations.Commands.UpdateBookCommand;
using WebAPI.Application.BookOperations.Commands;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.UnitTests.TestsSetup;

namespace WebAPI.UnitTests.Application.BookOperations.Commands
{
    public class UpdateBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBookCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            
            UpdateBookCommand UpdateBookCommand = new UpdateBookCommand(_context);
            UpdateBookCommand.BookId = 1000;

            FluentActions
                .Invoking(() => UpdateBookCommand.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
            //Arrenge
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
            updateBookCommand.Model = new UpdateBookModel
            {
                Title = "Hobbit12",
                PageCount = 1000,
                GenreId = 1,
                PublishDate = DateTime.Now.Date.AddYears(-1)
            };
            updateBookCommand.BookId = 1;

            //Act
            FluentActions
                .Invoking(() => updateBookCommand.Handle())
                .Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(b => b.Title == updateBookCommand.Model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(updateBookCommand.Model.PageCount);
            book.PublishDate.Should().Be(updateBookCommand.Model.PublishDate);
            book.GenreId.Should().Be(updateBookCommand.Model.GenreId);

        }
    }
}
