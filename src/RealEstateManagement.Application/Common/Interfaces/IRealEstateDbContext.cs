using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Application.Common.Interfaces;

public interface IRealEstateDbContext
{
    #region property
    DbSet<Property> Property { get; set; }
    DbSet<HouseArea> HouseArea { get; set; }
    DbSet<Photo> Photo { get; set; }
    #endregion

    #region geo
    DbSet<Country> Country { get; set; }
    DbSet<State> State { get; set; }
    DbSet<City> City { get; set; }
    #endregion
}
