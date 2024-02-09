using System;

namespace RealEstateManagement.Domain.Entities;

public class PropertyHouseArea
{
    public float UsableArea { get; set; }

    public Guid PropertyId { get; set; }
    public Property Property { get; set; }
    public Guid HouseAreaId { get; set; }
    public HouseArea HouseArea { get; set; }
}