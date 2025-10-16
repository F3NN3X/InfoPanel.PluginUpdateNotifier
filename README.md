# InfoPanel.PluginUpdateNotifier

A background utility plugin for [InfoPanel](https://github.com/habibrehmansg/InfoPanel) that automatically monitors installed plugins and notifies you when updates are available on GitHub.

![GitHub release](https://img.shields.io/github/v/release/F3NN3X/InfoPanel.PluginUpdateNotifier?style=flat-square)
![License](https://img.shields.io/github/license/F3NN3X/InfoPanel.PluginUpdateNotifier?style=flat-square)

## 📋 Overview

**InfoPanel.PluginUpdateNotifier** scans all your installed InfoPanel plugins, checks their GitHub repositories for new releases, and displays **Windows toast notifications** when updates are available. No more manual checking—stay up-to-date effortlessly!

### How It Works

1.  **Scans** `C:\ProgramData\InfoPanel\plugins` at configured intervals.
2.  **Reads** each plugin's `PluginInfo.ini` metadata (Name, Version, Website).
3.  **Checks** the GitHub API for the latest release tag.
4.  **Compares** versions using semantic versioning.
5.  **Notifies** you via a Windows toast notification when an update is found.

---

## ✨ Features

-   🔍 **Automatic Scanning**: Monitors all installed plugins in the background.
-   🌐 **GitHub Integration**: Checks GitHub's releases API for the latest versions.
-   🔔 **Native Notifications**: Uses Windows 10/11 toast notifications.
-   ⏰ **Configurable Interval**: Allows user-customizable check frequency via an INI file.
-   🪶 **Lightweight**: Ensures minimal CPU/memory usage and is non-intrusive.
-   🛡️ **Safe & Reliable**: Handles errors gracefully and continues on network failures.
-   📊 **Smart Versioning**: Manages semantic versions (e.g., v1.2.3) and string comparisons.

---

## 🧩 Notification Example

When an update is available, you'll see a notification like this:

```
⚙️ Plugin Update Available
InfoPanel.FPS
Installed: 1.1.6  →  Latest: 1.2.0
```

---

## 🔧 Installation

### Option 1: From Release (Recommended)

1.  Download the latest `InfoPanel.PluginUpdateNotifier-v{version}.zip` from the [Releases](https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier/releases) page.
2.  Extract the folder to `C:\ProgramData\InfoPanel\plugins\`.
3.  Restart InfoPanel.
4.  The plugin will start automatically with the default 24-hour check interval.

### Option 2: Build from Source

```powershell
# Clone the repository
git clone https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier.git
cd InfoPanel.PluginUpdateNotifier

# Build the plugin in Release configuration
dotnet build -c Release

# The output ZIP will be in:
# bin\Release\net8.0-windows10.0.19041.0\InfoPanel.PluginUpdateNotifier-v{Version}.zip
```

---

## ⚙️ Configuration

The plugin's behavior can be customized via a configuration file, which is automatically created with default values on the first run.

**File Location**:
`C:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\InfoPanel.PluginUpdateNotifier.dll.ini`

**Default Configuration**:

```ini
[Plugin Update Notifier]
CheckIntervalHours = 24
```

### Configuration Options

-   **`CheckIntervalHours`**: Sets how often the plugin checks for updates, in hours. Decimal values are supported for sub-hour intervals.

    -   **Testing**: Use `0.0167` for 1 minute or `0.0083` for 30 seconds.
    -   **Production**: `1` (hourly), `12` (twice a day), or `24` (daily, default).

### Important Notes

-   **GitHub Rate Limits**: Unauthenticated API requests are limited to 60 per hour. Very short intervals with many plugins may hit this limit.
-   **First Check**: The plugin performs an initial check on startup before waiting for the configured interval.
-   **Restart Required**: InfoPanel must be restarted for changes to the INI file to take effect.

---

## 🤝 Contributing

Contributions are welcome! Please fork the repository, create a feature branch, and submit a pull request.

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
