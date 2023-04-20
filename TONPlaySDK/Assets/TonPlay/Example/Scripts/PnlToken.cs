using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TONPlay;
using UnityEngine.Networking;
using Proyecto26;
using RSG;

namespace TONPlay.Example {
    public class PnlToken : MonoBehaviour {
        [SerializeField]
        private Image _tokenImg;
        [SerializeField]
        private Text _txtRarity;
        [SerializeField]
        private Text _txtTokenName;
        [SerializeField]
        private Text _txtTokenCollection;
        [SerializeField]
        private Text _txtItemOnSale;

        public void Show(Token token) {
            gameObject.SetActive(true);

            _txtRarity.text = token.rarity;
            _txtTokenName.text = token.name;
            _txtTokenCollection.text = token.properties.collection.name;
            _txtItemOnSale.text = $"{token.market.availableForBuy}/{token.supply}";

            RestClient.Get(new RequestHelper {
                Uri = token.image,
                DownloadHandler = new DownloadHandlerTexture(true)
            }).Then(res => {
                Texture2D tex = (Texture2D)((DownloadHandlerTexture)res.Request.downloadHandler).texture;

                _tokenImg.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            }).Catch(err => {
                Debug.LogError("Error: " + err.Message);
            });
        }
    }
}