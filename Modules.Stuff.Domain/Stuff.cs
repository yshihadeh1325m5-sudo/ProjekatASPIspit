using Shared.Kernel;
using System;

namespace Modules.Stuff.Domain
{
    public class StuffItem : BaseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }

        public StuffItem(Guid id, string name, string code, decimal price, string description)
        {
            Id = id;
            Name = name;
            Code = code;
            Price = price;
            Description = description;
        }

        public void UpdateDetails(string name, string code, decimal price, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Naziv ne može biti prazan.");

            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Kod ne može biti prazan.");

            Name = name;
            Code = code;
            Price = price;
            Description = description;
        }
    }
}