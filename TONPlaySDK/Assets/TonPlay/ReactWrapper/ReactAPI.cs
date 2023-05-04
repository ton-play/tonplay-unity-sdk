using System.Runtime.InteropServices;
using UnityEngine;

namespace ReactWrapper.ReactAPI {
    public class ReactAPI {
        //https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html
        [DllImport("__Internal")]
        static extern void WindowsOpenUrl(string url, string name);
        [DllImport("__Internal")]
        static extern void WindowHref(string url);
        [DllImport("__Internal")]
        static extern void Share(string url, string title, string text);

        /// <summary>
        /// Open url
        ///
        /// reactWindowsOpenMethods you can take from ReactWindowsOpenMethods class
        /// </summary>
        /// <param name="url"></param>
        /// <param name="reactWindowsOpenMethods"></param>
        public static void OpenUrl(string url, string reactWindowsOpenMethods = ReactWindowsOpenMethods.BLANK) {
#if !UNITY_EDITOR && UNITY_WEBGL
            WindowsOpenUrl(url: url, name: reactWindowsOpenMethods);
#else
            Application.OpenURL(url);
#endif
        }

        public static void WindowHrefOpen(string url) {
#if !UNITY_EDITOR && UNITY_WEBGL
            WindowHref(url: url);
#else
            Application.OpenURL(url);
#endif
        }

        public static void ShareData(string url, string title, string text) {
#if !UNITY_EDITOR && UNITY_WEBGL
            Share(url: url, title: title, text: text);
#else
            Debug.Log($"You try share url: {url}\ntitle: {title}\ntext: {text}");
#endif
        }
    }
}