using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValues()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9M, 99, "product.jpg");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.9M, 99, "product.jpg");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(1, "ab", "Product Description", 9.9M, 99, "product.jpg");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product Name", "Prod", 9.9M, 99, "product.jpg");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact]
        public void CreateProduct_WithNullNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(1, null, "Product Description", 9.9M, 99, "product.jpg");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(1, "", "Product Description", 9.9M, 99, "product.jpg");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateProduct_LongImageString_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9M, 99, "product.jpgaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact]
        public void CreateProduct_ImageNull_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9M, 99, null);

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ResultDomainExceptionValidation(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.9M, value, "product.png");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid stock value.");
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -12M, 50, "product.png");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid price value.");
        }
    }
}
