using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class TPayAPI {
        private string pathPayIn = "/pay/in/v1/new";

        public IPromise<PayInLinks> PayIn(PayInBody payInBody) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + pathPayIn,
                Headers = new Dictionary<string, string> {
                    { X_AUTH_TPAY_KEY, XAuthTPay }
                },
                Body = payInBody
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Post<PayInLinks>(requestOptions);
        }
    }
}
