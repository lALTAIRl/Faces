using Faces.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Faces.FacePlusPlus.Services
{
    public class FacePlusPlusService : IFacePlusPlusService
    {
        public async Task DetectFace(string imageUrl)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api-us.faceplusplus.com/facepp/v3/detect"),
                Headers =
                {
                    //{ "x-rapidapi-key", "e40e97ba8cmsh23971fc330c7308p1c9046jsnff0a79d64009" },
                    //{ "x-rapidapi-host", "faceplusplus-faceplusplus.p.rapidapi.com" },
                    //{ "api_key", "default-application_4921968"}
                },
                Content = new FormUrlEncodedContent(
                        new Dictionary<string, string>
                        {
                            {"api_key", "OO-Nlujdjwcx3YkzLI62xos7D-8tk6-x"},
                            {"api_secret", "beuxqr3bDsyxly7hP9iPrrgoWQ4FnshO"},
                            {"image_url", imageUrl},
                            //{"return_landmark", "0"},
                            {"return_attributes", "gender,age,eyestatus,mouthstatus"}
                        }
                    )
            };
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(body);

            throw new NotImplementedException();
        }

        public async Task GetFaceLandmarks(string imageURL)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(
                    "https://faceplusplus-faceplusplus.p.rapidapi.com/facepp/v1/face/thousandlandmark?return_landmark=all&image_url="
                    + imageURL
                    ),
                Headers =
                {
                    { "x-rapidapi-key", "e40e97ba8cmsh23971fc330c7308p1c9046jsnff0a79d64009" },
                    { "x-rapidapi-host", "faceplusplus-faceplusplus.p.rapidapi.com" },
                    { "api_key", "default-application_4921968"}
                },
            };
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(body);

            throw new NotImplementedException();
        }
    }
}
