using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class TonPlayAPI {
        private string pathBuyAsset = "/x/market/v1/sale";

        public IPromise<MarketConfirmationLinkResponse> BuyAsset(BuyAssetBody buyAssetBody) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + pathBuyAsset,
                Headers = new Dictionary<string, string> {
                    { X_AUTH_TON_PLAY_KEY, XAuthTonplay }
                },
                Body = buyAssetBody
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Post<MarketConfirmationLinkResponse>(requestOptions);
        }
    }
}
