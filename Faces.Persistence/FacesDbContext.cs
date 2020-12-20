using Faces.Application.Interfaces;
using Faces.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Faces.Persistence
{
    public class FacesDbContext : DbContext, IFacesDbContext
    {
        public FacesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Image> Images
        {
            get; set;
        }
    }
}
