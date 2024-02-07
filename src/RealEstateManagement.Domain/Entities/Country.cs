using RealEstateManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace RealEstateManagement.Domain.Entities;

public class Country : BaseEntity<Guid>
{
    public Country()
    {
        Id = Guid.NewGuid();
        States = [];
    }

    public string Name { get; set; }

    public HashSet<State> States { get; set; }
}
