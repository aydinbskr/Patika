using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.BookOperations.Commands;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.UnitTests.TestsSetup;
using WebAPI.Validators;
using static WebAPI.Application.BookOperations.Commands.CreateBookCommand;

namespace WebAPI.UnitTests.Application.BookOperations.Commands
{
    public class CreateBookCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var book = new Book
            {
                Title = "Test",
                GenreId = 1,
                PageCount = 100,
                PublishDate = DateTime.Now
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand createBookCommand = new CreateBookCommand(_context);
            createBookCommand.Model = new CreateBookModel { Title = book.Title };

            FluentActions
                .Invoking(() => createBookCommand.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Book zaten var!");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            //Arrenge
            CreateBookCommand createBookCommand = new CreateBookCommand(_context);
            createBookCommand.Model = new CreateBookModel
            {
                Title = "Hobbit3",
                PageCount = 1000,
                GenreId = 1,
                PublishDate = DateTime.Now.Date.AddYears(-1)
            };

            //Act
            FluentActions
                .Invoking(() => createBookCommand.Handle())
                .Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(b => b.Title == createBookCommand.Model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(createBookCommand.Model.PageCount);
            book.PublishDate.Should().Be(createBookCommand.Model.PublishDate);
            book.GenreId.Should().Be(createBookCommand.Model.GenreId);
            
        }
    }
}
