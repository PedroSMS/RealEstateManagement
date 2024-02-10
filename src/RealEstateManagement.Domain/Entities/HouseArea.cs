using RealEstateManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace RealEstateManagement.Domain.Entities;

public class HouseArea : BaseEntity<Guid>
{
    public HouseArea()
    {
        Id = Guid.NewGuid();
        Properties = [];
    }

    public string Name { get; set; }

    public HashSet<PropertyHouseArea> Properties { get; set; }
}
