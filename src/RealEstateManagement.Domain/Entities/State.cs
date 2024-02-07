using RealEstateManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace RealEstateManagement.Domain.Entities;

public class State : BaseEntity<Guid>
{
    public State()
    {
        Id = Guid.NewGuid();
        Cities = [];
    }

    public string Name { get; set; }

    public HashSet<City> Cities { get; set; }
}
