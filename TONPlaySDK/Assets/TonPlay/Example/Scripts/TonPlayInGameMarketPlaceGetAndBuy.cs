using UnityEngine;
using Proyecto26;
using System.Collections.Generic;

namespace TONPlay.Example {
    public class TonPlayInGameMarketPlaceGetAndBuy : MonoBehaviour {

        //need XAuthTonplay (TON Play API Key)
        //need user JWT. Asset will be purchased to address from user JWT
        //need Game Key
        [SerializeField]
        private TonPlayData _tonPlayData;
        [SerializeField]
        private PnlAssetsOnSale _pnlAssetsOnSale;
        [SerializeField]
        private QRImgLoader _qrImgLoader;

        Dictionary<string, Seller> _sellers;

        private string _userJWTString;

        void Start() {
            GetAssetsOnMarket();
        }

        public void GetAssetsOnMarket() {
            GetUserJWT();
            if (!CheckAllRequiredData())
                return;

            _sellers = new Dictionary<string, Seller>();

            TonPlayAPI tonPlayAPI = new TonPlayAPI();
            tonPlayAPI.XAuthTonplay = _tonPlayData.APIKey;

            tonPlayAPI.GetAssetsOnSale().Then(response => {
                foreach(var seller in response) {
                    _sellers[seller.seller.address] = seller;
                }

                _pnlAssetsOnSale.Show(response, (assetAddress) => BuyAsset(assetAddress));
            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });
        }

        public void BuyAsset(string assetAddress) {
            if (!_sellers.ContainsKey(assetAddress))
                return;

            TonPlayAPI tonPlayAPI = new TonPlayAPI();
            tonPlayAPI.XAuthTonplay = _tonPlayData.APIKey;

            Debug.Log($"user jwt: {_userJWTString}");

            UserJWT userJWT = JsonUtility.FromJson<UserJWT>(_userJWTString);

            if(string.IsNullOrWhiteSpace(userJWT.wallet)) {
                Debug.LogError("This user has not yet connected a wallet to TON Play. Please do it.");

                return;
            }

            BuyAssetBody buyAssetBody = new BuyAssetBody() {
                address = _sellers[assetAddress].address,
                amount = 1, //for example
                type = _sellers[assetAddress].type,
                buyerAddress = userJWT.wallet,
                sellerAddress = _sellers[assetAddress].seller.address
            };

            tonPlayAPI.BuyAsset(buyAssetBody).Then(response => {

                _qrImgLoader.gameObject.SetActive(true);
                _qrImgLoader.Load(response.url);

            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });

            GetAssetsOnMarket();
        }

        private void GetUserJWT() {
            string _queryToken = QueryParams.TOKEN;
            //your address can be like https://yourgame.com?token=yourTokenFromTONPlayOrYourTelegramBot
            string uri = Application.absoluteURL;
            Dictionary<string, string> query = ParamParse.GetBrowserParameters(uri);

            string token = query.ContainsKey(_queryToken) ? query[_queryToken] : _tonPlayData.UserJWT;
            _userJWTString = DecoderJWT.Decode(token);
        }

        private bool CheckAllRequiredData() {
            bool isValid = true;

            if (string.IsNullOrEmpty(_tonPlayData.APIKey)) {
                Debug.LogError("Please enter your game's API Key in TonPlayData");
                isValid = false;
            }

            if (string.IsNullOrEmpty(_tonPlayData.GameKey)) {
                Debug.LogError("Please enter your game Key  in TonPlayData");
                isValid = false;
            }

            if (string.IsNullOrEmpty(_tonPlayData.UserJWT)) {
                Debug.LogError("Please enter your userJWT  in TonPlayData");
                isValid = false;
            }

        return isValid;
        }
    }
}