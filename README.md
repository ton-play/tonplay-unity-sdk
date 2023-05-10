# TON Play Unity SDK

TON Play allows developers to add blockchain elements to any mobile or web game. Additionally, you can port any web game to launch directly inside Telegram via a Web App.

- [Use-cases](#use-cases)
- [Installation](#installation)
- [Quick start](#quick-start)
  - [TON Play API Quick start](#ton-play-api-quick-start)
  - [TPay API Quick start](#tpay-api-quick-start)
- [Main feature](#main-feature)
  - [TON Play API](#ton-play-api)
  - [TPayAPI](#tpayapi)

## Use-cases

This SDK allows you to get blockchain assets related to your game and to a specific user.

Also, you can create an in-game marketplace, so your users can put assets on sale, remove them from sale, and buy and sell assets.

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

## Main feature

- TON Play API — contains a set of API methods for interaction with the TON Play platform
- TPayAPI — contains payment solution API

The entire list of requests can be viewed in [postman](https://docs.tonplay.io/digital-assets-api/postman)

> **Note** For the safety of user game progress, you are recommended to transfer all requests containing the API Key and Payment Key to the backend.

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
