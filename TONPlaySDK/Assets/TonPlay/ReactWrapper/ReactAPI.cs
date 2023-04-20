using System.Runtime.InteropServices;
using UnityEngine;

namespace ReactWrapper.ReactAPI {
    public class ReactAPI {
        //https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html
        [DllImport("__Internal")]
        static extern void WindowsOpenUrl(string url, string name);

        [DllImport("__Internal")]
        static extern void ShowButton(string url, string title, bool fromTelegram);

        [DllImport("__Internal")]
        static extern void HideButton();

        /// <summary>
        /// Open url
        ///
        /// reactWindowsOpenMethods you can take  from ReactWindowsOpenMethods class
        /// </summary>
        /// <param name="url"></param>
        /// <param name="reactWindowsOpenMethods"></param>
        public static void OpenUrl(string url, string reactWindowsOpenMethods) {
#if !UNITY_EDITOR && UNITY_WEBGL
            WindowsOpenUrl(url: url, name: reactWindowsOpenMethods);
#else
            Application.OpenURL(url);
#endif
        }

        public static void ShowBtn(string url, string title = "Pay", bool fromTelegram = false) {
            ShowButton(url: url, title: title, fromTelegram: fromTelegram);
        }

        public static void HideBtn() {
            HideButton();
        }
    }
}