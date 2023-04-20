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


        Dictionary<string, Token> _gameTokens;
        Dictionary<string, Seller> _sellers;

        void Start() {
            GetAssetsOnMarket();
        }

        public void GetAssetsOnMarket() {
            if (!CheckAllRequiredData())
                return;

            _gameTokens = new Dictionary<string, Token>();
            _sellers = new Dictionary<string, Seller>();

            TonPlayAPI tonPlayAPI = new TonPlayAPI();
            tonPlayAPI.XAuthTonplay = _tonPlayData.XAuthTonplay;

            tonPlayAPI.GetAssetsGame().Then(response => {

                foreach(var token in response.content) {
                    _gameTokens[token.address] = token;
                }

                return tonPlayAPI.GetAssetsOnSale(_tonPlayData.GameKey);
            }).Then(response => {
                foreach(var seller in response) {
                    _sellers[seller.address] = seller;
                }

                _pnlAssetsOnSale.Show(response, _gameTokens, (assetAddress) => BuyAsset(assetAddress));
            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });
        }

        public void BuyAsset(string assetAddress) {
            if (!_sellers.ContainsKey(assetAddress))
                return;

            TonPlayAPI tonPlayAPI = new TonPlayAPI();
            tonPlayAPI.XAuthTonplay = _tonPlayData.XAuthTonplay;

            string userJWTString = DecoderJWT.Decode(_tonPlayData.UserJWT);
            Debug.Log($"user jwt: {userJWTString}");

            UserJWT userJWT = JsonUtility.FromJson<UserJWT>(userJWTString);

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


        private bool CheckAllRequiredData() {
            bool isValid = true;

            if (string.IsNullOrEmpty(_tonPlayData.XAuthTonplay)) {
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