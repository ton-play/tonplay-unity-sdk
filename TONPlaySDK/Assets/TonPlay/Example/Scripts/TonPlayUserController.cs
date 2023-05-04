using UnityEngine;
using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TONPlay.Example {
    public class TonPlayUserController : MonoBehaviour {
        //need user JWT 
        //need XAuthTonplay
        [SerializeField]
        private TonPlayData _tonPlayData;

        [Space]
        [SerializeField]
        private PnlUserInfo _pnlUserInfo;

        private string _userJWTString;

        void Start() {
            GetUserInfoByUserJWT();
        }

        private void GetUserInfoByUserJWT() {
            GetUserJWT();
            if (!CheckAllRequiredData())
                return;

            TonPlayAPI tonPlayAPI = new TonPlayAPI();
            tonPlayAPI.XAuthTonplay = _tonPlayData.APIKey;

            UserJWT userJWT = JsonUtility.FromJson<UserJWT>(_userJWTString);

            tonPlayAPI.GetUserByIdentifier(userJWT.sub).Then(response => {
                _pnlUserInfo.Show(response);
            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });
        }

        private void GetUserJWT() {
            string _queryToken = QueryParams.TOKEN;
            //your address can be like https://yourgame.com?token=yourTokenFromTONPlayOrYourTelegramBot
            string uri = Application.absoluteURL;
            Dictionary<string, string> query = ParamParse.GetBrowserParameters(uri);

            string token= query.ContainsKey(_queryToken) ? query[_queryToken] : _tonPlayData.UserJWT;
            _userJWTString = DecoderJWT.Decode(token);
        }

        private bool CheckAllRequiredData() {
            bool isValid = true;

            if (string.IsNullOrEmpty(_userJWTString)) {
                Debug.LogError("Please enter userJWT in TonPlayData or in url query");
                isValid = false;
            }

            if (string.IsNullOrEmpty(_tonPlayData.APIKey)) {
                Debug.LogError("Please enter your game's API Key in TonPlayData");
                isValid = false;
            }

            return isValid;
        }
    }
}