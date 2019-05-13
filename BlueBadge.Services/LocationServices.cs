using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class LocationServices
    {
        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    LocationState = model.LocationState,
                    LocationCity = model.LocationCity,
                    LocationAddress = model.LocationAddress
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<LocationListItem> GetLocation()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    LocationId = e.LocationId,
                                    LocationState = e.LocationState,
                                    LocationCity = e.LocationCity,
                                    LocationAddress = e.LocationAddress
                                }
                        );

                return query.ToArray();
            }
        }

        public LocationDetails GetLocationById(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == locationId);
                return
                    new LocationDetails
                    {
                        LocationId = entity.LocationId,
                        LocationState = entity.LocationState,
                        LocationCity = entity.LocationCity,
                        LocationAddress = entity.LocationAddress
                    };
            }
        }
    }
}
