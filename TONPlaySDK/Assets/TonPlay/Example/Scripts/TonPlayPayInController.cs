using UnityEngine;
using Proyecto26;


namespace TONPlay.Example {
    public class TonPlayPayInController : MonoBehaviour {

        [SerializeField]
        private TPayData _TPayData;

        [Space]
        [Header("UI")]
        [SerializeField]
        private QRImgLoader _tonhubQRImgLoader;
        [SerializeField]
        private QRImgLoader _tonkeeperQRImgLoader;

        void Start() {
            CreateMerchantAndPayIn();
        }

        /// <summary>
        /// In this example, we create a merchant every time and display the QR to top up the tokens
        /// In reality, you only need to do this once.
        /// </summary>
        private void CreateMerchantAndPayIn() {

            if(!CheckAllRequiredData()) 
                return;
            

            TPayAPI tpayAPI = new TPayAPI();

            CreateMerchantBody createMerchantBody = new CreateMerchantBody() {
                name = _TPayData.Name,
                address = _TPayData.Address,
                webhook = _TPayData.Webhook
            };

            //1. Create Merchant  (In reality, you only need to do this once for game)
            tpayAPI.CreateMerchant(createMerchantBody).Then(response => {
                tpayAPI.XAuthTPay = response.paymentKey;
                Debug.Log($"paymentKey {response.paymentKey}");

                PayInBody payInBody = new PayInBody() {
                    orderId = _TPayData.OrderId,
                    amount = _TPayData.Amount
                };
                
            //2. request Pay In link
                return tpayAPI.PayIn(payInBody);

            }).Then(response => {
                Debug.Log($"tonhub: {response.tonhub}");
                _tonhubQRImgLoader.Load(response.tonhub);
                Debug.Log($"tonkeeper: {response.tonkeeper}");
                _tonkeeperQRImgLoader.Load(response.tonkeeper);
            }).Catch(error => {
                Debug.LogError(error.Message);
            });


        }

        private bool CheckAllRequiredData() {
            bool isValid = true;

            if (string.IsNullOrEmpty(_TPayData.Name)) {
                Debug.LogError("Please enter your Name in TPayData");
                isValid = false;
            }

            if (string.IsNullOrEmpty(_TPayData.Address)) {
                Debug.LogError("Please enter your Address in TPayData");
                isValid = false;
            }

            if (string.IsNullOrEmpty(_TPayData.Webhook)) {
                Debug.LogError("Please enter your Webhook in TPayData");
                isValid = false;
            }

            if (string.IsNullOrEmpty(_TPayData.OrderId)) {
                Debug.LogError("Please enter your OrderId in TPayData");
                isValid = false;
            }

            if (_TPayData.Amount <= 0) {
                Debug.LogError("Please check your Amount in TPayData. It should be more then 0");
                isValid = false;
            }

            return isValid;
        }
    }
}