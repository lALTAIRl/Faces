using Newtonsoft.Json;
using System.Collections.Generic;

namespace Faces.Application.Models
{
    public class ImageEvaluationResultModel
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("time_used")]
        public int TimeUsed { get; set; }

        [JsonProperty("faces")]
        public List<Face> Faces { get; set; }

        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        [JsonProperty("face_num")]
        public int FacesQuantity { get; set; }
    }

    public class Face
    {
        [JsonProperty("face_token")]
        public string FaceToken { get; set; }

        [JsonProperty("face_rectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        //public Landmark landmark { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

    }

    public class FaceRectangle
    {
        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("left")]
        public int Left { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("age")]
        public Age Age { get; set; }

        [JsonProperty("smile")]
        public Smile Smile { get; set; }

        [JsonProperty("eyestatus")]
        public Eyestatus EyeStatus { get; set; }

        [JsonProperty("glass")]
        public Glass Glass { get; set; }
    }

    public class Gender
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Age
    {
        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class Smile
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("threshold")]
        public double Threshold { get; set; }
    }

    public class Glass
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Eyestatus
    {
        [JsonProperty("left_eye_status")]
        public OneEyeStatus LeftEyeStatus { get; set; }

        [JsonProperty("right_eye_status")]
        public OneEyeStatus RightEyeStatus { get; set; }
    }

    public class OneEyeStatus
    {
        [JsonProperty("no_glass_eye_open")]
        public double NoGlassEyeOpen { get; set; }

        [JsonProperty("no_glass_eye_close")]
        public double NoGlassEyeClose { get; set; }

        [JsonProperty("normal_glass_eye_open")]
        public double NormalGlassEyeOpen { get; set; }

        [JsonProperty("normal_glass_eye_close")]
        public double NormalGlassEyeClose { get; set; }

        [JsonProperty("dark_glasses")]
        public double DarkGlasses { get; set; }

        [JsonProperty("occlusion")]
        public double Occlusion { get; set; }
    }
}
