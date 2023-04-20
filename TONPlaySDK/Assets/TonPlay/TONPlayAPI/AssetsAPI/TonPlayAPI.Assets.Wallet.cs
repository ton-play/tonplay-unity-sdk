using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class TonPlayAPI {
        private string pathGetAssetsWallet = "/x/tondata/v1/assets/";

        public IPromise<PageableContent<Token>> GetAssetsWallet(string walletAddress, uint page = 0, uint size = 20, string sort = "name,asc", string gameKey = "") {
            RequestHelper requestOptions = null;

            var paramsList = new Dictionary<string, string> {
                    { "page", page.ToString() },
                    { "size", size.ToString() },
                    { "sort", sort }
                };

            if (!string.IsNullOrWhiteSpace(gameKey))
                paramsList.Add("gameKey", gameKey);

            requestOptions = new RequestHelper {
                Uri = SERVER + pathGetAssetsWallet + walletAddress,
                Params = paramsList,
                Headers = new Dictionary<string, string> {
                    { X_AUTH_TON_PLAY_KEY, XAuthTonplay }
                },
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Get<PageableContent<Token>>(requestOptions);
        }
    }
}
