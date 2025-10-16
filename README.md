# InfoPanel.PluginUpdateNotifier# InfoPanel.PluginUpdateNotifier# InfoPanel.PluginUpdateNotifier# InfoPanel.PluginUpdateNotifier

A background utility plugin for [InfoPanel](https://github.com/habibrehmansg/InfoPanel) that automatically monitors installed plugins and notifies you when updates are available on GitHub.

![GitHub release](https://img.shields.io/github/v/release/F3NN3X/InfoPanel.PluginUpdateNotifier?style=flat-square)A background utility plugin for [InfoPanel](https://github.com/habibrehmansg/InfoPanel) that automatically monitors installed plugins and notifies you when updates are available on GitHub.

![License](https://img.shields.io/github/license/F3NN3X/InfoPanel.PluginUpdateNotifier?style=flat-square)

## 📋 Overview![GitHub release](https://img.shields.io/github/v/release/F3NN3X/InfoPanel.PluginUpdateNotifier?style=flat-square)A background utility plugin for [InfoPanel](https://github.com/habibrehmansg/InfoPanel) that automatically monitors installed plugins and notifies you when updates are available on GitHub.## Overview

**InfoPanel.PluginUpdateNotifier** scans all your installed InfoPanel plugins, checks their GitHub repositories for new releases, and displays **Windows toast notifications** when updates are available. No more manual checking—stay up-to-date effortlessly!

### How It Works![License](https://img.shields.io/github/license/F3NN3X/InfoPanel.PluginUpdateNotifier?style=flat-square)

1. **Scans** `C:\ProgramData\InfoPanel\plugins` at configured intervals

2. **Reads** each plugin's `PluginInfo.ini` metadata (Name, Version, Website)**InfoPanel.PluginUpdateNotifier** is a background utility plugin for [InfoPanel](https://github.com/habibrehmansg/InfoPanel) that automatically checks for **new versions of installed plugins**.  

3. **Checks** GitHub API for the latest release tag

4. **Compares** versions using semantic versioning## 📋 Overview

5. **Notifies** you via Windows toast notification when updates are found

---![GitHub release](https://img.shields.io/github/v/release/F3NN3X/InfoPanel.PluginUpdateNotifier?style=flat-square)It reads metadata from each plugin’s `PluginInfo.ini`, compares the version with the latest release (via GitHub), and displays a **Windows notification** when updates are available.

## ✨ Features

- 🔍 **Automatic Scanning** - Monitors all installed plugins in the background**InfoPanel.PluginUpdateNotifier** scans all your installed InfoPanel plugins, checks their GitHub repositories for new releases, and displays **Windows toast notifications** when updates are available. No more manual checking—stay up-to-date effortlessly!

- 🌐 **GitHub Integration** - Checks GitHub releases API for latest versions

- 🔔 **Native Notifications** - Windows 10/11 toast notifications![License](https://img.shields.io/github/license/F3NN3X/InfoPanel.PluginUpdateNotifier?style=flat-square)

- ⏰ **Configurable Interval** - User-customizable check frequency via INI file

- 🪶 **Lightweight** - Minimal CPU/memory usage, non-intrusive### How It Works

- 🛡️ **Safe & Reliable** - Graceful error handling, continues on network failures

- 📊 **Smart Versioning** - Handles semantic versions (v1.2.3) and string comparisons1. **Scans** `C:\ProgramData\InfoPanel\plugins` at configured intervalsThis helps users keep all their InfoPanel plugins up-to-date without manually visiting each repository.

---

## 🧩 Notification Example2. **Reads** each plugin's `PluginInfo.ini` metadata (Name, Version, Website)

When an update is available, you'll see:

```3. **Checks** GitHub API for the latest release tag## 📋 Overview

⚙️ Plugin Update Available

InfoPanel.FPS4. **Compares** versions using semantic versioning

Installed: 1.1.6  →  Latest: 1.2.0

```5. **Notifies** you via Windows toast notification when updates are found---

---

## 🔧 Installation---**InfoPanel.PluginUpdateNotifier** scans all your installed InfoPanel plugins, checks their GitHub repositories for new releases, and displays **Windows toast notifications** when updates are available. No more manual checking—stay up-to-date effortlessly!

### Option 1: From Release (Recommended)

1. Download the latest `InfoPanel.PluginUpdateNotifier-v{version}.zip` from [Releases](https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier/releases)## ✨ Features## ✨ Features

2. Extract the folder to:

   ```- 🔍 **Automatic Scanning** - Monitors all installed plugins in the background### How It Works- Scans all installed plugins in `C:\ProgramData\InfoPanel\plugins`

   C:\ProgramData\InfoPanel\plugins\

   ```- 🌐 **GitHub Integration** - Checks GitHub releases API for latest versions

3. Restart InfoPanel

4. The plugin starts automatically with default 24-hour check interval- 🔔 **Native Notifications** - Windows 10/11 toast notifications1. **Scans** `C:\ProgramData\InfoPanel\plugins` every 24 hours- Reads each plugin’s `PluginInfo.ini` for:

### Option 2: Build from Source

```powershell- ⏰ **Configurable Interval** - User-customizable check frequency via INI file

# Clone the repository

git clone https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier.git- 🪶 **Lightweight** - Minimal CPU/memory usage, non-intrusive2. **Reads** each plugin's `PluginInfo.ini` metadata (Name, Version, Website)  - Name  

cd InfoPanel.PluginUpdateNotifier

# Build the plugin- 🛡️ **Safe & Reliable** - Graceful error handling, continues on network failures

dotnet build -c Release

# Output location:- 📊 **Smart Versioning** - Handles semantic versions (v1.2.3) and string comparisons3. **Checks** GitHub API for the latest release tag  - Version  

# bin\Release\net8.0-windows10.0.19041.0\InfoPanel.PluginUpdateNotifier-v{Version}.zip

```---4. **Compares** versions using semantic versioning  - Website (used for GitHub lookups)

---

## 📁 Plugin Structure## 🧩 Notification Example5. **Notifies** you via Windows toast notification when updates are found- Checks for newer versions from GitHub releases

```

C:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\When an update is available, you'll see:- Displays native **Windows toast notifications** for updates

├── InfoPanel.PluginUpdateNotifier.dll

├── InfoPanel.PluginUpdateNotifier.dll.ini  (configuration file)```---- Runs silently in the background (default: every 24 hours)

├── PluginInfo.ini

├── INIFileParser.dll⚙️ Plugin Update Available

├── Microsoft.Toolkit.Uwp.Notifications.dll

└── (other dependencies)InfoPanel.FPS- Safe, low CPU usage, and non-intrusive

```

### PluginInfo.ini FormatInstalled: 1.1.6  →  Latest: 1.2.0

For other plugins to be monitored, they must have:

```ini```## ✨ Features

[PluginInfo]

Name=PluginName------

Version=1.0.0

Website=https://github.com/owner/repo  # Must be GitHub URL## 🔧 Installation- 🔍 **Automatic Scanning** - Monitors all installed plugins in the background

```

**Important**: The `Website` field must be a GitHub repository URL for update checking to work.### Option 1: From Release (Recommended)- 🌐 **GitHub Integration** - Checks GitHub releases API for latest versions## 🧩 Example Notification

---

## ⚙️ Configuration1. Download the latest `InfoPanel.PluginUpdateNotifier-v{version}.zip` from [Releases](https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier/releases)

The plugin uses a configuration file to customize its behavior. The file is automatically created with default values on first run.

### Configuration File Location2. Extract the folder to:- 🔔 **Native Notifications** - Windows 10/11 toast notifications> ⚙️ **Plugin Update Available**  

```

C:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\InfoPanel.PluginUpdateNotifier.dll.ini   ```

```

### Configuration Format   C:\ProgramData\InfoPanel\plugins\- ⏰ **Configurable Interval** - Default 24-hour check cycle (customizable)> InfoPanel.FPS → New version 1.2.0 available!  

**InfoPanel.PluginUpdateNotifier.dll.ini:**

```ini   ```

[Plugin Update Notifier]

CheckIntervalHours = 243. Restart InfoPanel- 🪶 **Lightweight** - Minimal CPU/memory usage, non-intrusive> Click to open download page.

```

### Configuration Options4. The plugin starts automatically with default 24-hour check interval

#### CheckIntervalHours

How often the plugin checks for updates (in hours). Supports decimal values for sub-hour intervals.- 🛡️ **Safe & Reliable** - Graceful error handling, continues on network failures

**Production Values (Recommended):**

```ini### Option 2: Build from Source

# Every 30 minutes

CheckIntervalHours = 0.5```powershell- 📊 **Smart Versioning** - Handles semantic versions (v1.2.3) and string comparisons---

# Every hour (recommended minimum)

CheckIntervalHours = 1# Clone the repository

# Every 6 hours

CheckIntervalHours = 6git clone https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier.git

# Every 12 hours

CheckIntervalHours = 12cd InfoPanel.PluginUpdateNotifier

# Every 24 hours (default)

CheckIntervalHours = 24---## 📁 File Structure

# Once a week

CheckIntervalHours = 168# Build the plugin

```

**Testing/Debug Values:**dotnet build -c ReleaseC:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier

```ini

# Every 30 seconds (rapid testing)# Output location:## 🧩 Notification Example│

CheckIntervalHours = 0.0083

# Every 1 minute (quick testing)# bin\Release\net8.0-windows10.0.19041.0\InfoPanel.PluginUpdateNotifier-v{Version}.zip

CheckIntervalHours = 0.0167

# Every 5 minutes (testing)```├── PluginUpdateNotifier.cs

CheckIntervalHours = 0.0833

# Every 10 minutes (testing)---When an update is available, you'll see:├── manifest.json

CheckIntervalHours = 0.1667

```## 📁 Plugin Structure├── PluginInfo.ini

### ⚠️ Important Notes

- **GitHub Rate Limits**: Unauthenticated API requests are limited to 60/hour. Short check intervals with many plugins may hit this limit.``````└── README.md

- **First Check**: Plugin checks immediately on startup, then waits for the configured interval

- **Restart Required**: Changes to the INI file require restarting InfoPanel to take effectC:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\

- **Auto-Creation**: If missing, the configuration file is automatically created with default values

### How to Change Configuration├── InfoPanel.PluginUpdateNotifier.dll⚙️ Plugin Update Available

1. Navigate to `C:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\`

2. Open `InfoPanel.PluginUpdateNotifier.dll.ini` in a text editor (e.g., Notepad)├── InfoPanel.PluginUpdateNotifier.dll.ini  (configuration file)

3. Modify the value (e.g., `CheckIntervalHours = 12`)

4. Save the file├── PluginInfo.iniInfoPanel.FPS## ⚙️ PluginInfo.ini Example

5. Restart InfoPanel

**Console Output Example:**├── INIFileParser.dll

```

[PluginUpdateNotifier] Check interval set to: 12 hours├── Microsoft.Toolkit.Uwp.Notifications.dllInstalled: 1.1.6  →  Latest: 1.2.0```ini

```

---└── (other dependencies)

## 🧪 Testing & Debugging

### Quick Test Setup``````[PluginInfo]

1. **Set Short Interval** - Edit the INI file:

   ```ini### PluginInfo.ini FormatName=InfoPanel Plugin Update Notifier

   [Plugin Update Notifier]

   CheckIntervalHours = 0.0167  # 1 minuteFor other plugins to be monitored, they must have:

   ```

2. **Create Test Plugin** - Make a folder with old version:```ini---Author=F3NN3X / Themely.dev

   ```

   C:\ProgramData\InfoPanel\plugins\TestPlugin\[PluginInfo]

   └── PluginInfo.ini

   ```Name=PluginNameVersion=1.0.0

   **PluginInfo.ini:**

   ```iniVersion=1.0.0

   [PluginInfo]

   Name=TestPluginWebsite=https://github.com/owner/repo  # Must be GitHub URL## 🔧 InstallationWebsite=https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier

   Version=1.0.0

   Website=https://github.com/YourGitHub/YourPlugin```

   ```

3. **Restart InfoPanel** - Changes take effectDescription=Automatically checks for updates for installed InfoPanel plugins.

4. **Verify Notification** - Should appear within 1 minute if newer version exists

5. **Check Console** - Monitor for log messages:**Important**: The `Website` field must be a GitHub repository URL for update checking to work.

   ```

   [PluginUpdateNotifier] Check interval set to: 0.0167 hours### Option 1: From Release (Recommended)

   [PluginUpdateNotifier] Checking plugin: TestPlugin

   ```---

### Debug Checklist

- ✅ Plugin has valid GitHub URL in `Website` field1. Download the latest `InfoPanel.PluginUpdateNotifier-v{version}.zip` from [Releases](https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier/releases)🔧 Installation

- ✅ GitHub repository has releases created

- ✅ Latest release tag is newer than installed version## ⚙️ Configuration

- ✅ Internet connection is active

- ✅ GitHub API is accessible (not rate limited)2. Extract the folder to:

### Common Testing Scenarios

- Plugin with outdated version → Should notifyThe plugin uses a configuration file to customize its behavior. The file is automatically created with default values on first run.

- Plugin without GitHub URL → Skipped (no notification)

- Plugin without PluginInfo.ini → Skipped   ```Download the plugin ZIP release from github.

- Network failure → Logged error, continues operation

- Invalid version format → Uses string comparison fallback### Configuration File Location

---

## 🧱 Dependencies```   C:\ProgramData\InfoPanel\plugins\Extract it to:

- **InfoPanel.Plugins** - Core InfoPanel plugin framework

- **Microsoft.Toolkit.Uwp.Notifications** (v7.1.3) - Windows toast notificationsC:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\InfoPanel.PluginUpdateNotifier.dll.ini

- **ini-parser** (v2.5.2) - INI configuration file parsing

- **System.Net.Http** - GitHub API requests```   ```C:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\

- **System.Text.Json** - JSON parsing

- **.NET 8.0 Windows 10 SDK** - Target framework (10.0.19041.0)### Configuration Format3. Restart InfoPanel

---

## 🏗️ Build System**InfoPanel.PluginUpdateNotifier.dll.ini:**4. The plugin starts automatically and checks for updates every 24 hoursRestart InfoPanel.

The project uses custom MSBuild targets for InfoPanel compatibility:

- **MoveDependencyFiles** - Flattens all DLLs to root output directory (InfoPanel requires flat structure)```ini

- **CreateReleaseZip** - Automatically packages plugin as distributable ZIP in Release builds

```powershell[Plugin Update Notifier]The plugin will automatically run and check for updates every 24 hours.

# Debug build (no ZIP packaging)

dotnet buildCheckIntervalHours = 24

# Release build (creates ZIP)

dotnet build -c Release```### Option 2: Build from Source

```

**Output Structure:**### Configuration Options```powershellAI Coding Instructions

```

bin\Release\net8.0-windows10.0.19041.0\#### CheckIntervalHours# Clone the repository

├── InfoPanel.PluginUpdateNotifier-v1.0.0.zip (distribution package)

└── InfoPanel.PluginUpdateNotifier-v1.0.0\How often the plugin checks for updates (in hours). Supports decimal values for sub-hour intervals.

    └── InfoPanel.PluginUpdateNotifier\

        ├── InfoPanel.PluginUpdateNotifier.dllgit clone https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier.gitUse these as guidance for GitHub Copilot or Cursor when developing or maintaining this plugin.

        ├── InfoPanel.PluginUpdateNotifier.dll.ini

        ├── PluginInfo.ini**Production Values (Recommended):**

        └── (dependencies)

``````inicd InfoPanel.PluginUpdateNotifier

---

## 🔍 How Version Comparison Works# Every 30 minutes

```csharp

// Example: "v1.1.6" vs "1.2.0"CheckIntervalHours = 0.5Primary Goal: Maintain a background InfoPanel plugin that checks for updates and sends Windows notifications.

1. Strip 'v' prefix: "1.1.6" vs "1.2.0"

2. Try Version.TryParse() for semantic versioning# Every hour (recommended minimum)# Build the plugin

3. Compare using Version objects (1.2.0 > 1.1.6) ✓

4. Fallback to string comparison if parsing failsCheckIntervalHours = 1

```

**Supported Formats:**dotnet build -c ReleaseLanguage: C# (.NET 8, Windows)

- Semantic: `1.0.0`, `1.2.3`, `2.0.0-beta`

- With prefix: `v1.0.0`, `v1.2.3`# Every 6 hours

- Partial: `1.0`, `1.2`

---CheckIntervalHours = 6

## 🤝 Contributing

Contributions welcome! Please:# Every 12 hours# Output location:Entry Point: PluginUpdateNotifier.cs

1. Fork the repository

2. Create a feature branch (`git checkout -b feature/amazing-feature`)CheckIntervalHours = 12

3. Make your changes

4. Commit using conventional commits (`git commit -m 'feat: add amazing feature'`)# bin\Release\net8.0-windows\InfoPanel.PluginUpdateNotifier-v{Version}.zip

5. Push to the branch (`git push origin feature/amazing-feature`)

6. Submit a pull request# Every 24 hours (default)

See [CHANGELOG.md](CHANGELOG.md) for version history.

---CheckIntervalHours = 24```Framework: Must integrate with InfoPanel’s BasePlugin system.

## 📝 Known Limitations

- Only supports GitHub repositories (no GitLab, Bitbucket, etc.)# Once a week

- No GitHub API rate limiting protection (60 requests/hour limit)

- Toast notification button ("Open GitHub") is non-functionalCheckIntervalHours = 168

- No per-plugin exclude/include configuration

- No GitHub authentication token support (for higher rate limits)```---Core Services:

---

## 🗺️ Roadmap**Testing/Debug Values:**

- [ ] GitHub authentication support (PAT tokens)

- [ ] GitLab and Bitbucket repository support```ini

- [ ] Plugin exclude/include list configuration

- [ ] Clickable toast notifications (open release page)# Every 30 seconds (rapid testing)## 📁 Plugin StructurePluginDirectoryService → Scans C:\ProgramData\InfoPanel\plugins

- [ ] Rate limiting protection and retry logic

- [ ] Service-based architecture refactoringCheckIntervalHours = 0.0083

- [ ] Unit test coverage

---# Every 1 minute (quick testing)

## 📄 License

MIT License - See [LICENSE](LICENSE) file for detailsCheckIntervalHours = 0.0167```VersionCheckService → Uses GitHub API to get latest version tags

---

## 👤 Author# Every 5 minutes (testing)C:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\

**F3NN3X**

- GitHub: [@F3NN3X](https://github.com/F3NN3X)CheckIntervalHours = 0.0833

- Website: [Themely.dev](https://themely.dev)

---├── InfoPanel.PluginUpdateNotifier.dllNotificationService → Displays Windows toast notifications

## 🙏 Acknowledgments

- [InfoPanel](https://github.com/habibrehmansg/InfoPanel) by habibrehmansg# Every 10 minutes (testing)

- [Microsoft Toolkit](https://github.com/CommunityToolkit/WindowsCommunityToolkit) for UWP notifications

- [ini-parser](https://github.com/rickyah/ini-parser) by rickyah for configuration managementCheckIntervalHours = 0.1667├── PluginInfo.ini


```

├── Microsoft.Toolkit.Uwp.Notifications.dllCycle:

### ⚠️ Important Notes

└── (other dependencies)

- **GitHub Rate Limits**: Unauthenticated API requests are limited to 60/hour. Short check intervals with many plugins may hit this limit.

- **First Check**: Plugin checks immediately on startup, then waits for the configured interval```On plugin start → initialize background loop

- **Restart Required**: Changes to the INI file require restarting InfoPanel to take effect

- **Auto-Creation**: If missing, the configuration file is automatically created with default values

### How to Change Configuration### PluginInfo.ini FormatEvery 24h → check all plugins → compare versions

1. Navigate to `C:\ProgramData\InfoPanel\plugins\InfoPanel.PluginUpdateNotifier\````ini

2. Open `InfoPanel.PluginUpdateNotifier.dll.ini` in a text editor (e.g., Notepad)

3. Modify the value (e.g., `CheckIntervalHours = 12`)[PluginInfo]If new version found → show toast + log result

4. Save the file

5. Restart InfoPanelName=InfoPanel.PluginUpdateNotifier

**Console Output Example:**Author=F3NN3XError Handling: Log errors to console, continue operation on network failure.

```

[PluginUpdateNotifier] Check interval set to: 12 hoursVersion=1.0.0

```

Website=https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifierNo Blocking Calls: Always use async/await and background tasks.

---

Description=Automatically checks for updates for installed InfoPanel plugins

## 🧪 Testing & Debugging

```Copilot prompt example:

### Quick Test Setup

1. **Set Short Interval** - Edit the INI file:

   ```ini**Important**: The `Website` field must be a GitHub repository URL for update checking to work.“Write a C# method that reads PluginInfo.ini from a plugin folder and returns Name, Version, and Website as a struct.”

   [Plugin Update Notifier]

   CheckIntervalHours = 0.0167  # 1 minute

   ```

---🧱 Dependencies

2. **Create Test Plugin** - Make a folder with old version:

   ```

   C:\ProgramData\InfoPanel\plugins\TestPlugin\

   └── PluginInfo.ini## ⚙️ ConfigurationInfoPanel.Plugins (Core framework)

   ```

   

   **PluginInfo.ini:**

   ```iniTo change the check interval, modify `CheckIntervalHours` in `PluginUpdateNotifier.cs`:System.Net.Http (GitHub API requests)

   [PluginInfo]

   Name=TestPlugin

   Version=1.0.0

   Website=https://github.com/YourGitHub/YourPlugin```csharpSystem.Text.Json (Parsing JSON responses)

   ```

private const double CheckIntervalHours = 24.0; // Change to desired hours

3. **Restart InfoPanel** - Changes take effect

```Microsoft.Toolkit.Uwp.Notifications (Windows toast notifications)

4. **Verify Notification** - Should appear within 1 minute if newer version exists

5. **Check Console** - Monitor for log messages:

   ```Then rebuild and reinstall the plugin.Install via NuGet:

   [PluginUpdateNotifier] Check interval set to: 0.0167 hours

   [PluginUpdateNotifier] Checking plugin: TestPlugin

   ```

---dotnet add package Microsoft.Toolkit.Uwp.Notifications

### Debug Checklist

- ✅ Plugin has valid GitHub URL in `Website` field

- ✅ GitHub repository has releases created

- ✅ Latest release tag is newer than installed version## 🧱 DependenciesBuild & Release

- ✅ Internet connection is active

- ✅ GitHub API is accessible (not rate limited)dotnet build -c Release

### Common Testing Scenarios- **InfoPanel.Plugins** - Core InfoPanel plugin framework

- Plugin with outdated version → Should notify

- Plugin without GitHub URL → Skipped (no notification)- **Microsoft.Toolkit.Uwp.Notifications** (v7.1.3) - Windows toast notificationsOutput directory:

- Plugin without PluginInfo.ini → Skipped

- Network failure → Logged error, continues operation- **System.Net.Http** - GitHub API requestsbin\Release\net8.0-windows\InfoPanel.PluginUpdateNotifier-v{Version}\InfoPanel.PluginUpdateNotifier

- Invalid version format → Uses string comparison fallback

- **System.Text.Json** - JSON parsing

---

- **.NET 8.0 Windows** - Target framework🧪 Testing

## 🧱 Dependencies

- **InfoPanel.Plugins** - Core InfoPanel plugin framework

- **Microsoft.Toolkit.Uwp.Notifications** (v7.1.3) - Windows toast notifications---Temporarily change check interval to 1 minute for debugging.

- **ini-parser** (v2.5.2) - INI configuration file parsing

- **System.Net.Http** - GitHub API requests

- **System.Text.Json** - JSON parsing

- **.NET 8.0 Windows 10 SDK** - Target framework (10.0.19041.0)## 🏗️ Build SystemSimulate older plugin versions in PluginInfo.ini to test notification behavior.

---

## 🏗️ Build SystemThe project uses custom MSBuild targets for InfoPanel compatibility:Test without internet connection to verify error handling.

The project uses custom MSBuild targets for InfoPanel compatibility:- **MoveDependencyFiles** - Flattens all DLLs to root output directory (InfoPanel requires flat structure)

- **CreateReleaseZip** - Automatically packages plugin as distributable ZIP in Release builds

- **MoveDependencyFiles** - Flattens all DLLs to root output directory (InfoPanel requires flat structure)

- **CreateReleaseZip** - Automatically packages plugin as distributable ZIP in Release builds```powershell

# Debug build (no ZIP packaging)

```powershelldotnet build

# Debug build (no ZIP packaging)

dotnet build# Release build (creates ZIP)

dotnet build -c Release

# Release build (creates ZIP)```

dotnet build -c Release

```---

**Output Structure:**## 🧪 Testing & Debugging

```

bin\Release\net8.0-windows10.0.19041.0\### Quick Test

├── InfoPanel.PluginUpdateNotifier-v1.0.0.zip (distribution package)1. Change `CheckIntervalHours` to `0.016` (≈1 minute)

└── InfoPanel.PluginUpdateNotifier-v1.0.0\2. Modify a test plugin's version to an older number

    └── InfoPanel.PluginUpdateNotifier\3. Rebuild and run - notification should appear within 1 minute

        ├── InfoPanel.PluginUpdateNotifier.dll

        ├── InfoPanel.PluginUpdateNotifier.dll.ini### Debug Workflow

        ├── PluginInfo.ini```csharp

        └── (dependencies)// Add breakpoint in CheckAllPluginsAsync() after:

```var pluginDirs = Directory.GetDirectories(PluginsPath);

```

---

### Test Scenarios

## 🔍 How Version Comparison Works- ✅ Plugin with GitHub URL and outdated version

- ✅ Plugin with non-GitHub URL (should skip)

```csharp- ✅ Plugin without PluginInfo.ini (should skip)

// Example: "v1.1.6" vs "1.2.0"- ✅ Network failure (should log error and continue)

1. Strip 'v' prefix: "1.1.6" vs "1.2.0"- ✅ Invalid version format (should use string comparison fallback)

2. Try Version.TryParse() for semantic versioning

3. Compare using Version objects (1.2.0 > 1.1.6) ✓---

4. Fallback to string comparison if parsing fails

```## 🔍 How Version Comparison Works

**Supported Formats:**
```csharp
- Semantic: `1.0.0`, `1.2.3`, `2.0.0-beta`// Example: "v1.1.6" vs "1.2.0"
- With prefix: `v1.0.0`, `v1.2.3`1. Strip 'v' prefix: "1.1.6" vs "1.2.0"
- Partial: `1.0`, `1.2`2. Try Version.TryParse() for semantic versioning
3. Compare using Version objects (1.2.0 > 1.1.6) ✓
4. Fallback to string comparison if parsing fails

```

## 🤝 Contributing

---

Contributions welcome! Please:
1. Fork the repository## 🤝 Contributing
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changesContributions welcome! Please:
4. Commit using conventional commits (`git commit -m 'feat: add amazing feature'`)1. Fork the repository
5. Push to the branch (`git push origin feature/amazing-feature`)2. Create a feature branch
6. Submit a pull request3. Make your changes
4. Submit a pull request

See [CHANGELOG.md](CHANGELOG.md) for version history.

---

## 📝 Known Limitations

- Only supports GitHub repositories (no GitLab, Bitbucket, etc.)
- Only supports GitHub repositories (no GitLab, Bitbucket, etc.)- No GitHub API rate limiting implementation
- No GitHub API rate limiting protection (60 requests/hour limit)- Toast notification button ("Open GitHub") is non-functional
- Toast notification button ("Open GitHub") is non-functional- No per-plugin exclude/include configuration
- No per-plugin exclude/include configuration
- No GitHub authentication token support (for higher rate limits)

## 🗺️ RoadmapMIT License - See [LICENSE](LICENSE) file for details

- [ ] GitHub authentication support (PAT tokens)---
- [ ] GitLab and Bitbucket repository support
- [ ] Plugin exclude/include list configuration## 👤 Author
- [ ] Clickable toast notifications (open release page)
- [ ] Rate limiting protection and retry logic

------

## 📄 License## 🙏 Acknowledgments

MIT License - See [LICENSE](LICENSE) file for details

## 🙏 Acknowledgments
- [InfoPanel](https://github.com/habibrehmansg/InfoPanel) by habibrehmansg
- [Microsoft Toolkit](https://github.com/CommunityToolkit/WindowsCommunityToolkit) for UWP notifications

---

## 👤 Author

**F3NN3X**
- GitHub: [@F3NN3X](https://github.com/F3NN3X)
- Website: [Themely.dev](https://themely.dev)

---

## 🙏 Acknowledgments

- [InfoPanel](https://github.com/habibrehmansg/InfoPanel) by habibrehmansg
- [Microsoft Toolkit](https://github.com/CommunityToolkit/WindowsCommunityToolkit) for UWP notifications
- [ini-parser](https://github.com/rickyah/ini-parser) by rickyah for configuration management
