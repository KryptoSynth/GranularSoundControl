# GranularSoundControl Changelog

## Unreleased

#### Changed

- Renamed TV to Television
- Changed LethalSettings and LethalConfig to the NuGet package

## 1.6.0 (2024-12-28)

#### Added

- Entries:
  - Coil Head
  - Eyeless Dog
  - Spore Lizard
  - Hoarding Bug
  - Ghost Girl
  - Thumper
  - Nutcracker
  - Barber
  - Company Speaker

#### Changed

- Reverted references from GranularSoundControl to KeepItDown
- Renamed Ship Alarm to Loud Horn
- Mentioned KeepItDown in manifest.json

#### Removed

- Entries:
  - Ship Alarm Cord
  - Old Phone
  - Rubber Ducky
  - Flashlight
  - Radar Booster Ping

#### Fixed 

- Entries:
  - Cruiser Radio
  - Cruiser Skidding
  - Walkie-talkie
  - Jetpack
  - Extension Ladder (semi-fixed)
  - Turret (semi-fixed)
  - Spider
  - Jester
  - Snare Flea
  - Old Bird (semi-fixed)
  - Loud Horn (semi-fixed)

### 1.5.2 (2024-12-18)

#### Changed

- Changed Assembly-CSharp to the NuGet package

#### Fixed

- Cruiser strings

### 1.5.1 (2024-12-18)

#### Changed

- Renamed Steam Valve to Steam Leak

## 1.5.0 (2024-12-18)

#### Added

- LethalConfig categories:
  - Scrap
  - Tools
  - Hazards
  - Entities
  - Cruiser
  - Miscellaneous
  
- Entries:
  - Scrap:
    - Knife
    - Clock
    - Soccer Ball
  - Tools:
    - Shotgun
  - Hazards:
    - Steam Valve
  - Entities:
    - Snare Flea
    - Spider
    - Maneater Scream
  - Cruiser:
    - Horn
    - Radio
    - Skidding
    - Engine
  - Miscellaneous:
    - Ship Door

#### Changed

- Changed references from KeepItDown to GranularSoundControl
- Moved existing entries into categories:
  - Scrap:
    - Remote
    - Dentures
    - Robot Toy
    - Hairdryer
    - Rubber Ducky
    - Whoopie Cushion
    - Clownhorn
    - Old Phone
    - Easter Egg
  - Tools:
    - Flashlight
    - Walkie-talkie
    - Spraycan
    - Jetpack
    - Radar Booster Ping
    - Shovel
    - Extension Ladder
    - Stun Grenade
  - Hazards:
    - Landmine
    - Turret
    - Thunder
    - Spike Trap
  - Entities:
    - Jester
    - Old Bird
  - Miscellaneous:
    - Scan
    - Ship Alarm
    - Ship Alarm Cord
    - Item Charger
    - TV
- Updated libraries:
  - Assembly-CSharp v69
  - LethalConfig 1.4.3
  - LethalSettings 1.4.1

# KeepItDown Changelog

## 1.4.0 (2024-04-16)

- Added 3 volume configs:
  - OldBird
  - SpikeTrap
  - EasterEgg

### 1.3.1 (2024-03-18)

- Fixed error when running without LethalSettings

## 1.3.0 (2024-03-01)

- Added LethalConfig support (limited)
- Added LethalConfig as a  soft dependency
- Made LethalSettings a soft dependency
- Added TV volume config
- Removed API (since it wasn't working anyway)

### 1.2.1 (2024-02-25)

- Added 5 volume configs:
  - Jester,
  - Thunder
  - WhoopieCushion
  - ExtensionLadder
  - Turret

- Improved documentation

## 1.2.0 (2024-02-24)

- Readded search feature
- Added 12 volume configs:
  - Scan
  - Spraycan
  - Dentures
  - RobotToy
  - Hairdryer
  - Jetpack
  - RadarBoosterPing
  - ShipAlarm
  - ShipAlarmCord
  - ItemCharger
  - Shovel
  - RubberDucky
  - Landmine


### 1.1.1 (2024-02-19)

- Added support for adding volume configs to other config files
- Renamed volume config "HUD" to "Scan"
- Removed search feature

## 1.1.0 (2024-02-19)

- Added reset button
- Added XML comments
- Fixed bindings not being removed when GameObjects are destroyed

# 1.0.0 (2024-02-18)

- Released mod
