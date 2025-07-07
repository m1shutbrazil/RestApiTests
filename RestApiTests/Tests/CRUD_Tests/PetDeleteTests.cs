using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestApiTests.Helpers;
using static RestApiTests.TestData.PetTestData;

namespace Tests.CRUD_Tests
{
    [TestClass]
    public sealed class PetDeleteTests
    {
        [TestInitialize]
        public async Task TestInitialize()
        {
            var pet = CreatePetHelper.CreatePet(_id, _category, _petName, _tag, _status);
            var content = JsonHelper.SerializeContentToJson(pet);
            var postResponse = await _httpClient.PostAsync(url, content);
        }

        [TestMethod]
        public async Task DeletePet_ShouldReturOK()
        {
            var delResponse = await _httpClient.DeleteAsync(urlWithId);

            Assert.AreEqual(HttpStatusCode.OK, delResponse.StatusCode);
        }

        [TestMethod]
        public async Task GetDeletedPet_ShouldReturnNotFound()
        {
            var delResponse = await _httpClient.DeleteAsync(urlWithId);
            var getResponse = _httpClient.GetAsync(urlWithId).GetAwaiter().GetResult();

            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            var delResponse = await _httpClient.DeleteAsync(urlWithId);
        }
    }
}
