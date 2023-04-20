using Proyecto26;


namespace TONPlay {
    public class ServerConnectionErrorSignal {}
    public partial class BaseAPI {
        private const int TIMEOUT = 10;
        private const int RETRIES = 5;
        private const int RETRY_SECONDS_DELAY = 2;
        public static void AddDefaultRequestOptions(RequestHelper requestOptions) {
            requestOptions.Timeout = TIMEOUT;
            requestOptions.Retries = RETRIES;
            requestOptions.RetrySecondsDelay = RETRY_SECONDS_DELAY;
            //requestOptions.EnableDebug = true; 
        }
    }
}