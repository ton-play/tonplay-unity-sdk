using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Proyecto26;

namespace TONPlay.Example {
    public class QRImgLoader : MonoBehaviour {

        [SerializeField]
        private Image _image;

        private const string GOOGLE_QR_LINK_PREFIX = "http://chart.apis.google.com/chart?cht=qr&chs=300x300&chl=";

        public void Load(string url) {
            RestClient.Get(new RequestHelper {
                Uri = GOOGLE_QR_LINK_PREFIX  + url,
                DownloadHandler = new DownloadHandlerTexture(true)
            }).Then(res => {
                Texture2D tex = (Texture2D)((DownloadHandlerTexture)res.Request.downloadHandler).texture;

                _image.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            }).Catch(err => {
                Debug.LogError("Error: " + err.Message);
            });
        }
    }
}