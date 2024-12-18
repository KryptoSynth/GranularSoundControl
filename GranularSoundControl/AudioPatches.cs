using HarmonyLib;
using Unity.Netcode;
using UnityEngine;

namespace GranularSoundControl; 

internal static class AudioPatches {
    static string GetFormattedName(Object gameObject) {
        return gameObject.name.Replace("(Clone)", "").Replace("Item", "");
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(NoisemakerProp), nameof(NoisemakerProp.Start))]
    static void NoiseMakerProp_Start_Postfix(NoisemakerProp __instance) {
        var gameObject = __instance.gameObject;
        var name = GetFormattedName(gameObject);
        GranularSoundControlPlugin.Instance.Bind(name, gameObject, __instance.maxLoudness, v => __instance.maxLoudness = v);
        GranularSoundControlPlugin.Instance.Bind(name, gameObject, __instance.minLoudness, v => __instance.minLoudness = v);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(AnimatedItem), nameof(AnimatedItem.Start))]
    static void AnimatedItem_Start_Postfix(AnimatedItem __instance) {
        var name = GetFormattedName(__instance.gameObject);
        GranularSoundControlPlugin.Instance.BindAudioSource(name, __instance.itemAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(RadarBoosterItem), nameof(RadarBoosterItem.Start))]
    static void RadarBoosterItem_Start_Postfix(RadarBoosterItem __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("RadarBoosterPing", __instance.pingAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(ShipAlarmCord), "Start")]
    static void ShipAlarmCord_Start_Postfix(ShipAlarmCord __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSources("ShipAlarm", __instance.hornClose, __instance.hornFar);
        GranularSoundControlPlugin.Instance.BindAudioSource("ShipAlarmCord", __instance.cordAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(BoomboxItem), nameof(BoomboxItem.Start))]
    static void BoomboxItem_Start_Postfix(BoomboxItem __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("Boombox", __instance.boomboxAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(WalkieTalkie), nameof(WalkieTalkie.Start))]
    static void WalkieTalkie_Start_Postfix(WalkieTalkie __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("Walkie-talkie", __instance.thisAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Start))]
    static void FlashlightItem_Start_Postfix(FlashlightItem __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("Flashlight", __instance.flashlightAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SprayPaintItem), nameof(SprayPaintItem.Start))]
    static void SprayPaintItem_Start_Postfix(SprayPaintItem __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("Spraycan", __instance.sprayAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(Landmine), "Start")]
    static void Landmine_Start_Postfix(Landmine __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("Landmine", __instance.mineAudio);
    }
    
        [HarmonyPostfix]
    [HarmonyPatch(typeof(SteamValveHazard), "Start")]
    static void SteamValveHazard_Start_Postfix(SteamValveHazard __instance)
    {
        GranularSoundControlPlugin.Instance.BindAudioSource("SteamLeak", __instance.valveAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SpikeRoofTrap), "Start")]
    static void SpikeRoofTrap_Start_Postfix(SpikeRoofTrap __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("SpikeTrap", __instance.spikeTrapAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(Turret), "Start")]
    static void Turret_Start_Postfix(Turret __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSources("Turret", __instance.mainAudio, __instance.berserkAudio, __instance.farAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), "Start")]
    static void VehicleController_Start_Postfix(VehicleController __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("CruiserHorn", __instance.hornAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), "SetRadioValues")]
    static void VehicleControllerRadio_Start_Postfix(VehicleController __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSources("CruiserRadio", __instance.radioAudio, __instance.radioInterference);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), "SetCarEffects")]
    static void VehicleControllerEngine_Start_Postfix(VehicleController __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSources("CruiserSkid", __instance.tireAudio, __instance.skiddingAudio);
        GranularSoundControlPlugin.Instance.BindAudioSources(
            "CruiserEngine",
            __instance.vehicleEngineAudio,
            __instance.engineAudio1,
            __instance.engineAudio2
        );
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(JesterAI), nameof(JesterAI.Start))]
    static void JesterAI_Start_Postfix(JesterAI __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("Jester", __instance.farAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SandSpiderAI), nameof(SandSpiderAI.Start))]
    static void SandSpider_Start_Postfix(SandSpiderAI __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("Spider", __instance.footstepAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(CentipedeAI), nameof(CentipedeAI.Start))]
    static void CentipedeAI_Start_Postfix(CentipedeAI __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("SnareFlea", __instance.clingingToPlayer2DAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(RadMechAI), nameof(RadMechAI.Start))]
    static void RedMechAI_Start_Postfix(RadMechAI __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSources(
            "OldBird",
            __instance.blowtorchAudio,
            __instance.explosionAudio,
            __instance.LocalLRADAudio,
            __instance.LocalLRADAudio2,
            __instance.chargeForwardAudio,
            __instance.flyingDistantAudio,
            __instance.spotlightOnAudio
        );
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(TVScript), "OnEnable")]
    static void TVScript_OnEnable_Postfix(TVScript __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("TV", __instance.tvSFX);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(TVScript), "OnDisable")]
    static void TVScript_OnDisable_Postfix(TVScript __instance) {
        GranularSoundControlPlugin.Instance.RemoveBindings("TV", __instance.tvSFX.gameObject);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "OnEnable")]
    static void StartOfRound_OnEnable_Postfix(StartOfRound __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("ShipDoor", __instance.shipDoorAudioSource);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "OnDisable")]
    static void StartOfRound_OnDisable_Postfix(StartOfRound __instance) {
        GranularSoundControlPlugin.Instance.RemoveBindings("ShipDoor", __instance.gameObject);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StormyWeather), "OnEnable")]
    static void StormyWeather_OnEnable_Postfix(StormyWeather __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSources(
            "Thunder",
            __instance.randomStrikeAudio,
            __instance.randomStrikeAudioB,
            __instance.targetedStrikeAudio
        );  
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StormyWeather), "OnDisable")]
    static void StormyWeather_OnDisable_Postfix(StormyWeather __instance) {
        GranularSoundControlPlugin.Instance.RemoveBindings("Thunder", __instance.gameObject);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.PlayAudioOfCurrentState))]
    static void EnemyAI_Start_Postfix(EnemyAI __instance) {
        switch (__instance) {
            case CaveDwellerAI caveDwellerAI:
                GranularSoundControlPlugin.Instance.BindAudioSource("ManeaterScream", caveDwellerAI.screamAudio);
                break;
            case CentipedeAI centipedeAI:
                GranularSoundControlPlugin.Instance.BindAudioSource("SnareFlea", centipedeAI.creatureSFX);
                break;
            case SandSpiderAI sandSpiderAI:
                GranularSoundControlPlugin.Instance.BindAudioSource("Spider", sandSpiderAI.creatureSFX);
                break;
        }
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(GrabbableObject), nameof(GrabbableObject.Start))]
    static void GrabbableObject_Start_Postfix(GrabbableObject __instance) {
        switch (__instance) {
            case RemoteProp remoteProp:
                GranularSoundControlPlugin.Instance.BindAudioSource("Remote", remoteProp.remoteAudio);
                break;
            case JetpackItem jetpackItem:
                GranularSoundControlPlugin.Instance.BindAudioSource("Jetpack", jetpackItem.jetpackAudio);
                break;
            case Shovel shovel:
                GranularSoundControlPlugin.Instance.BindAudioSource("Shovel", shovel.shovelAudio);
                break;
            case ShotgunItem shotgunItem:
                GranularSoundControlPlugin.Instance.BindAudioSources("Shotgun", shotgunItem.gunShootAudio, shotgunItem.gunBulletsRicochetAudio);
                break;
            case KnifeItem knifeItem:
                GranularSoundControlPlugin.Instance.BindAudioSource("Knife", knifeItem.knifeAudio);
                break;
            case ClockProp clockProp:
                GranularSoundControlPlugin.Instance.BindAudioSource("Clock", clockProp.tickAudio);
                break;
            case SoccerBallProp soccerBallProp:
                GranularSoundControlPlugin.Instance.BindAudioSource("SoccerBall", soccerBallProp.soccerBallAudio);
                break;
            case WhoopieCushionItem whoopieCushionItem:
                GranularSoundControlPlugin.Instance.BindAudioSource("WhoopieCushion", whoopieCushionItem.whoopieCushionAudio);
                break;
            case ExtensionLadderItem extensionLadderItem:
                GranularSoundControlPlugin.Instance.BindAudioSource("ExtensionLadder", extensionLadderItem.ladderAudio);
                break;
            case StunGrenadeItem stunGrenadeItem:
                var name = stunGrenadeItem.name.Contains("Egg") ? "EasterEgg" : "StunGrenade";
                GranularSoundControlPlugin.Instance.BindAudioSource(name, stunGrenadeItem.itemAudio);
                break;
        }
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(NetworkBehaviour), nameof(NetworkBehaviour.OnNetworkSpawn))]
    static void NetworkBehaviour_OnNetworkSpawn_Postfix(NetworkBehaviour __instance) {
        switch (__instance) {
            case ItemCharger itemCharger:
                GranularSoundControlPlugin.Instance.BindAudioSource("ItemCharger", itemCharger.zapAudio);
                break;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(HUDManager), "OnEnable")]
    static void HUDManager_OnEnable_Postfix(HUDManager __instance) {
        GranularSoundControlPlugin.Instance.BindAudioSource("Scan", __instance.UIAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(HUDManager), "OnDisable")]
    static void HUDManager_OnDisable_Postfix(HUDManager __instance) {
        GranularSoundControlPlugin.Instance.RemoveBindings("Scan", __instance.UIAudio.gameObject);
    }
}