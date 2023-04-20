mergeInto(LibraryManager.library, {
  WindowsOpenUrl: function (url, name) {
    dispatchReactUnityEvent("WindowsOpenUrl", UTF8ToString(url), UTF8ToString(name));
  },
  OpenLinkTelegramAPI: function (url) {
    dispatchReactUnityEvent("OpenLinkTelegramAPI", UTF8ToString(url));
  },  
  OpenTelegramLinkTelegramAPI: function (url) {
    dispatchReactUnityEvent("OpenTelegramLinkTelegramAPI", UTF8ToString(url));
  },  
  OpenHapticFeedbackTelegramAPI: function (style) {
    dispatchReactUnityEvent("OpenHapticFeedbackTelegramAPI", UTF8ToString(style));
  },
    ShowButton: function (url, title, fromTelegram) {
    dispatchReactUnityEvent("ShowButton", UTF8ToString(url), UTF8ToString(title), fromTelegram);
  },
    HideButton: function () {
    dispatchReactUnityEvent("HideButton");
  }
});
