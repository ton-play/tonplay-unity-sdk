using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class TonPlayAPI {
        private string pathGetAssetsGame = "/x/tondata/v1/assets/game";

        public IPromise<PageableContent<Token>> GetAssetsGame(uint page = 0, uint size = 20, string sort = "name,asc") {
            RequestHelper requestOptions = null;

            var paramsList = new Dictionary<string, string> {
                    { "page", page.ToString() },
                    { "size", size.ToString() },
                    { "sort", sort }
                };

            requestOptions = new RequestHelper {
                Uri = SERVER + pathGetAssetsGame,
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
