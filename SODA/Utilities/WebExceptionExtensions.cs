using System;
using System.IO;
using System.Net;

namespace SODA.Utilities
{
    /// <summary>
    /// Convenience methods for dealing with <see cref="System.Net.WebException">WebExceptions</see>.
    /// </summary>
    public static class WebExceptionExtensions
    {
        /// <summary>
        /// Attempts to read the inner Response string of this <see cref="System.Net.WebException"/>.
        /// </summary>
        /// <returns>
        /// The response string from <paramref name="webException"/> if available, 
        /// otherwise the <see cref="System.Net.WebException"><paramref name="webException"/></see>.Message property.
        /// </returns>
        public static string UnwrapResponse(this WebException webException)
        {
            string message = String.Empty;

            if (webException != null)
            {
                //set a default just in case there isn't a response property
                message = webException.Message;

                if (webException.Response != null)
                {
                    using (var streamReader = new StreamReader(webException.Response.GetResponseStream()))
                    {
                        message = streamReader.ReadToEnd();
                    }
                }
            }

            return message;
        }
    }
}
