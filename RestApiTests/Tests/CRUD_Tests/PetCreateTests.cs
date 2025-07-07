using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RestApiTests.Helpers;
using RestApiTests.Models;
using static RestApiTests.TestData.PetTestData;

namespace Tests.CRUD_Tests
{
    [TestClass]
    public sealed class PetCreateTests
    {
        [TestInitialize]
        public async Task TestInitialize()
        {

        }

        [TestMethod]
        public async Task CreatePet_ShouldReturnOK()
        {
            var pet = CreatePetHelper.CreatePet(_id, _category, _petName, _tag, _status);

            var content = JsonHelper.SerializeContentToJson(pet);
            var postResponse = await _httpClient.PostAsync(url, content);

            Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);
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
