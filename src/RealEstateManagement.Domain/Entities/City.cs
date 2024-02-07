using RealEstateManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace RealEstateManagement.Domain.Entities;

public class City : BaseEntity<Guid>
{
    public City()
    {
        Id = Guid.NewGuid();
        Properties = [];
    }

    public string Name { get; set; }

    public HashSet<Property> Properties { get; set; }
}
