using Faces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Faces.Application.Models
{
    public class ImageViewModel
    {
        public Image OriginalImage
        {
            get; set;
        }

        public ImageEvaluationResultModel NeuralResult
        {
            get; set;
        }

    }
}
