using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Proyecto26;
using System;

namespace TONPlay.Example {
    public class PnlTokenOnSale : MonoBehaviour {
        [SerializeField]
        private Image _tokenImg;
        [SerializeField]
        private Text _txtRarity;
        [SerializeField]
        private Text _txtTokenName;
        [SerializeField]
        private Text _txtTokenCollection;
        [SerializeField]
        private Text _txtPrice;
        [SerializeField]
        private BtnBuyAsset _btnBuyAsset;

        public void Show(Seller seller, Action<string> buyAction) {
            gameObject.SetActive(true);

            _txtTokenName.text = seller.address ?? "";
            _txtTokenCollection.text = seller.name ?? "";
            _txtPrice.text = $"{seller.price.ToString("F")} TON";

            _btnBuyAsset.SetBuyAction(() => buyAction?.Invoke(seller.address));

            RestClient.Get(new RequestHelper {
                Uri = seller.image,
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