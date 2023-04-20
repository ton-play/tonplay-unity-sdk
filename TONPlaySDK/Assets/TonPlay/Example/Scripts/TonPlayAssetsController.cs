using UnityEngine;
using Proyecto26;

namespace TONPlay.Example {
    public class TonPlayAssetsController : MonoBehaviour {
        //need XAuthTonplay (TON Play API Key)
        [SerializeField]
        private TonPlayData _tonPlayData;
        [SerializeField]
        private PnlAssets _pnlAssets;

        void Start() {
            GetAssetsGame();
        }

        private void GetAssetsGame() {
            if (!CheckAllRequiredData())
                return;

            TonPlayAPI tonPlayAPI = new TonPlayAPI();
            tonPlayAPI.XAuthTonplay = _tonPlayData.XAuthTonplay;

            tonPlayAPI.GetAssetsGame().Then(response => {
                _pnlAssets.Show(response.content);
            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });
        }

        private bool CheckAllRequiredData() {
            bool isValid = true;

            if (string.IsNullOrEmpty(_tonPlayData.XAuthTonplay)) {
                Debug.LogError("Please enter your game's API Key in TonPlayData");
                isValid = false;
            }

            return isValid;
        }
    }
}