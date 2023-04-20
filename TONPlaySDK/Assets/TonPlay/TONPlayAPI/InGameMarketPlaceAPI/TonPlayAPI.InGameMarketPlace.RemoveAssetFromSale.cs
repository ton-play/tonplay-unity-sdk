using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class TonPlayAPI {
        private string pathRemoveAssetFromSale = "/x/market/v1/sale";

        public IPromise<MarketConfirmationLinkResponse> RemoveAssetFromSale(RemoveAssetFromSaleBody removeAssetFromSaleBody) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + pathRemoveAssetFromSale,
                Headers = new Dictionary<string, string> {
                    { X_AUTH_TON_PLAY_KEY, XAuthTonplay }
                },
                Body = removeAssetFromSaleBody
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Delete<MarketConfirmationLinkResponse>(requestOptions);
        }
    }
}
