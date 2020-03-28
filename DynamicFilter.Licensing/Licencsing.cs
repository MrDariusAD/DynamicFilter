using System;
using SKM.V3;
using SKM.V3.Methods;
using SKM.V3.Models;

namespace DynamicFilter.Licensing {
    public static class Licencsing {
        public static string LicenseKey { get; set; } = "";
        public static bool IsLicensed { get; set; } = false;
        public static bool CheckLicense(string key) {
            var RSAPubKey = "<RSAKeyValue><Modulus>p77M20U58E8p3meGluw4tq/iqHOE40tTzzWbJdZP8koN9/w0AXWR1oq7Lrr2Y6x3AJEMO6Z84vwU84PBNI4So+maJ31omnSV99uUHa5Gcal6HtRD16/DMJbEJY5SDmARpEvkccSIlH5cqX6E0OpI0nEQp/T5rfHaOXoUpzgKJKuxhmTZ5pMHb+JFGvbNTtuGu6ESGVyR2MvJa2IblWrLIBg1rL2TlG5gs4WayOAJwGUcTf+mNsbZemy8qOE2vNsmcw0LGMNTT/FFMDpoQK4rTx2PocCScds0FCj1GjGCXAywzoBILqy5Jz63kFwBAMi9T+nQKuYKdVD+JRgK/F29CQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            var auth = "WyIxNzIwNyIsIklJVTFxZHpxcmZ0bTVJM2F3YkFpRUpVN1J4SHRkMTlreStuSjNlNWYiXQ==";
            LicenseKey = key;
            var result = Key.Activate(token: auth, parameters: new ActivateModel() {
                Key = key,
                ProductId = 5995,
                Sign = true
            });

            return result != null && result.Result != ResultType.Error && result.LicenseKey.HasValidSignature(RSAPubKey).IsValid();
        }
    }
}
