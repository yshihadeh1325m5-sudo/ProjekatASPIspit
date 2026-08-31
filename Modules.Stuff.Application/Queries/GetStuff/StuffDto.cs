using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Stuff.Application.Queries.GetStuff
{
    public class StuffDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public StuffDto(Guid id, string name, string code, decimal price, string description)
        {
            Id = id;
            Name = name;
            Code = code;
            Price = price;
            Description = description;
        }
    }
}