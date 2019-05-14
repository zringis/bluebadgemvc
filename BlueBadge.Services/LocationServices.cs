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
                        LocationCity = entity.LocationCity
                    };
            }
        }
        public bool UpdateNote(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == model.LocationId);

                entity.LocationState = model.LocationState;
                entity.LocationCity = model.LocationCity;
                return ctx.SaveChanges() == 1;
            }
        }

        

        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == locationId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        public bool LocationsExist()
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Locations.Count<Location>() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
