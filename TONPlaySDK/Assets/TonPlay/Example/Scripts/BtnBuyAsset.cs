using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TONPlay.Example {
    public class BtnBuyAsset : MonoBehaviour {
        //public string AssetAddress {
        //    set;
        //    get;
        //}

        private Action _buyAction;

        public void SetBuyAction(Action buyAction) {
            _buyAction = buyAction;
        }

        public void Buy() {
            _buyAction.Invoke();
        }
    }
}
