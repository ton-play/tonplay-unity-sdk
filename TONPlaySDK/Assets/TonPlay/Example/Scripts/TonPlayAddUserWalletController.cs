using UnityEngine;
using Proyecto26;


namespace TONPlay.Example {
    public class TonPlayAddUserWalletController : MonoBehaviour {
        //need user JWT
        [SerializeField]
        private TonPlayData _tonPlayData;

        [Space]
        [SerializeField]
        private QRImgLoader _qrImgLoader;

        void Start() {
            GetUserInfoByUserJWT();
        }

        private void GetUserInfoByUserJWT() {
            if (!CheckAllRequiredData())
                return;

            string userJWTString = DecoderJWT.Decode(_tonPlayData.UserJWT);
            Debug.Log($"user jwt: {userJWTString}");

            UserJWT userJWT = JsonUtility.FromJson<UserJWT>(userJWTString);

            _qrImgLoader.Load(userJWT.sub);
        }

        private bool CheckAllRequiredData() {
            bool isValid = true;

            if (string.IsNullOrEmpty(_tonPlayData.UserJWT)) {
                Debug.LogError("Please enter userJWT in userJWT");
                isValid = false;
            }

            return isValid;
        }
    }
}