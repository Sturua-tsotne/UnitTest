using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetworkUtility.Tests.ping
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            var pingService = new NetworkService();

            //Act
            var result = pingService.SendPing();


            //assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping  sent!");
            result.Should().Contain("Success", Exactly.Once());



        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b , int expected)
        {
            //Arrange
            var pingService = new NetworkService();
            //Act

            var result = pingService.PingTimeout(a, b);
            //Assert    

            result.Should().Be(expected);
            //result.Should().BeGreaterThanOrEqualTo(3);
            result.Should().NotBeInRange(-10000,0);


        }

    }
}
