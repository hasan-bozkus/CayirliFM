using CayirliFM.DtoLayer.Dtos.HiggingFaceDto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.External
{
    public class HuggingFaceManager : IHuggingFaceService
    {
        private readonly HttpClient _httpClient;
        private readonly string _huggingFaceTraslantionModelUrl;
        private readonly string _huggingFaceToxicityModelUrl;
        private readonly string _apiKey;

        public HuggingFaceManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _huggingFaceTraslantionModelUrl = configuration["HuggingFace:HuggingFaceTranslationModel"];
            _huggingFaceToxicityModelUrl = configuration["HuggingFace:HuggingFaceToxicityModel"];
            _apiKey = configuration["HuggingFace:ApiKey"];
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ToxicityDedectionResultDto> DetectionToxicityAsync(string commentText)
        {
            var requestBody = new { inputs = commentText };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_huggingFaceToxicityModelUrl, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine(responseString);

                var modelResponse = JsonSerializer.Deserialize<List<List<ModelPredection>>>(responseString);

                var topPredection = modelResponse[0].OrderByDescending(p => p.score).FirstOrDefault();

                if (topPredection != null && topPredection.label.ToLower().Contains("toxic"))
                {
                    return new ToxicityDedectionResultDto
                    {
                        IsToxic =  topPredection.score > 0.5,
                        Score = topPredection.score,
                        DetectLabel = topPredection.label
                    };
                }
                else if (topPredection != null)
                {
                    return new ToxicityDedectionResultDto
                    {
                        IsToxic = false,
                        Score = topPredection.score,
                        DetectLabel = topPredection.label
                    };
                }
            }

            return new ToxicityDedectionResultDto
            {
                IsToxic = false,
                Score = 0,
                DetectLabel = "Un Dedected"
            };
        }

        private class ModelPredection
        {
            public string label { get; set; }
            public double score { get; set; }
        }

        public async Task<string> TranslationEnglishAsync(string turkishText)
        {
            var requestBody = new { inputs = turkishText };
            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_huggingFaceTraslantionModelUrl, jsonContent);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<TranslationResponse>>(responseString);

            return result?.FirstOrDefault()?.translation_text;
        }

        private class TranslationResponse
        {
            public string translation_text { get; set; }
        }
    }
}
