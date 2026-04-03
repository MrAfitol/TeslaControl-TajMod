# TeslaControl-TajMod
[![Version](https://img.shields.io/github/v/release/MrAfitol/TeslaControl-TajMod?sort=semver&style=flat-square&color=blue&label=Version)](https://github.com/MrAfitol/TeslaControl-TajMod/releases)
[![Downloads](https://img.shields.io/github/downloads/MrAfitol/TeslaControl-TajMod/total?style=flat-square&color=yellow&label=Downloads)](https://github.com/MrAfitol/TeslaControl-TajMod/releases)


A plugin that allows configuring which roles are ignored by Tesla gates, with an option to also ignore cuffed players.

# 📦 Installation Guide

Follow these steps to install the plugin:

## 1. Install BepInEx 5

Download the latest version of **BepInEx 5** from the official GitHub page:
👉 https://github.com/BepInEx/BepInEx/releases

* Choose the correct version for your server (usually **x64**)
* Extract the archive into your server folder (where the server executable is located)

After launching the server once, a `BepInEx` folder will be created automatically.

---

## 2. Download the Plugin

Go to the **Releases** section of this repository and download the latest version of the plugin (`.dll` file).

---

## 3. Install the Plugin

Move the downloaded `.dll` file into:

```
<Server Folder>/BepInEx/plugins/
```

Example:

```
C:\TajMod-Server\BepInEx\plugins\TeslaControl.dll
```

---

## 4. Launch the Server

Start the server normally.
If everything is installed correctly, the plugin will load automatically.

---

## ⚙️ Configuration

The plugin uses a BepInEx configuration file (TeslaControl.cfg) located in:
```
<Server Folder>/BepInEx/config/
```
You can customize which roles are ignored by Tesla gates and whether cuffed players are ignored. Example default config:

```
[General]

## Roles that the Tesla gate should ignore
# Setting type: String
# Default value: Scientist, FacilityGuard, NtfCadet, NtfLieutenant, NtfCommander
TeslaIgnoreRoles = Scientist, FacilityGuard, NtfCadet, NtfLieutenant, NtfCommander

## If true, Tesla gates will ignore cuffed (handcuffed) players and won't trigger on them.
# Setting type: Boolean
# Default value: true
IsTeslaIgnoreCuffedPlayers = true
```

💡 Tip: You can edit the config while the server is off. Changes will be applied automatically on next server start.

---

## ⚠️ Troubleshooting

* Make sure you installed **BepInEx 5**, not version 6
* Ensure the `.dll` file is inside the `plugins` folder
* Check logs in:

```
<Server Folder>/BepInEx/logs/
```

* If the plugin doesn’t work, verify that you downloaded the latest version
