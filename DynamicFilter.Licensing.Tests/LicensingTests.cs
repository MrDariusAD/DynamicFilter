using System;
using FluentAssertions;
using Xunit;

namespace DynamicFilter.Licensing.Tests {
    public class LicensingTests {
        [Fact]
        public void CheckLicense_ValidKeyIsEntered_CheckLicenseShouldReturnTrue() {
            var key = "FDSLX-ETMTF-QOENV-DHKOF";

            Licencsing.CheckLicense(key).Should().BeTrue();
        }
    }
}
