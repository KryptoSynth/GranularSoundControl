﻿using System;
using System.Linq;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace KeepItDown; 

// ReSharper disable Unity.NoNullPropagation

[BepInPlugin(KeepItDownInfo.Guid, KeepItDownInfo.Name, KeepItDownInfo.Version)]
[BepInDependency(LethalSettingsGuid, BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency(LethalConfigGuid, BepInDependency.DependencyFlags.SoftDependency)]
public class KeepItDownPlugin : BaseUnityPlugin {
    public static KeepItDownPlugin Instance { get; private set; }
    
    internal ManualLogSource Log => Logger;
    internal new KeepItDownConfig Config { get; private set; }
    
    const string LethalSettingsGuid = "com.willis.lc.lethalsettings";
    const string LethalConfigGuid = "ainavt.lc.lethalconfig";
    
    void Awake() {
        Instance = this;
        
        Config = new KeepItDownConfig(base.Config);
        AddConfigs(new[] {
            "Airhorn",
            "CashRegister",
            "Dentures",
            "RobotToy",
            "Hairdryer",
            "WhoopieCushion",
            "Clownhorn",
            "Shotgun",
            "EasterEgg",
            "Knife",
            "Clock",
            "SoccerBall",
        }, "Scrap");
        
        AddConfigs(new[] {
            "Boombox",
            "Walkie-talkie",
            "Spraycan",
            "Jetpack",
            "Shovel",
            "ExtensionLadder",
            "StunGrenade",
        }, "Tools");
        
        AddConfigs(new[] {
            "Landmine",
            "Thunder",
            "Turret",
            "SteamLeak",
            "SpikeTrap",
        }, "Hazards");
        
        AddConfigs(new[] {
            "Jester",
            "SnareFlea",
            "Spider",
            "CoilHead",
            "SporeLizard",
            "HoardingBug",
            "Thumper",
            "EyelessDog",
            "GhostGirl",
            "Nutcracker",
            "OldBird",
            "ManeaterScream",
            "Barber"
        }, "Entities");
        
        AddConfigs(new[] {
            "Horn",
            "Radio",
            "Skidding",
            "Engine"
        }, "Cruiser");
        
        AddConfigs(new[] {
            "Scan",
            "LoudHorn",
            "ItemCharger",
            "Television",
            "ShipDoor",
            "CompanySpeaker"
        }, "Miscellaneous");

        var harmony = new Harmony(KeepItDownInfo.Guid);
        harmony.PatchAll(typeof(AudioPatches));
        
        var lethalSettingsInstalled = Chainloader.PluginInfos.ContainsKey(LethalSettingsGuid);
        if (lethalSettingsInstalled) {
            Log.LogInfo("LethalSettings found, initializing UI...");
            LethalSettingsUI.Init();
        }
        
        var lethalConfigInstalled = Chainloader.PluginInfos.ContainsKey(LethalConfigGuid);
        if (lethalConfigInstalled) {
            Log.LogInfo("LethalConfig found, initializing UI...");
            LethalConfigUI.Init();
        }
        
        if (!lethalSettingsInstalled && !lethalConfigInstalled) {
            Log.LogWarning("Neither LethalSettings nor LethalConfig found, no UI will be available");
        }
        
        Log.LogInfo($"{KeepItDownInfo.Guid} is loaded!");
    }

    /// <inheritdoc cref="KeepItDownConfig.AddVolumeConfig"/>
    internal bool AddConfig(string key, string section, ConfigFile cfg = null) {
        return Config.AddVolumeConfig(key, section, cfg);
    }
    
    /// <inheritdoc cref="KeepItDownConfig.AddVolumeConfigs"/>
    internal bool AddConfigs(IEnumerable<string> keys, string section, ConfigFile cfg = null) {
        return Config.AddVolumeConfigs(keys, section, cfg);
    }
    
    internal bool TryGetConfig(string key, out VolumeConfig config) {
        return Config.Volumes.TryGetValue(key, out config);
    }
    
    /// <summary>
    /// Binds to a volume config. Use this when you want to sync a property
    /// with a volume config. If you want to bind an AudioSource's volume,
    /// use <see cref="BindAudioSource"/> instead.
    /// </summary>
    /// <param name="key">The key of the config.</param>
    /// <param name="gameObject">
    /// The "owner" GameObject. When this is destroyed, the binding is removed.
    /// </param>
    /// <param name="baseVolume">The default volume, will be scaled by the config value.</param>
    /// <param name="volumeSetter">An action to set the raw volume.</param>
    /// <returns>Whether the binding was successfully created.</returns>
    internal bool Bind(string key, GameObject gameObject, float baseVolume, Action<float> volumeSetter) {
        if (!TryGetConfig(key, out var volumeConfig)) {
            Log.LogWarning($"Trying to bind volume config for {key}, but it doesn't exist");
            return false;
        }
        
        volumeConfig.AddBinding(new VolumeConfig.Binding(gameObject, baseVolume, volumeSetter));
        return true;
    }
    
    /// <summary>
    /// Binds the volume of an AudioSource to a volume config.
    /// </summary>
    /// <param name="key">The key of the config.</param>
    /// <param name="audioSource">The AudioSource to bind to.</param>
    /// <returns>Whether the binding was successfully created.</returns>
    internal bool BindAudioSource(string key, AudioSource audioSource) {
        return Bind(key, audioSource.gameObject, audioSource.volume, v => audioSource.volume = v);
    }
    
    internal bool BindAudioSourceClampRange(string key, AudioSource audioSource) {
        return Bind(key, audioSource.gameObject, audioSource.minDistance = 0.4f, v => audioSource.volume = v);
    }
    
    /// <summary>
    /// Binds the volume of one or more AudioSources to a volume config.
    /// </summary>
    /// <param name="key">The key of the config.</param>
    /// <param name="audioSources">The AudioSources to bind to.</param>
    /// <returns>Whether the binding was successfully created.</returns>
    internal bool BindAudioSources(string key, params AudioSource[] audioSources) {
        return audioSources.All(audioSource => BindAudioSource(key, audioSource));
    }
    
    internal bool BindAudioSourcesClampRange(string key, params AudioSource[] audioSources) {
        return audioSources.All(audioSource => BindAudioSourceClampRange(key, audioSource));
    }
    
    /// <summary>
    /// Removes all bindings for a specific GameObject.
    /// </summary>
    /// <param name="key">The key of the config.</param>
    /// <param name="gameObject">The target GameObject.</param>
    /// <returns>Whether the bindings were successfully removed.</returns>
    internal bool RemoveBindings(string key, GameObject gameObject) {
        if (!TryGetConfig(key, out var volumeConfig)) {
            Log.LogWarning($"Trying to remove volume config bindings for {key}, but it doesn't exist");
            return false;
        }
        
        volumeConfig.RemoveBindings(gameObject);
        return true;
    }
}