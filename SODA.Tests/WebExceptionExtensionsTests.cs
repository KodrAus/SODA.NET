using System;
using System.Net;
using NUnit.Framework;
using SODA.Utilities;

namespace SODA.Tests
{
    [TestFixture]
    public class WebExceptionExtensionsTests
    {

        [Test]
        [Category("WebExceptionExtensions")]
        public void UnwrapResponseMessage_Returns_Empty_String_For_Null_Input()
        {
            WebException nullWebException = null;

            string message = nullWebException.UnwrapResponse();

            StringAssert.AreEqualIgnoringCase(String.Empty, message);
        }

        [Test]
        [Category("WebExceptionExtensions")]
        public void UnwrapResponseMessage_Returns_WebException_Message_For_WebException_With_Null_Response()
        {
            WebException webException = new WebException("this is a message");

            Assert.IsNull(webException.Response);

            string message = webException.UnwrapResponse();

            StringAssert.AreEqualIgnoringCase(webException.Message, message);
        }

        [Test]
        [Category("WebExceptionExtensions")]
        public void UnwrapResponseMessage_Returns_WebException_Response()
        {
            WebException webException = null;

            //purposely cause a WebException to get a populated Response property
            try
            {
                new WebClient().DownloadString("http://www.example.com/this/will/fail");
            }
            catch (WebException ex)
            {
                webException = ex;
            }
            //validate that the exception has the properties we are interested in
            Assert.NotNull(webException);
            Assert.NotNull(webException.Response);
            Assert.False(String.IsNullOrEmpty(webException.Message));

            string message = webException.UnwrapResponse();

            //we should have gotten a message by unwrapping
            Assert.False(String.IsNullOrEmpty(message));
            //but it should not be the same as the exception's message property -> it came from the Response
            StringAssert.AreNotEqualIgnoringCase(webException.Message, message);
        }
    }
}