using System.Collections.Generic;
using Proyecto26;
using RSG;
using System.Text;

namespace TONPlay {
    public partial class TonPlayAPI {
        private string pathGetUsersByIdentifiers = "/x/auth/v1/user";

        public IPromise<User[]> GetUsersByIdentifiers(List<string> tonPlayUsersIds) {
            RequestHelper requestOptions = null;

            var paramsList = new Dictionary<string, string> {
                { "identifiers", string.Join(",",tonPlayUsersIds) }
            };

            requestOptions = new RequestHelper {
                Uri = SERVER + pathGetUsersByIdentifiers,
                Params = paramsList,
                Headers = new Dictionary<string, string> {
                    { X_AUTH_TON_PLAY_KEY, XAuthTonplay }
                },
            };

            AddDefaultRequestOptions(requestOptions);


            var promise = new Promise<User[]>();

            RestClient.Get(requestOptions).Then(response => {
                var users = JsonHelper.ArrayFromJson<User>(Encoding.UTF8.GetString(response.Data, 0, (response.Data.Length)));
                promise.Resolve(users);

            }).Catch(err => {
                promise.Reject(err);
            });

            return promise;
        }
    }
}
