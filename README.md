# TON Play Unity SDK

TON Play allows developers to add blockchain elements to any mobile or web game. Additionally, you can port any web game to launch directly inside Telegram via a Web App.


- [Use-cases](#use-cases)
- [Installation](#installation)
- [Quick start](#quick-start)
  - [TON Play API Quick start](#ton-play-api-quick-start)
  - [TPay API Quick start](#tpay-api-quick-start)
  - [React Wrapper Quick Start](#react-wrapper-quick-start)
    - [React Wrapper Simple Test](#react-wrapper-simple-test)
    - [React Wrapper Test your build](#react-wrapper-test-your-build)
    - [React Wrapper Custom build](#react-wrapper-custom-build)
    - [React Wrapper Debug Console](#react-wrapper-debug-console)
- [Main feature](#main-feature)
  - [TON Play API](#ton-play-api)
  - [TPayAPI](#tpayapi)
  - [ReactWrapper](#reactwrapper)

## Use-cases

This SDK allows you to get blockchain assets related to your game and to a specific user.

Also, you can create an in-game marketplace, so your users can put assets on sale, remove them from sale, and buy and sell assets.

Moreover, this SDK includes React wrapper:

1. to optimize the way you launch the game in iFrame or WebApp/WebView
2. to open external links (for example, invite links or signing transactions)
3. to open Debug Console in Telegram

## Installation

To install the SDK in your project, use [TONPlaySDK.unitypackage](https://github.com/ton-play/tonplay-unity-sdk/blob/main/TONPlaySDK.unitypackage)

This SDK has a dependency on the free package [Rest Client for Unity](https://assetstore.unity.com/packages/tools/network/rest-client-for-unity-102501)

## Quick start

1. Register and log in to the admin panel on the platform [Console TON Play](https://console.tonplay.io/).
2. Create a game in [Console TON Play](https://console.tonplay.io/) and get [API Key and Game Key](https://docs.tonplay.io/digital-assets-api/api-key).

<img width="500" alt="Create new Game" src="https://user-images.githubusercontent.com/111277652/236257239-7891c368-4664-4b01-8392-479dc6ba751b.png">

### TON Play API Quick start

3. Open `1_TONPlayAPI_User` scene in TonPlay -> Example -> Scenes and select `TonPlayUserController` on the scene.
4. Open the [Console TON Play](https://console.tonplay.io/) and copy the required information in ScriptableObject `TonPlayData`.

Copy the API Key by simply clicking on the copy button.

<img width="500" alt="CopyAPIKey_img" src="https://user-images.githubusercontent.com/111277652/236257386-439958b4-e20b-41ee-b83d-e6bb97211cff.png">

Copy the Game Key (this is the string before the colon).

<img width="500" alt="CopyGameKey" src="https://user-images.githubusercontent.com/111277652/236257419-d5cb1f24-1c20-4be3-8095-6c29e8931f62.png">

Receive and copy UserJWT
Since we are not doing token verification in this example, any token you get will do. You can go to the TON Play platform, launch any game and copy it from the console in the browser. You can write your own telegram bot and authorize the user. But first, the easiest way is https://t.me/tonplay_dev_bot

<img width="500" alt="telegram_bot_tonplayDev_getUserJWT" src="https://user-images.githubusercontent.com/111277652/236263583-07eca3d7-cd5e-43a7-9836-9622a1c46601.png">

> **Note** In a real game, always [validate a token](https://docs.tonplay.io/digital-assets-api/authentication/validate-user-jwt) , you need to make sure that the token is still active and it definitely belongs to your game.

As a result, you should get something like this

<img width="433" alt="TonPlayData" src="https://user-images.githubusercontent.com/111277652/236257708-0182b92f-8dbe-4997-a118-8f9d984f096c.png">

5. Click Play button in Unity and test your data
6. You can build WebGL and run it in a browser. Note that `TonPlayUserController` reads the `token` query from the command line, and if it does not find it, then it will already ask for userJWT from `TonPlayData`.
7. You can test other scenes related to the TON Play API in the same way. You will not have to fill in the data for them, since you have already placed the necessary information in `TonPlayData`

### TPay API Quick start

3. Open `5_TPayAPI_PayIn` scene in TonPlay -> Example -> Scenes and select `TonPlayPayInController` on the scene.
4. Open the [Console TON Play](https://console.tonplay.io/) and create [Payment Key](https://docs.tonplay.io/payment-solution/get-started)

`TON Wallet Address` — your real address to receive TON tokens from the user.

`Webhook` — the address of your server where the notification of receiving tokens will be sent.
For a test, you can use https://webhook.site/ , but only for a test. You can read more about [TPay Webhook here](https://docs.tonplay.io/payment-solution/webhook)

5. Copy [Payment Key](https://docs.tonplay.io/payment-solution/get-started) to ScriptableObject `TPayData`.
6. Set any `OrderId` that is convenient for you (you need it in order to finally understand why the user sent the money).
7. Set `Amount` (Value in $TON. Not $nanoTON).

<img width="430" alt="TPayData" src="https://user-images.githubusercontent.com/111277652/236257865-8bd5ea5b-6144-44c0-b448-86f2ec8bb933.png">

8. Click Play button in Unity and test your data
9. Now you can scan the QR, send TON, and a notification will be sent to your Webhook. For the test, you can send to your own wallets.

### React Wrapper Quick Start

In order to properly display the application and use additional helper functions, we recommend that you put your assembly in a React wrapper.

#### React Wrapper Simple Test

1. Open `react-unity-webgl` and find `Example` folder.

<img width="325" alt="Build folder" src="https://user-images.githubusercontent.com/111277652/236257904-d5fe1e8b-b584-4629-b16c-45ec6c19979b.png">

2. For a simple site start, you can use [Servez](https://github.com/greggman/servez) ([Servez builds for different platforms](https://github.com/greggman/servez/releases/))

3. Start you site

#### React Wrapper Test your build

1. For example build `6_ReactWrapper` scene for WebGL. You can try test this scene in Web browser, in Telegram game (web view) and Telegram Web App. So you will understand how different methods behave on different devices.

For ease of test launch, we suggest build with `Compression Format` `Disabled` (in Player Settings -> Publishing Settings).

When building please name the project `Game`

<img width="371" alt="Build result" src="https://user-images.githubusercontent.com/111277652/236257950-14b25891-64a7-4848-ac3f-2b527059c903.png">

2. Open `react-unity-webgl` and find `Example` folder. Put your files (`Game.data`, `Game.framework.js`, `Game.loader.js`, `Game.wasm`)

<img width="285" alt="Example folder" src="https://user-images.githubusercontent.com/111277652/236259127-30caf832-1474-487c-96ce-29158634feb7.png">

3. Start you site with [Servez](https://github.com/greggman/servez) ([Servez builds for different platforms](https://github.com/greggman/servez/releases/))

#### React Wrapper Custom build

1. For example build `6_ReactWrapper` scene for WebGL. You can name build whatever you want. You can use whatever compression you want.
2. Open `react-unity-webgl` in Visual Studio Code (for example)
3. In terminal call `npm i` (You will need to install npm on your device first.)
4. Put your files ( for example `Game.data`, `Game.framework.js`, `Game.loader.js`, `Game.wasm`, maybe you will have other names ) in react-unity-webgl -> public -> `unitybuild` folder
5. In react-unity-webgl -> src -> `app.component.tsx` update code before start

<img width="600" alt="Update appName" src="https://user-images.githubusercontent.com/111277652/236259346-11e14233-bb0b-4e36-9122-968678d61fff.png">

6. If you don't have compression you can just call in terminal `npm run start` and you'll start you app in browser. Or you can make build `npm run build` and upload you app on server from `build` folder

<img width="325" alt="Build folder" src="https://user-images.githubusercontent.com/111277652/236262834-cd7fd46b-cf3b-4370-9ace-e091fc25092b.png">

#### React Wrapper Debug Console

If you need a console for testing and displaying logs inside telegrams. You can enable [eruda](https://www.npmjs.com/package/eruda)

react-unity-webgl -> public -> `index.html`

If you don't need it, then just delete these lines.

```
<script src="//cdn.jsdelivr.net/npm/eruda"></script>
    <script>
      eruda.init();
    </script>
```

<img width="445" alt="Console" src="https://user-images.githubusercontent.com/111277652/236259391-bc21606e-a0fb-4b6d-a374-8e4518e0bc13.png">

## Main feature

- TON Play API — contains a set of API methods for interaction with the TON Play platform
- TPayAPI — contains payment solution API
- ReactWrapper — contains a set of methods that allow you to interact with the telegram API, as well as additional functions such as sharing.

The entire list of requests can be viewed in [postman](https://docs.tonplay.io/digital-assets-api/postman)

> **Note** For the safety of user game progress, you are recommended to transfer all requests containing the API Key to the backend.

### TON Play API

Contains Rest API requests:

- [AssetsAPI (Public API)](https://docs.tonplay.io/digital-assets-api/assets-api#public-api)
- [UsersAPI (Public API)](https://docs.tonplay.io/digital-assets-api/users-api)
- [InGameMarketPlaceAPI (Public API)](https://docs.tonplay.io/digital-assets-api/in-game-marketplace-api)
- [AddUserWalletAPI](https://docs.tonplay.io/digital-assets-api/connect-wallet)

To call a function TON Play API functions from Unity you will need add TONPlay

`using TONPlay;`

and create TonPlayAPI object

`TonPlayAPI tonPlayAPI = new TonPlayAPI();`

### TPayAPI

Allows users to transfer TON to your TON address. The user, for example, will be able to exchange TON for game assets.

Contain Rest API request:

- [Pay-in](https://docs.tonplay.io/payment-solution/pay-in)

To call a function TON Play API functions from Unity you will need add TONPlay

`using TONPlay;`

and create TonPlayAPI object

`TPayAPI tpayAPI = new TPayAPI();`

### ReactWrapper

You can use our wrapper for WebGL and use already implemented functions in it.

When running the game inside a wrapper, you won't have problems with the game rendering incorrectly in the iFrame.

To call wrapper functions from Unity you will need

`using ReactWrapper.ReactAPI;` - to call react functions  
`using ReactWrapper.TelegramAPI;` - to call Telegram API functions from react.

Functions in React Wrapper:

- `OpenUrl` - opens a link with the selected method
- `WindowHrefOpen` - opens a link
- `ShareData` - allows you to share a link

> **Note**
> Please note that OpenUrl and WindowHrefOpen may not work inside the built-in telegram browser, except for links with a redirect to a deep link application, such as Tonkeeper.

Functions in TelegramAPI

- `OpenLink` - opens a link in an external application from Telegram
- `OpenTelegramLink` - opens a link inside Telegram
- `HapticFeedback` - you can call Haptic triggers inside Telegram

> **Note**
> Please note that the functions exactly work in the Telegram app when running the game as a Web App, since Telegram API above 6.7 is supported there.
