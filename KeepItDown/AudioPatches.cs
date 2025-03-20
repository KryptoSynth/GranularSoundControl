using HarmonyLib;
using Unity.Netcode;
using UnityEngine;

namespace KeepItDown; 

internal static class AudioPatches {
    static string GetFormattedName(Object gameObject) {
        return gameObject.name.Replace("(Clone)", "").Replace("Item", "");
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(NoisemakerProp), nameof(NoisemakerProp.Start))]
    static void NoiseMakerProp_Start_Postfix(NoisemakerProp __instance) {
        var gameObject = __instance.gameObject;
        var name = GetFormattedName(gameObject);
        KeepItDownPlugin.Instance.Bind(name, gameObject, __instance.maxLoudness, v => __instance.maxLoudness = v);
        KeepItDownPlugin.Instance.Bind(name, gameObject, __instance.minLoudness, v => __instance.minLoudness = v);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(AnimatedItem), nameof(AnimatedItem.Start))]
    static void AnimatedItem_Start_Postfix(AnimatedItem __instance) {
        var name = GetFormattedName(__instance.gameObject);
        KeepItDownPlugin.Instance.BindAudioSource(name, __instance.itemAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(ShipAlarmCord), nameof(ShipAlarmCord.HoldCordDown))]
    static void ShipAlarmCord_HoldCordDown_Postfix(ShipAlarmCord __instance) {
        KeepItDownPlugin.Instance.BindAudioSourcesClampRange("LoudHorn", __instance.hornClose, __instance.hornFar);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(Landmine), nameof(Landmine.Start))]
    static void Landmine_Start_Postfix(Landmine __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Landmine", __instance.mineAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SteamValveHazard), nameof(SteamValveHazard.Start))]
    static void SteamValveHazard_Start_Postfix(SteamValveHazard __instance)
    {
        KeepItDownPlugin.Instance.BindAudioSource("SteamLeak", __instance.valveAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SpikeRoofTrap), nameof(SpikeRoofTrap.Start))]
    static void SpikeRoofTrap_Start_Postfix(SpikeRoofTrap __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("SpikeTrap", __instance.spikeTrapAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(Turret), nameof(Turret.SetTargetToPlayerBody))]
    static void Turret_SetTargetToPlayerBody_Postfix(Turret __instance) {
        KeepItDownPlugin.Instance.BindAudioSources(
            "Turret",
            __instance.mainAudio,
            __instance.berserkAudio,
            __instance.farAudio,
            __instance.bulletCollisionAudio
        );
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), nameof(VehicleController.Start))]
    static void VehicleController_Start_Postfix(VehicleController __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Horn", __instance.hornAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), nameof(VehicleController.SetRadioValues))]
    static void VehicleController_SetRadioValues_Postfix(VehicleController __instance) {
        KeepItDownPlugin.Instance.BindAudioSourcesClampRange("Radio", __instance.radioAudio, __instance.radioInterference);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), nameof(VehicleController.SetCarEffects))]
    static void VehicleController_SetCarEffects_Postfix(VehicleController __instance) {
        KeepItDownPlugin.Instance.BindAudioSources(
            "Skidding",
            __instance.tireAudio,
            __instance.rollingAudio,
            __instance.skiddingAudio
        );
        KeepItDownPlugin.Instance.BindAudioSources(
            "Engine",
            __instance.vehicleEngineAudio,
            __instance.engineAudio1,
            __instance.engineAudio2
        );
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(NutcrackerEnemyAI), nameof(NutcrackerEnemyAI.TurnTorsoToTargetDegrees))]
    static void NutcrackerEnemyAI_TurnTorsoToTargetDegrees_Postfix(NutcrackerEnemyAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSourceClampRange("Nutcracker", __instance.torsoTurnAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(NutcrackerEnemyAI), nameof(NutcrackerEnemyAI.StartInspectionTurn))]
    static void NutcrackerEnemyAI_StartInspectionTurn_Postfix(NutcrackerEnemyAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSourceClampRange("Nutcracker", __instance.longRangeAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(RadMechAI), nameof(RadMechAI.MoveTowardsThreat))]
    static void RedMechAI_MoveTowardsThreat_Postfix(RadMechAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSources("OldBird", __instance.chargeForwardAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(ClaySurgeonAI), nameof(ClaySurgeonAI.SetMusicVolume))]
    static void ClaySurgeonAI_SetMusicVolume_Postfix(ClaySurgeonAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Barber", __instance.musicAudio2);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), nameof(StartOfRound.Start))]
    static void StartOfRound_Start_Postfix(StartOfRound __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("CompanySpeaker", __instance.speakerAudioSource);
        KeepItDownPlugin.Instance.BindAudioSource("ShipDoor", __instance.shipDoorAudioSource);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(TVScript), "OnEnable")]
    static void TVScript_OnEnable_Postfix(TVScript __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("TV", __instance.tvSFX);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(TVScript), "OnDisable")]
    static void TVScript_OnDisable_Postfix(TVScript __instance) {
        KeepItDownPlugin.Instance.RemoveBindings("Television", __instance.tvSFX.gameObject);
    }
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StormyWeather), "OnEnable")]
    static void StormyWeather_OnEnable_Postfix(StormyWeather __instance) {
        KeepItDownPlugin.Instance.BindAudioSources(
            "Thunder",
            __instance.randomStrikeAudio,
            __instance.randomStrikeAudioB,
            __instance.targetedStrikeAudio
        );  
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StormyWeather), "OnDisable")]
    static void StormyWeather_OnDisable_Postfix(StormyWeather __instance) {
        KeepItDownPlugin.Instance.RemoveBindings("Thunder", __instance.gameObject);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.Start))]
    static void EnemyAI_Start_Postfix(EnemyAI __instance) {
        switch (__instance) {
            case JesterAI jesterAI:
                KeepItDownPlugin.Instance.BindAudioSources(
                    "Jester",
                    jesterAI.farAudio,
                    jesterAI.creatureSFX,
                    jesterAI.creatureVoice
                );
                break;
            case CentipedeAI centipedeAI:
                KeepItDownPlugin.Instance.BindAudioSources(
                    "SnareFlea",
                    centipedeAI.clingingToPlayer2DAudio,
                    centipedeAI.creatureSFX,
                    centipedeAI.creatureVoice
                );
                break;
            case SandSpiderAI sandSpiderAI:
                KeepItDownPlugin.Instance.BindAudioSources(
                    "Spider",
                    sandSpiderAI.footstepAudio,
                    sandSpiderAI.creatureSFX,
                    sandSpiderAI.creatureVoice
                );
                break;
            case CrawlerAI crawlerAI:
                KeepItDownPlugin.Instance.BindAudioSources("Thumper", crawlerAI.creatureSFX, crawlerAI.creatureVoice);
                break;
            case MouthDogAI mouthDogAI:
                KeepItDownPlugin.Instance.BindAudioSources("EyelessDog", mouthDogAI.creatureSFX, mouthDogAI.creatureVoice);
                break;
            case SpringManAI springManAI:
                KeepItDownPlugin.Instance.BindAudioSource("CoilHead",springManAI.creatureVoice);
                break;
            case DressGirlAI dressGirlAI:
                KeepItDownPlugin.Instance.BindAudioSource("GhostGirl", dressGirlAI.creatureVoice);
                break;
            case NutcrackerEnemyAI nutcrackerEnemyAI:
                KeepItDownPlugin.Instance.BindAudioSources("Nutcracker", nutcrackerEnemyAI.creatureSFX, nutcrackerEnemyAI.creatureVoice);
                break;
            case PufferAI pufferAI:
                KeepItDownPlugin.Instance.BindAudioSources("SporeLizard", pufferAI.creatureSFX, pufferAI.creatureVoice);
                break;
            case HoarderBugAI hoarderBugAI:
                KeepItDownPlugin.Instance.BindAudioSources("HoardingBug", hoarderBugAI.creatureSFX, hoarderBugAI.creatureVoice);
                break;
            case RadMechAI radMechAI:
                KeepItDownPlugin.Instance.BindAudioSources(
                    "OldBird",
                    radMechAI.blowtorchAudio,
                    radMechAI.explosionAudio,
                    radMechAI.LocalLRADAudio,
                    radMechAI.LocalLRADAudio2,
                    radMechAI.spotlightOnAudio,
                    radMechAI.engineSFX,
                    radMechAI.creatureSFX,
                    radMechAI.creatureVoice
                );
                break;
            case CaveDwellerAI caveDwellerAI:
                KeepItDownPlugin.Instance.BindAudioSources(
                    "ManeaterScream",
                    caveDwellerAI.screamAudio,
                    caveDwellerAI.creatureSFX,
                    caveDwellerAI.creatureVoice
                );
                break;
            case ClaySurgeonAI claySurgeonAI:
                KeepItDownPlugin.Instance.BindAudioSources("Barber", claySurgeonAI.musicAudio , claySurgeonAI.creatureSFX);
                break;
        }
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(GrabbableObject), nameof(GrabbableObject.Start))]
    static void GrabbableObject_Start_Postfix(GrabbableObject __instance) {
        switch (__instance) {
            case BoomboxItem boomboxItem:
                KeepItDownPlugin.Instance.BindAudioSource("Boombox", boomboxItem.boomboxAudio);
                break;
            case WalkieTalkie walkieTalkie:
                KeepItDownPlugin.Instance.BindAudioSource("Walkie-talkie", walkieTalkie.target);
                break;
            case SprayPaintItem sprayPaintItem:
                KeepItDownPlugin.Instance.BindAudioSource("Spraycan", sprayPaintItem.sprayAudio);
                break;
            case JetpackItem jetpackItem:
                KeepItDownPlugin.Instance.BindAudioSources("Jetpack", jetpackItem.jetpackAudio, jetpackItem.jetpackBeepsAudio);
                break;
            case Shovel shovel:
                KeepItDownPlugin.Instance.BindAudioSource("Shovel", shovel.shovelAudio);
                break;
            case StunGrenadeItem stunGrenadeItem:
                var name = stunGrenadeItem.name.Contains("Egg") ? "EasterEgg" : "StunGrenade";
                KeepItDownPlugin.Instance.BindAudioSource(name, stunGrenadeItem.itemAudio);
                break;
            case WhoopieCushionItem whoopieCushionItem:
                KeepItDownPlugin.Instance.BindAudioSource("WhoopieCushion", whoopieCushionItem.whoopieCushionAudio);
                break;
            case ShotgunItem shotgunItem:
                KeepItDownPlugin.Instance.BindAudioSources("Shotgun", shotgunItem.gunShootAudio, shotgunItem.gunBulletsRicochetAudio);
                break;
            case KnifeItem knifeItem:
                KeepItDownPlugin.Instance.BindAudioSource("Knife", knifeItem.knifeAudio);
                break;
            case SoccerBallProp soccerBallProp:
                KeepItDownPlugin.Instance.BindAudioSource("SoccerBall", soccerBallProp.soccerBallAudio);
                break;
            case ClockProp clockProp:
                KeepItDownPlugin.Instance.BindAudioSource("Clock", clockProp.tickAudio);
                break;
        }
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(ExtensionLadderItem), nameof(ExtensionLadderItem.StartLadderAnimation))]
    static void ExtensionLadderItem_StartLadderAnimation_Postfix(ExtensionLadderItem __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("ExtensionLadder", __instance.ladderAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(NetworkBehaviour), nameof(NetworkBehaviour.OnNetworkSpawn))]
    static void NetworkBehaviour_OnNetworkSpawn_Postfix(NetworkBehaviour __instance) {
        switch (__instance) {
            case ItemCharger itemCharger:
                KeepItDownPlugin.Instance.BindAudioSource("ItemCharger", itemCharger.zapAudio);
                break;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(HUDManager), "OnEnable")]
    static void HUDManager_OnEnable_Postfix(HUDManager __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Scan", __instance.UIAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(HUDManager), "OnDisable")]
    static void HUDManager_OnDisable_Postfix(HUDManager __instance) {
        KeepItDownPlugin.Instance.RemoveBindings("Scan", __instance.UIAudio.gameObject);
    }
}