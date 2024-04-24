using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public record FooCreatedIntegrationEvent()
    {
        public string FooName { get; init; }
    }
}
