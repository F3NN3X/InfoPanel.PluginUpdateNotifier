# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.1] - 2025-10-16

### Added
- INI-based configuration system with auto-creation of default settings
- User-configurable check interval via `InfoPanel.PluginUpdateNotifier.dll.ini`
- Decimal hour support for sub-hour check intervals (e.g., 0.0167 for 1 minute testing)
- Toast notification activation handler for opening GitHub releases pages
- Comprehensive console logging for debugging and monitoring
- Documentation for configuration options and testing workflows

### Changed
- Migrated from custom Timer to InfoPanel's built-in update lifecycle (`UpdateAsync`)
- Plugin now inherits from `BasePlugin` instead of standalone class structure
- Implemented required `IPlugin` interface methods (Initialize, Load, Update, UpdateAsync, Close)
- Toast notifications now use foreground activation for better button functionality
- Configuration file path based on assembly location
- Updated PluginInfo.ini header from `[Plugin]` to `[PluginInfo]` for consistency

### Fixed
- Fixed InfoPanel crash by implementing proper `BasePlugin` interface
- Fixed duplicate notifications (previously shown twice per check)
- Fixed "Open GitHub" button not functioning in toast notifications
- Fixed toast activation handler registration (now registered once at initialization)
- Fixed GitHub releases URL construction to append `/releases` path

### Dependencies
- Added ini-parser v2.5.2 for configuration management
- Microsoft.Toolkit.Uwp.Notifications v7.1.3
- InfoPanel.Plugins (external reference)
- .NET 8.0 Windows target framework (10.0.19041.0)

## [1.0.0] - 2025-10-16

### Added
- Initial release of InfoPanel.PluginUpdateNotifier
- Automatic scanning of installed InfoPanel plugins in `C:\ProgramData\InfoPanel\plugins`
- GitHub API integration to check for latest release versions
- INI file parsing for plugin metadata (Name, Version, Website)
- Smart version comparison with semantic versioning support
- Version string fallback for non-standard version formats
- Windows 10/11 native toast notifications for update alerts
- Timer-based background checking every 24 hours
- Configurable check interval via `CheckIntervalHours` constant
- Graceful error handling with console logging
- Support for GitHub repository URLs only
- Automatic dependency flattening in build process
- ZIP packaging for distribution in Release builds
- `OnLoad()` and `OnUnload()` lifecycle methods for InfoPanel integration

### Dependencies
- Microsoft.Toolkit.Uwp.Notifications v7.1.3
- InfoPanel.Plugins (external reference)
- .NET 8.0 Windows target framework

[1.0.1]: https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier/releases/tag/v1.0.1
[1.0.0]: https://github.com/F3NN3X/InfoPanel.PluginUpdateNotifier/releases/tag/v1.0.0
