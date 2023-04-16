using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetworkUtility.Tests.ping
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;

        public NetworkServiceTests()
        {
            _pingService = new NetworkService();    
        }


        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            
            //Act
            var result = _pingService.SendPing();


            //assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping  sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange
            //Act

            var result = _pingService.PingTimeout(a, b);
            //Assert    

            result.Should().Be(expected);
            //result.Should().BeGreaterThanOrEqualTo(3);
            result.Should().NotBeInRange(-10000, 0);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
           
            //Act
            var result = _pingService.LastPingDate();

            //assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));

        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()
        {

            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act

            var result = _pingService.GetPingOptions();

            // Assert Worning: "Be" Careful

            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(expected.Ttl);
        }


        [Fact]
        public void NetworkService_MostRecentPings_ReturnsObject()
        {

            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act

            var result = _pingService.MostRecentPings();

            // Assert Worning: "Be" Careful

           // result.Should().BeOfType<List<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x=>x.DontFragment==true);
        }
    }
}
