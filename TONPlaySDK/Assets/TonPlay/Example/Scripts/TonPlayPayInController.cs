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
        /// In this example, we display the QR to top up the tokens
        /// </summary>
        private void CreateMerchantAndPayIn() {

            if(!CheckAllRequiredData()) 
                return;

            TPayAPI tpayAPI = new TPayAPI();
            tpayAPI.XAuthTPay = _TPayData.PaymentKey;

            PayInBody payInBody = new PayInBody() {
                orderId = _TPayData.OrderId,
                amount = _TPayData.Amount
            };
                
            //Request Pay In link
            tpayAPI.PayIn(payInBody).Then(response => {
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