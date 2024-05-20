using NumAndDrive.Models;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NumAndDrive.Utilities
{
    public class AddressUtilities
    {
        private readonly IConfiguration _configuration;

        public AddressUtilities(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Address> FormatAddressWithAPIAsync(string researchedAddress)
        {
            string baseUrl = @"https://api-adresse.data.gouv.fr/search/?q=";
            string formatedUserResearch = researchedAddress.Replace(' ', '+');
            string url = baseUrl + formatedUserResearch;

            try
            {
                using HttpClient httpClient = new HttpClient();
                string jsonString = await httpClient.GetStringAsync(url);

                JsonObject jsonObject = JsonNode.Parse(jsonString).AsObject();
                JsonArray features = jsonObject["features"].AsArray();
                Address address = new Address();

                foreach (JsonNode node in features)
                {
                    address.Coordinates = node["geometry"]["coordinates"].AsArray().Select(x => (double)x).ToArray();
                    address.City = node["properties"]["city"].ToString();
                    address.PostalCode = node["properties"]["postcode"].ToString();
                    address.Street = node["properties"]["name"].ToString();
                }

                return address;

            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error during the process.", ex);
            }
        }

        public async Task<int> CalculateTravelTimeAsync(double[] personnalCoordinates, double[] schoolCoordinates)
        {
            string origins = FormatingCoordinatesToString(personnalCoordinates);
            string destinations = FormatingCoordinatesToString(schoolCoordinates);
            string apiKey = _configuration.GetValue<string>("GoogleMaps:ApiKey");

            string url = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={origins}&destinations={destinations}&key={apiKey}";

            using HttpClient httpClient = new HttpClient();
            string jsonString = await httpClient.GetStringAsync(url);

            using JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement root = doc.RootElement;

            if (root.GetProperty("status").GetString() != "OK")
            {
                throw new HttpRequestException("Erreur lors de la requête à l'API Distance Matrix.");
            }

            JsonElement rows = root.GetProperty("rows");

            if (rows.GetArrayLength() == 0)
            {
                throw new HttpRequestException("Aucun résultat trouvé pour les adresses fournies.");
            }

            JsonElement elements = rows[0].GetProperty("elements");

            if (elements[0].GetProperty("status").GetString() != "OK")
            {
                throw new HttpRequestException("Erreur lors de la requête à l'API Distance Matrix pour les éléments.");
            }

            int travelTimeInSeconds = elements[0].GetProperty("duration").GetProperty("value").GetInt32();

            return travelTimeInSeconds;
        }

        private string FormatingCoordinatesToString(double[] coordinates)
        {
            string longitude = coordinates[0].ToString().Replace(',', '.');
            string latitude = coordinates[1].ToString().Replace(',', '.');

            return latitude + ',' + longitude;
        }
    }
}
