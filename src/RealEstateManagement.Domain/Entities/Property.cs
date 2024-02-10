using RealEstateManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace RealEstateManagement.Domain.Entities;

public class Property : BaseEntity<Guid>
{
    public Property()
    {
        Id = Guid.NewGuid();
        Photos = [];
        Areas = [];
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string EnergyCertificate { get; set; }
    public float? GrossArea { get; set; }
    public float? AreaOfLand { get; set; }
    public decimal PriceEur { get; set; }

    public City City { get; set; }
    public Guid CityId { get; set; }
    public ETypology TypologyId { get; set; }
    public ECondition ConditionId { get; set; }

    public HashSet<Photo> Photos { get; set; }
    public HashSet<PropertyHouseArea> Areas { get; set; }
}