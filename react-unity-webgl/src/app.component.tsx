import { useCallback, useEffect, useRef, useState } from "react";
import { Unity, useUnityContext } from "react-unity-webgl";
import styles from "./app.module.css";
import { RWebShare, RWebShareProps } from "react-web-share";

const appName = "Game"; //enter your app file name from public/unitybuild folder

const App = () => {
  const {
    unityProvider,
    isLoaded,
    loadingProgression,
    addEventListener,
    removeEventListener,
  } = useUnityContext({
    loaderUrl: "/unitybuild/" + appName + ".loader.js",
    dataUrl: "/unitybuild/" + appName + ".data",
    frameworkUrl: "/unitybuild/" + appName + ".framework.js",
    codeUrl: "/unitybuild/" + appName + ".wasm",
    webglContextAttributes: {
      preserveDrawingBuffer: true,
    },
  });

  const [shareData, setShareData] = useState({
    url: "https://google.com",
    title: "Game",
    text: "",
  });

  //Windows open
  const handleWindowsOpenUrl = useCallback((url: string, name: string) => {
    console.log("Windows Open: " + url);
    setTimeout(() => {
      window.open(url, name);
    });
  }, []);

  useEffect(() => {
    addEventListener("WindowsOpenUrl", handleWindowsOpenUrl);
    return () => {
      removeEventListener("WindowsOpenUrl", handleWindowsOpenUrl);
    };
  }, [handleWindowsOpenUrl, addEventListener, removeEventListener]);

  //Windows href
  const handleWindowHref = useCallback((url: string) => {
    console.log("href: " + url);
    setTimeout(() => {
      window.location.href = url;
    });
  }, []);

  useEffect(() => {
    addEventListener("WindowHref", handleWindowHref);
    return () => {
      removeEventListener("WindowHref", handleWindowHref);
    };
  }, [handleWindowHref, addEventListener, removeEventListener]);

  //Share link
  const handleShare = useCallback(
    (url: string, title: string, text: string) => {
      setShareData({
        url: url,
        title: title,
        text: text,
      });

      if (buttonRef.current) {
        buttonRef.current.click();
      }
    },
    []
  );

  useEffect(() => {
    addEventListener("Share", handleShare);
    return () => {
      removeEventListener("Share", handleShare);
    };
  }, [handleShare, addEventListener, removeEventListener]);

  //Telegram API
  //Telegram API Open Link
  const handleOpenLink = useCallback((url: string) => {
    console.log("telegram api open link: " + url);
    Telegram.WebApp.openLink(url);
  }, []);

  useEffect(() => {
    addEventListener("OpenLinkTelegramAPI", handleOpenLink);
    return () => {
      removeEventListener("OpenLinkTelegramAPI", handleOpenLink);
    };
  }, [handleOpenLink, addEventListener, removeEventListener]);

  //Telegram API Open Link in Telegram
  const handleOpenTelegramLink = useCallback((url: string) => {
    console.log("telegram api open telegram link: " + url);
    Telegram.WebApp.openTelegramLink(url);
  }, []);

  useEffect(() => {
    addEventListener("OpenTelegramLinkTelegramAPI", handleOpenTelegramLink);
    return () => {
      removeEventListener(
        "OpenTelegramLinkTelegramAPI",
        handleOpenTelegramLink
      );
    };
  }, [handleOpenTelegramLink, addEventListener, removeEventListener]);

  //Telegram API Haptic
  const handleHapticFeedback = useCallback(
    (style: "light" | "medium" | "heavy" | "rigid" | "soft") => {
      Telegram.WebApp.HapticFeedback.impactOccurred(style);
    },
    []
  );

  useEffect(() => {
    addEventListener("OpenHapticFeedbackTelegramAPI", handleHapticFeedback);
    return () => {
      removeEventListener(
        "OpenHapticFeedbackTelegramAPI",
        handleHapticFeedback
      );
    };
  }, [handleHapticFeedback, addEventListener, removeEventListener]);

  useEffect(() => {
    Telegram.WebApp.ready();
    console.log("WebApp.version: " + Telegram.WebApp.version);
  });

  const buttonRef = useRef<HTMLButtonElement>(null);

  return (
    <div className={styles.container}>
      <div className={styles.unityWrapper}>
        {isLoaded === false && (
          <div className={styles.loaderContainer}>
            <div className={styles.loaderWrapper}>
              {/* <img className="img" src="/images/logo.png"></img> */}
              {/* <img className="img" src="/images/animatedLogo.gif"></img> */}
              <h1 className={styles.text}>
                Loading<span>.</span>
                <span>.</span>
                <span>.</span>
              </h1>
              <div className={styles.loadingBar}>
                <div className={styles.loadingBarFill}>
                  <div className={styles.loadingbarfillBg}>
                    <img
                      src="/images/loader-image.png"
                      className={styles.loadingbarimg}
                      style={{ width: loadingProgression * 300 }}
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        )}
        <Unity
          unityProvider={unityProvider}
          style={{ display: isLoaded ? "block" : "none" }}
        />
      </div>
      <div>
        <RWebShare
          data={shareData}
          onClick={() => console.log("shared successfully!")}
        >
          <button
            ref={buttonRef}
            onClick={() => console.log("shared successfully!")}
            style={{ display: "none" }}
          ></button>
        </RWebShare>
      </div>
    </div>
  );
};

export { App };
