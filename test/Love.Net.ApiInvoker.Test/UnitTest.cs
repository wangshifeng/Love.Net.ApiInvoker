using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Love.Net.ApiInvoker.Test {
    public class UnitTest {
        public UnitTest() {
        }

        [Fact]
        public void Uri_Scheme_Test() {
            var url = "http://doctor.test.didixl.com/api/help/ui";

            Assert.True(IsHttpPath(url));

            url = "api/help/ui";

            Assert.True(IsHttpPath(url));
        }

        private static bool IsHttpPath(string url) {
            try {
                Uri uri;
                if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri)
                   &&
                  (uri.Scheme == "http" || uri.Scheme == "https")) {
                    return true;
                }

                return false;
            }
            catch {
                return false;
            }
        }
    }
}
