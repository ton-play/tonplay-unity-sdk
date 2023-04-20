using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TONPlay;
using System;

namespace TONPlay.Example {
    public class PnlAssetsOnSale : MonoBehaviour {
        [SerializeField]
        private List<PnlTokenOnSale> _pnlTokens;

        public void Show(Seller[] tokensOnSale, Dictionary<string, Token> gameTokens, Action<string> buyAction) {
            for (int i = 0; i < tokensOnSale.Length; i++) {
                if (i == _pnlTokens.Count)
                    break;

                if (!gameTokens.ContainsKey(tokensOnSale[i].address))
                    continue;

                _pnlTokens[i].Show(gameTokens[tokensOnSale[i].address], tokensOnSale[i], buyAction);

            }
        }

    }
}
