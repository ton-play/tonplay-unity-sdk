using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class TonPlayAPI {
        private string pathPutOnSale = "/x/market/v1/sale";

        public IPromise<MarketConfirmationLinkResponse> PutOnSale(PutOnSaleBody putOnSaleBody) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + pathPutOnSale,
                Headers = new Dictionary<string, string> {
                    { X_AUTH_TON_PLAY_KEY, XAuthTonplay }
                },
                Body = putOnSaleBody
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Put<MarketConfirmationLinkResponse>(requestOptions);
        }
    }
}
