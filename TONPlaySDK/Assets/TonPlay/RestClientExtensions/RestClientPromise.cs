using RSG;

namespace Proyecto26 {
    public static partial class RestClient {
        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Delete<T>(RequestHelper options) {
            var promise = new Promise<T>();
            Delete<T>(options, promise.Promisify);
            return promise;
        }
    }
}