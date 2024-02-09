using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
            Name = name;
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            ValidateDomain(name);
            Id = id;
            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
            Name = name;
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");
        }

        public ICollection<Product>? Products { get; set; }
    }
}
