using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiTests.Models;

namespace RestApiTests.TestData
{
    public static class PetTestData
    {
        public static int _id = GenerateUniqueId();

        public static readonly HttpClient _httpClient = new HttpClient();
        public static string url = "https://petstore.swagger.io/v2/pet";
        public static string urlWithId = $"https://petstore.swagger.io/v2/pet/{_id}";

        public static string _petName = "Bob";
        public static string _petName2 = "Jack";

        public static string _status = "available";
        public static string _status2 = "unavailable";

        public static List<Tag> _tag = new List<Tag>() { new Tag { id = 1, name = "home" } };
        public static List<Tag> _tag2 = new List<Tag>() { new Tag { id = 1, name = "shelter" } };

        public static Category _category = new Category() { id = 1, name = "dog" };
        public static Category _category2 = new Category() { id = 0, name = "cat" };
        private static int GenerateUniqueId() => new Random().Next(1_000_000, int.MaxValue);

    }
}
