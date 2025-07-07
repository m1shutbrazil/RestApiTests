using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RestApiTests.Models;

namespace RestApiTests.Helpers
{
    public class CreatePetHelper
    {
        public static Pet CreatePet(int id, Category category, string petName, List<Tag> tag, string status)
        {
            return new Pet()
            {
                id = id,
                category = category,
                name = petName,
                photoUrls = new List<string> { "string" },
                tags = tag,
                status = status
            };
        }
    
    }
}
