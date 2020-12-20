using System.Threading.Tasks;

namespace Faces.Application.Interfaces
{
    public interface IFacePlusPlusService
    {
        Task DetectFace(string imageURL);

        Task GetFaceLandmarks(string imageURL);
    }
}
