using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestApiTests.Helpers;
using RestApiTests.Models;
using static RestApiTests.TestData.PetTestData;

namespace Tests.CRUD_Tests
{
    [TestClass]
    public sealed class PetUpdateTests
    {
        [TestInitialize]
        public async Task TestInitialize()
        {
            var pet = CreatePetHelper.CreatePet(_id, _category, _petName, _tag, _status);
            var content = JsonHelper.SerializeContentToJson(pet);
            var postResponse = await _httpClient.PostAsync(url, content);
        }

        [TestMethod]
        public async Task UpdatePet_ShouldReturnOK()
        {
            var pet = CreatePetHelper.CreatePet(_id, _category2, _petName2, _tag2, _status2);
            var content = JsonHelper.SerializeContentToJson(pet);

            var putResponse = await _httpClient.PutAsync(url, content);

            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode);
            Assert.AreEqual(_id, pet.id);
            Assert.AreEqual(_category2.id, pet.category.id);
            Assert.AreEqual(_category2.name, pet.category.name);
            Assert.AreEqual(_petName2, pet.name);
            Assert.AreEqual(_tag2.Count, pet.tags.Count);
            Assert.AreEqual(_tag2[0].id, pet.tags[0].id);
            Assert.AreEqual(_tag2[0].name, pet.tags[0].name);
            Assert.AreEqual(_status2, pet.status);
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            var delResponse = await _httpClient.DeleteAsync(urlWithId);
        }

    }
}
