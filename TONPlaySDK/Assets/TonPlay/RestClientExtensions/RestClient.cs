using System;
using UnityEngine.Networking;

namespace Proyecto26 {
    public static partial class RestClient {
        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Delete<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback) {
            options.Method = UnityWebRequest.kHttpVerbDELETE;
            Request(options, callback);
        }
    }
}
