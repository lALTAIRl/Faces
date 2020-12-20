using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faces.Domain.Entities
{
    public class Image
    {
        public int Id
        {
            get; set;
        }

        [NotMapped]
        public IFormFile Picture
        {
            get; set;
        }

    }
}
