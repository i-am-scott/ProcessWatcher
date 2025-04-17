# ProcessWatcher
Add executables that will start/stop a process and automatically restart them when they are frozen or crash. Intended as a replacement for ServerDoc and for my own specific use-case.
Has its own web portal for remote monitoring and control using Steam OpenID.

## Configuration
Create a config.json file next to the executable or run the application once to create the layout for you.
Your Steam API key can be found [here](https://steamcommunity.com/dev/apikey).
Enabling the Web server will let you remotely stop and start a service along with displaying CPU and Memory usage. Debug mode will show stack traces within the web browser.

OAuthReturn requires the URL to end with /login. The domain should be the same as the domain/ip this application will be listening on.

```json
{
  "Web": {
    "Enabled": true,
    "DebugMode": false,
    "BindAddressHTTP": "http://localhost:80",
    "BindAddressHTTPS": "https://localhost:443",
    "AllowedSteamIDs": [
      "STEAM_0:1",
      "7656119801361612"
    ]
  },
  "Steam": {
    "API": "",
    "OAuthUri": "https://steamcommunity.com/openid/login",
    "OAuthReturn": "https://your-url-here.com/login"
  }
}
```
