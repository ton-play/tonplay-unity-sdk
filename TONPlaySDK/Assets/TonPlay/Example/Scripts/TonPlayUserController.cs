using UnityEngine;
using Proyecto26;


namespace TONPlay.Example {
    public class TonPlayUserController : MonoBehaviour {
        //need user JWT 
        //need XAuthTonplay
        [SerializeField]
        private TonPlayData _tonPlayData;

        [Space]
        [SerializeField]
        private PnlUserInfo _pnlUserInfo;

        void Start() {
            GetUserInfoByUserJWT();
        }

        private void GetUserInfoByUserJWT() {
            if (!CheckAllRequiredData())
                return;

            TonPlayAPI tonPlayAPI = new TonPlayAPI();
            tonPlayAPI.XAuthTonplay = _tonPlayData.XAuthTonplay;

            string userJWTString = DecoderJWT.Decode(_tonPlayData.UserJWT);
            Debug.Log($"user jwt: {userJWTString}");

            UserJWT userJWT = JsonUtility.FromJson<UserJWT>(userJWTString);

            tonPlayAPI.GetUserByIdentifier(userJWT.sub).Then(response => {
                _pnlUserInfo.Show(response);
            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });
        }

        private bool CheckAllRequiredData() {
            bool isValid = true;

            if (string.IsNullOrEmpty(_tonPlayData.UserJWT)) {
                Debug.LogError("Please enter userJWT in TonPlayData");
                isValid = false;
            }

            if (string.IsNullOrEmpty(_tonPlayData.XAuthTonplay)) {
                Debug.LogError("Please enter your game's API Key in TonPlayData");
                isValid = false;
            }

            return isValid;
        }
    }
}