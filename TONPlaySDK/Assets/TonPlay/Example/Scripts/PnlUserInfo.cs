using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.Networking;

namespace TONPlay.Example {
    public class PnlUserInfo : MonoBehaviour {

        [SerializeField]
        private Image _avatar;
        [SerializeField]
        private Text _userName;
        [SerializeField]
        private Text _balance;
        [SerializeField]
        private Text _walletAddress;

        public void Show(User user) {
            _userName.text = user.username;
            _balance.text = $"{user.wallet.balance.ToString("F")} TON";
            _walletAddress.text = user.wallet.address;

            RestClient.Get(new RequestHelper {
                Uri = user.avatar,
                DownloadHandler = new DownloadHandlerTexture(true)
            }).Then(res => {
                Texture2D tex = (Texture2D)((DownloadHandlerTexture)res.Request.downloadHandler).texture;

                _avatar.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            }).Catch(err => {
                Debug.LogError("Error: " + err.Message);
            });
        }
    }
}