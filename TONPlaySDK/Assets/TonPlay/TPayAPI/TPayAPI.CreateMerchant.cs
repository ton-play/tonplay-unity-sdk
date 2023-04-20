using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class TPayAPI {
        private string pathCreateMerchant = "/auth/v1/create";

        public IPromise<Merchant> CreateMerchant(CreateMerchantBody createMerchantBody) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + pathCreateMerchant,
                Body = createMerchantBody
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Post<Merchant>(requestOptions);
        }
    }
}
