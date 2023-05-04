using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TONPlay;
using System;

namespace TONPlay.Example {
    public class PnlAssetsOnSale : MonoBehaviour {
        [SerializeField]
        private List<PnlTokenOnSale> _pnlTokens;

        public void Show(Seller[] tokensOnSale, Action<string> buyAction) {
            for (int i = 0; i < tokensOnSale.Length; i++) {
                if (i == _pnlTokens.Count)
                    break;

                _pnlTokens[i].Show(tokensOnSale[i], buyAction);

            }
        }

    }
}
