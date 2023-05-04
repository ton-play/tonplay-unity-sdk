using UnityEngine;
using Proyecto26;
using System.Collections.Generic;


namespace TONPlay.Example {
    public class TonPlayAddUserWalletController : MonoBehaviour {
        //need user JWT
        [SerializeField]
        private TonPlayData _tonPlayData;

        [Space]
        [SerializeField]
        private QRImgLoader _qrImgLoader;

        private string _userJWTString;

        void Start() {
            GetUserInfoByUserJWT();
        }

        private void GetUserInfoByUserJWT() {
            GetUserJWT();
            if (!CheckAllRequiredData())
                return;

            Debug.Log($"user jwt: {_userJWTString}");

            UserJWT userJWT = JsonUtility.FromJson<UserJWT>(_userJWTString);

            _qrImgLoader.Load(userJWT.sub);
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

            if (string.IsNullOrEmpty(_tonPlayData.UserJWT)) {
                Debug.LogError("Please enter userJWT in userJWT");
                isValid = false;
            }

            return isValid;
        }
    }
}