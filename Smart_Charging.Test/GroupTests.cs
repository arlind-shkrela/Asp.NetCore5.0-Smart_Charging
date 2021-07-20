using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Smart_ChargingApi.Interfaces;
using Smart_ChargingApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Smart_Charging.Test
{
    public class GroupTests
    {
        private readonly IGroup _dataRepository;
        public GroupTests(IGroup dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test1()
        {
             var okResult = await _dataRepository.GetAsync();
                // Assert
             Assert.IsAssignableFrom<List<Group>>(okResult);
        }
    }
}