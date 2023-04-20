using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class TonPlayAPI {
        private string pathGetUserByIdentifier = "/x/auth/v1/user/";

        public IPromise<User> GetUserByIdentifier(string tonPlayUserId) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + pathGetUserByIdentifier + tonPlayUserId,
                Headers = new Dictionary<string, string> {
                    { X_AUTH_TON_PLAY_KEY, XAuthTonplay }
                },
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Get<User>(requestOptions);
        }
    }
}
