namespace Faces.Settings
{
    public class FacePlusPlusSettings : IApplicationSettings
    {
        public string ApiUrl
        {
            get; set;
        }

        public string ApiKey
        {
            get; set;
        }

        public string ApiSecret
        {
            get; set;
        }
    }
}
