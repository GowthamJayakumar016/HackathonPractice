using ConsoleApp4.Ping;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace TestProject1.PingTest
{
    public class NetworkServiceTest
    {
        private readonly NetworkSErvice _Pnetwork;
        public NetworkServiceTest() 
        {
            _Pnetwork = new NetworkSErvice();
        }
        [Fact]
        public void NetworkServiceTest_Send_Returnstring()
        {
            var result = _Pnetwork.Send();
            result.Should().Be("Sucess");
        }
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        public  void NetworkServiceTest_Time_Returnint(int a,int b,int expected)
        {
          
            var result = _Pnetwork.Time(a, b);
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
        }
        [Fact]
        public void NetworkSErvice_Pingdate_Returndate()
        {
                var result = _Pnetwork.Pingdate();
                result.Should().BeAfter(1.January(2010));
                result.Should().BeBefore(1.January(2030));


        }
        [Fact]
        public void NetworkSErvice_PingOptions_Returnobject()
        {
            var expect = new PingOptions
            {
                Ttl = 1,
                DontFragment = true
            };
            var result = _Pnetwork.PingOptions();
            result.Should().BeEquivalentTo(expect);
            result.Should().BeOfType<PingOptions>();

        }
        [Fact]
        public void NetworkSErvice_Most_Returnobject()
        {
            var expect = new PingOptions
            {
                Ttl = 1,
                DontFragment = true
            };
            var result = _Pnetwork.Most();
            result.Should().ContainEquivalentOf(expect);
            result.Should().Contain(z => z.DontFragment == true);

        }
    }
}
