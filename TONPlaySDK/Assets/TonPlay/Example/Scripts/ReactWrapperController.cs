using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReactWrapper.ReactAPI;
using ReactWrapper.TelegramAPI;
using UnityEngine.UI;

public class ReactWrapperController : MonoBehaviour {
    [SerializeField]
    private Text _txtUrl;
    [SerializeField]
    private Text _txtTitle;
    [SerializeField]
    private Text _txtText;

    [Space]
    [SerializeField]
    private string _url = "https://tonplay.io/games";
    [SerializeField]
    private string _title = "TON Play";
    [TextArea]
    [SerializeField]
    private string _text = "TON Play is a toolkit that allows game developers to leverage the power of Telegram, the fastest-growing social platform with 700+ million users, and TON, its native blockchain.";

    private void Start() {
        _txtUrl.text = _url;
        _txtTitle.text = _title;
        _txtText.text = _text;
    }

    public void WindowOpen() {
        ReactAPI.OpenUrl(_url, ReactWindowsOpenMethods.SELF);
    }

    public void WindowHref() {
        ReactAPI.WindowHrefOpen(_url);
    }

    public void Share() {
        ReactAPI.ShareData(_url, _text, _text);
    }

    public void OpenLinkTelegramAPI() {
        TelegramAPI.OpenLink(_url);
    }

    public void OpenLinkInTelegramTelegramAPI() {
        TelegramAPI.OpenTelegramLink(_url);
    }

    public void HapticTelegramAPI() {
        TelegramAPI.HapticFeedback(HapticFeedbackStyles.Medium);
    }
}
