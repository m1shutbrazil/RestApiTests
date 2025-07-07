using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace RestApiTests.Helpers
{
    public class JsonHelper
    {
        public static StringContent SerializeContentToJson<T>(T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static async Task<T> DeserializeContentToJson<T>(HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions 
            { 
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
