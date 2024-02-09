using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValues()
        {
            Action action = () => new Category(1, "Category Name");

            action.Should()
                .NotThrow<DomainExceptionValidation>();

        }

        [Fact]
        public void CreateCategory_NegativeIdValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid id value.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Category(1, "ab");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Category(1, null);

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Category(1, "");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }
    }
}