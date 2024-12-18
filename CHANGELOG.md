# Changelog

## 1.5.0 (2024-12-18)

### Added

- LethalConfig categories:
  - Scrap
  - Tools
  - Hazards
  - Entities
  - Cruiser
  - Miscellaneous
  
- New entries:
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

### Changed

- Changed all references from KeepItDown to GranularSoundControl.
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
