using RealEstateManagement.Domain.Common;
using System;

namespace RealEstateManagement.Domain.Entities;

public class Photo : BaseEntity<Guid>
{
    public Photo()
    {
        Id = Guid.NewGuid();
    }

    public string Name { get; set; }
}
