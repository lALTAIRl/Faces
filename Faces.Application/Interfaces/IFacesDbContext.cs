using Faces.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Faces.Application.Interfaces
{
    public interface IFacesDbContext
    {
        DbSet<Image> Images
        {
            get; set;
        }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}
