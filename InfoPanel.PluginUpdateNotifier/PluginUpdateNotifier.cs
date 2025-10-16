using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Toolkit.Uwp.Notifications;
using IniParser;
using IniParser.Model;
using InfoPanel.Plugins;

namespace PluginUpdateNotifier
{
    public class PluginUpdateNotifier : BasePlugin
    {
        private readonly HttpClient _http = new HttpClient();
        private const string PluginsPath = @"C:\ProgramData\InfoPanel\plugins";
        private const double DefaultCheckIntervalHours = 24.0;
        
        private string? _configFilePath = null;
        private double _checkIntervalHours = DefaultCheckIntervalHours;

        public override string? ConfigFilePath => _configFilePath;
        public override TimeSpan UpdateInterval => TimeSpan.FromHours(_checkIntervalHours);

        public PluginUpdateNotifier() : base("Plugin Update Notifier", "Automatically checks for plugin updates on GitHub")
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("InfoPanelPluginUpdateNotifier/1.0");
            LoadConfiguration();
            RegisterToastActivationHandler();
        }

        // Register the toast notification activation handler once
        private static void RegisterToastActivationHandler()
        {
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                try
                {
                    var args = ToastArguments.Parse(toastArgs.Argument);
                    Console.WriteLine($"[PluginUpdateNotifier] Toast activated with args: {toastArgs.Argument}");
                    
                    if (args.Contains("action") && args["action"] == "viewRelease")
                    {
                        if (args.Contains("url"))
                        {
                            string url = args["url"];
                            Console.WriteLine($"[PluginUpdateNotifier] Opening URL: {url}");
                            
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = url,
                                UseShellExecute = true
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[PluginUpdateNotifier] Toast activation error: {ex.Message}");
                }
            };
        }

        public override void Initialize()
        {
            // Initialization logic if needed
        }

        public override void Load(List<IPluginContainer> containers)
        {
            // This plugin doesn't create any UI containers
            // It runs silently in the background
            // InfoPanel will call UpdateAsync() based on UpdateInterval
        }

        public override void Update()
        {
            // Synchronous update - not used for this plugin
        }

        public override async Task UpdateAsync(CancellationToken cancellationToken)
        {
            // Asynchronous update - called by InfoPanel at UpdateInterval
            await CheckAllPluginsAsync();
        }

        public override void Close()
        {
            _http?.Dispose();
        }

        private async Task CheckAllPluginsAsync()
        {
            try
            {
                if (!Directory.Exists(PluginsPath))
                    return;

                var pluginDirs = Directory.GetDirectories(PluginsPath);
                foreach (var dir in pluginDirs)
                {
                    string iniPath = Path.Combine(dir, "PluginInfo.ini");
                    if (!File.Exists(iniPath))
                        continue;

                    var info = ParseIni(iniPath);
                    if (info == null || string.IsNullOrEmpty(info.Website))
                        continue;

                    if (IsGitHubRepo(info.Website))
                    {
                        string repo = ExtractRepoFromUrl(info.Website);
                        if (!string.IsNullOrEmpty(repo))
                        {
                            string latestVersion = await GetLatestReleaseTagAsync(repo);
                            if (!string.IsNullOrEmpty(latestVersion) && IsNewerVersion(latestVersion, info.Version))
                            {
                                ShowUpdateNotification(info.Name, info.Version, latestVersion, info.Website);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PluginUpdateNotifier] Error: {ex.Message}");
            }
        }

        private async Task<string> GetLatestReleaseTagAsync(string repo)
        {
            try
            {
                string apiUrl = $"https://api.github.com/repos/{repo}/releases/latest";
                string json = await _http.GetStringAsync(apiUrl);
                using var doc = JsonDocument.Parse(json);
                return doc.RootElement.GetProperty("tag_name").GetString();
            }
            catch
            {
                return null;
            }
        }

        private static bool IsGitHubRepo(string url)
        {
            return url.StartsWith("https://github.com/", StringComparison.OrdinalIgnoreCase);
        }

        private static string ExtractRepoFromUrl(string url)
        {
            try
            {
                var uri = new Uri(url);
                var parts = uri.AbsolutePath.Trim('/').Split('/');
                if (parts.Length >= 2)
                    return $"{parts[0]}/{parts[1]}";
            }
            catch { }
            return null;
        }

        private static bool IsNewerVersion(string latest, string current)
        {
            string l = latest.TrimStart('v');
            string c = current.TrimStart('v');
            if (Version.TryParse(l, out var latestV) && Version.TryParse(c, out var currentV))
            {
                return latestV > currentV;
            }
            return !string.Equals(latest, current, StringComparison.OrdinalIgnoreCase);
        }

        private static PluginInfo ParseIni(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path);
                var info = new PluginInfo();
                foreach (var line in lines)
                {
                    if (line.StartsWith("Name=", StringComparison.OrdinalIgnoreCase))
                        info.Name = line.Substring(5).Trim();
                    else if (line.StartsWith("Version=", StringComparison.OrdinalIgnoreCase))
                        info.Version = line.Substring(8).Trim();
                    else if (line.StartsWith("Website=", StringComparison.OrdinalIgnoreCase))
                        info.Website = line.Substring(8).Trim();
                }
                return info;
            }
            catch
            {
                return null;
            }
        }

        private static void ShowUpdateNotification(string name, string current, string latest, string githubUrl)
        {
            try
            {
                // Build the releases URL
                string releasesUrl = githubUrl.TrimEnd('/') + "/releases";
                
                Console.WriteLine($"[PluginUpdateNotifier] Showing notification for {name}");
                Console.WriteLine($"[PluginUpdateNotifier] Releases URL: {releasesUrl}");
                
                new ToastContentBuilder()
                    .AddText($"{name} Update Available")
                    .AddText($"Installed: {current}  →  Latest: {latest}")
                    .AddButton(new ToastButton()
                        .SetContent("Open GitHub")
                        .AddArgument("action", "viewRelease")
                        .AddArgument("url", releasesUrl))
                    .Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PluginUpdateNotifier] Failed to show notification: {ex.Message}");
            }
        }

        private void LoadConfiguration()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            _configFilePath = $"{assembly.ManifestModule.FullyQualifiedName}.ini";

            var parser = new FileIniDataParser();
            try
            {
                if (!File.Exists(_configFilePath))
                {
                    Console.WriteLine($"[PluginUpdateNotifier] Config file not found at {_configFilePath}, creating default.");
                    CreateDefaultConfigFile(parser);
                }
                else
                {
                    Console.WriteLine($"[PluginUpdateNotifier] Reading config file from {_configFilePath}");
                    IniData config = parser.ReadFile(_configFilePath);
                    LoadConfigurationFromIni(config);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PluginUpdateNotifier] Error reading config file '{_configFilePath}': {ex.Message}");
                SetDefaultConfiguration();
            }

            LogConfigurationSummary();
        }

        private void CreateDefaultConfigFile(FileIniDataParser parser)
        {
            var config = new IniData();
            config["Plugin Update Notifier"]["CheckIntervalHours"] = DefaultCheckIntervalHours.ToString();
            parser.WriteFile(_configFilePath, config);
            
            SetDefaultConfiguration();
        }

        private void SetDefaultConfiguration()
        {
            _checkIntervalHours = DefaultCheckIntervalHours;
        }

        private void LoadConfigurationFromIni(IniData config)
        {
            if (!double.TryParse(config["Plugin Update Notifier"]["CheckIntervalHours"], out _checkIntervalHours) || _checkIntervalHours <= 0)
            {
                Console.WriteLine($"[PluginUpdateNotifier] Invalid CheckIntervalHours, using default: {DefaultCheckIntervalHours}");
                _checkIntervalHours = DefaultCheckIntervalHours;
            }
        }

        private void LogConfigurationSummary()
        {
            Console.WriteLine($"[PluginUpdateNotifier] Check interval set to: {_checkIntervalHours} hours");
        }

        private class PluginInfo
        {
            public string Name { get; set; } = string.Empty;
            public string Version { get; set; } = string.Empty;
            public string Website { get; set; } = string.Empty;
        }
    }
}
