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
    public sealed class PetReadTests
    {
        [TestInitialize]
        public async Task TestInitialize()
        {
            var pet = CreatePetHelper.CreatePet(_id, _category, _petName, _tag, _status);
            var content = JsonHelper.SerializeContentToJson(pet);
            var postResponse = await _httpClient.PostAsync(url, content);
        }

        [TestMethod]
        public async Task GetPet_ShouldReturnOK()
        {
            var getResponse = await _httpClient.GetAsync(urlWithId);

            var pet = await JsonHelper.DeserializeContentToJson<Pet>(getResponse.Content);

            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.AreEqual(_id, pet.id);
            Assert.AreEqual(_category.id, pet.category.id);
            Assert.AreEqual(_category.name, pet.category.name);
            Assert.AreEqual(_petName, pet.name);
            Assert.AreEqual(_tag.Count, pet.tags.Count);
            Assert.AreEqual(_tag[0].id, pet.tags[0].id);
            Assert.AreEqual(_tag[0].name, pet.tags[0].name);
            Assert.AreEqual(_status, pet.status);
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            var delResponse = await _httpClient.DeleteAsync(urlWithId);
        }
    }
}
