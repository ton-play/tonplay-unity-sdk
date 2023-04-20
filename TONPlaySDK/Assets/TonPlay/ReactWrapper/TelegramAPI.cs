using System.Runtime.InteropServices;
using UnityEngine;

namespace ReactWrapper.TelegramAPI {
    public class TelegramAPI {
        //https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html
        [DllImport("__Internal")]
        static extern void OpenLinkTelegramAPI(string url);

        [DllImport("__Internal")]
        static extern void OpenTelegramLinkTelegramAPI(string url);

        [DllImport("__Internal")]
        static extern void OpenHapticFeedbackTelegramAPI(string style);

        public static void OpenLink(string url) {

#if !UNITY_EDITOR && UNITY_WEBGL
            OpenLinkTelegramAPI(url: url);
#else
            Application.OpenURL(url);
#endif
        }

        public static void OpenTelegramLink(string url) {

#if !UNITY_EDITOR && UNITY_WEBGL
            OpenTelegramLinkTelegramAPI(url: url);
#else
            Application.OpenURL(url);
#endif

        }

        /// <summary>
        /// HapticFeedback
        ///
        /// Style you can take from HapticFeedbackStyles
        /// </summary>
        /// <param name="style"></param>
        public static void HapticFeedback(string style) {
#if !UNITY_EDITOR && UNITY_WEBGL
            OpenHapticFeedbackTelegramAPI(style: style);
#endif
        }
    }
}