using Faces.Application.Models;
using System.Threading.Tasks;

namespace Faces.Application.Interfaces
{
    public interface IFacePlusPlusService
    {
        Task<ImageEvaluationResultModel> DetectFace(string imageURL);
    }
}
