using System.Collections.Generic;
using Proyecto26;
using RSG;
using System.Text;

namespace TONPlay {
    public partial class TonPlayAPI {
        private string pathGetAssetsOnSale = "/x/market/v1/game/";

        public IPromise<Seller[]> GetAssetsOnSale(string gameKey) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + pathGetAssetsOnSale + gameKey,
                Headers = new Dictionary<string, string> {
                    { X_AUTH_TON_PLAY_KEY, XAuthTonplay }
                }
            };

            AddDefaultRequestOptions(requestOptions);

            var promise = new Promise<Seller[]>();

            RestClient.Get(requestOptions).Then(response => {
                var seller = JsonHelper.ArrayFromJson<Seller>(Encoding.UTF8.GetString(response.Data, 0, (response.Data.Length)));
                promise.Resolve(seller);

            }).Catch(err => {
                promise.Reject(err);
            });

            return promise;
        }
    }
}
