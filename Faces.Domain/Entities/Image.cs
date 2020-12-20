using System.ComponentModel.DataAnnotations;

namespace Faces.Domain.Entities
{
    public class Image
    {
        public int Id
        {
            get; set;
        }

        [Required]
        public string ImageUrl
        {
            get; set;
        }
    }
}
