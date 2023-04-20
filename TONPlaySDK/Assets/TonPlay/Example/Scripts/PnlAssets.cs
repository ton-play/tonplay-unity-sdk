using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TONPlay;

namespace TONPlay.Example {
    public class PnlAssets : MonoBehaviour {
        [SerializeField]
        private List<PnlToken> pnlTokens;

        public void Show(List<Token> tokens) {
            for (int i = 0; i < tokens.Count; i++) {
                if (i == pnlTokens.Count)
                    break;

                pnlTokens[i].Show(tokens[i]);
            }
        }
    }
}