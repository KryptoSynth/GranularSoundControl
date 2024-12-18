using System.Globalization;
using System.Text.RegularExpressions;
using GameNetcodeStuff;
using HarmonyLib;

namespace GranularSoundControl; 

public static class SharedUI {
    public const string Name = "GranularSoundControl";
    public const string Guid = GranularSoundControlInfo.Guid;
    public const string Version = GranularSoundControlInfo.Version;
    public const string Description = "Volume control for various sounds in the game.";
    
    static readonly Regex _nicifyRegex = new("(?<=[a-z])([A-Z])", RegexOptions.Compiled);
    
    public static string GetDisplayName(VolumeConfig volumeConfig) {
        var titleCaseKey = _nicifyRegex.Replace(volumeConfig.Key, " $1");
        if (volumeConfig.Section != "Vanilla") {
            titleCaseKey += $" ({volumeConfig.Section})";
        }
        return titleCaseKey;
    }

    public static void ResetAllVolumes() {
        foreach (var volumeConfig in GranularSoundControlPlugin.Instance.Config.Volumes.Values) {
            volumeConfig.NormalizedValue = 1f;
        }
    }
}