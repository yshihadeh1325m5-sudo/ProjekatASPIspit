using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Stuff.Application.Commands.CreateStuff
{
    public record UpdateStuffCommand(Guid Id, string Name, string Code, decimal Price, string Description);
}