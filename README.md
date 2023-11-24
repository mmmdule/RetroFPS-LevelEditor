# RetroFPS-LevelEditor

Level Editor desktop app for my [RetroFPS game](https://github.com/mmmdule/RetroFPS).

The app allows map creation with many customization options. Configure each level's layout, textures, enemy and pickup placement and much more with great ease.

Created using C# and .NET 7.

## Features
- Graphical grid display of map layouts
- Simple and accessible user interface
- Parameter customization (health, patrol range, damage...) for every object on the map
- Map grouping into Level Editor Projects.

## Playing/Testing level pack
To play levels from a project created using the Editor, place the project's **_.lep_** file and "**_/maps/_**" folder into the game's "**_PandemoniumFPS_Data_ > StreamingAssets**" directory.

# User Manual
The following section will cover creating a new project, opening an existing one and editing levels inside a project.

## Creating and opening a project
### Creating a project

![image](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/cc32e8aa-1fdb-4e9c-8c42-87df18f0e5b4)

Creating a new project is a two-step process:
- On the Home window, click the **"Create New Project"** button in the _Getting Started_ section.
- Next, enter the project's information. **_Project Name_** and **_Path_** are the only mandatory fields.

_Note: All of the project info (project name, game title, subtitle and author) except the project path can be edited later in the **Project View**_

When a project is created, the app will create a Project Directory in the path the user selected.
This directory will contain two items:
- A **.lep** (_Level Editor Project_) file, which contains the project data
- A **/maps/** sub-directory, which will contain **.lem** (_Level Editor Map_) files which contain level and story data

### Opening an existing project
To open an existing project, click the **"Open Project"** button in the _Getting Started_ section.\
Find the project's **_.lep_** file and select it to open the project.

The **_.lep_** file you selected must be in the same directory as the **/maps/** directory. Otherwise, an error will occur when trying to open a level or story segment.

**_Any time a project is created or opened it will be added to the top of the "Recent projects" list in the Home window._** 

## Editing Levels and Story
**Levels** (_gameplay segments_) and **Story Segments** are both added to the project's Maps section, and are both considered as Maps.\
Story segments are always shown to the player after a level. If you put one on the top of the Maps list, the player will not be able to access it.

![image](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/0b75dfb2-38d9-4946-a03a-13432fb19ffe)

### Adding/Removing a Map
To add a Map, click the green '+' button in the **Project View** and then add the level's name and type.

To remove a Map, click on a Map and then click the red '-' button.\
Deleting a Map deletes the map file, so you should make a backup to prevent data loss.

Maps can be reordered using the arrow buttons next to each map's name.\
A map can be move one place up or down, or to the top/bottom of the list.

### Editing Levels
To edit a level after adding it, double click on the segment's name in the Map list.\
This will open the grid window in which the level's layout and object properties can be customized.

![image](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/847014a4-2182-4dc4-971f-a1e312927c41)

When in **_Draw Mode_**, to draw on the grid, use the left mouse button. To erase, use the right mouse button.\
To edit an object's properties choose **_Select Mode_** and click on that object on the grid. When entering a value, press Enter to confirm input.

The bottom toolbar contains brushes (object types) you can use to draw on the map.\
Brushes displayed can be changed in the toolbar in **View > Brushes**.\
The following brush types can be chosen:
- **Walls** (_Regular_ and _Cobweb Walls_)
- **Enemies** (_Imp, TriHorn_ and _PlasmaEater_)
- **Map Objects** (_ExitDoor, Key, DoorGate, EnergyBall, Torch, ArmorBlink, Stone, ArchwaySingle_ and _ArchwaySmall_)
- **Pickups** (_SmallMedkit, ShotgunAmmo, smgAmmo_ and _Bullets_)
- **Player**

### Player
![player](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/68f37fbe-c9b5-44ed-9775-276a38e427de)\
Player must be added to be able to start the level in-game.

The player object has multiple parameters that can be edited:
- **Starting Health** (_Max Health is 100 during a level, but Starting Health can be above 100_)
- **Weapon ammo** (_Ammo for the Revolver, Shotgun and Uzi can each be set_)
- **Weapon Possession** (_Check the boxes for the weapons you want the player to have during a level_)

### Walls
Wall brush texture can be chosen in the toolbar in **Wall Brush**.\
![image](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/f80f01be-f7e7-492b-9fd7-00c6b3cef621)

Border wall texture can be chosen in the toolbar in **Map Settings > Border Wall Texture**

### Enemies
![imp](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/7e6b5e13-8a69-4833-8c94-31c937a720f8)\
**Imp**
- Slowest enemy type
- Fires 1 projectile when attacking

![trihorn](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/0bd0c4d7-d439-426e-b132-ba1d78679de7)\
**TriHorn**
- Faster than Imp
- Fires 3 smaller projectiles (_damage inputed is divided by 3 for each projectile_)

![plasmaEater](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/c0e267e9-df2b-4c1e-9492-b215756fc617)\
**PlasmaEater**
- Same speed as TriHorn
- Fires 4 smaller projectiles (_damage inputed is divided by 4 for each projectile_)
- Gains +60HP when shot with Uzi's plasma ammo (_hence the name_) and increases slightly in size.

**ENEMY PARAMETERS**
Enemy behaviour and attributes can be modified with the following parameters:
- **Health**
- **Projectile Damage**
- **Time Between Shots** - Pause between enemy attacks in seconds
- **Patrol Range** - Radius inside which the enemy will pick next patrol target point randomly
- **Sight Range** - Range from which enemy can detect Player if no obstacles are between them (_if the player is detected, the enemy will start chasing him_)
- **Attack Range** - Range from which enemy will attack Player if no obstacles are between them
- **Can Move** - Enables/Disables enemy movement

### Map Objects
Map Objects are divided into two categories:
1. Keys and Doors
2. Decorations and Traps

Use of decorations is encouraged to help the player navigate the map easier.

![MapObjects](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/4acb739a-1d52-4c89-8d4c-47d19dee38d0)\
(items are listed in same order as image)

**Keys and Doors**
- **ExitDoor** - ends the level (_place above player on map so player enters from underneath on the grid_)
- **Key**      - unlocks DoorGate so player can progress (_only one key per level_)
- **DoorGate** - blocks part of map away (_only one key per level_)

**Decorations and Traps**
- **EnergyBall**     - small brick surrounded by energy balls that do 8HP damage upon contact
- **Torch**          - light source
- **ArmorBlink**     - possesed piece of armor, blinks at you if you stare long enough
- **Stone**          - spawns one of the pebble sprites (_randomly chosen_)
- **ArchwaySingle**  - column with arch on top
- **ArchwaySmall**   - smaller column with arch on top

### Pickups
Pickups restore the players heatlh and ammo.
The value of each individual pickup can be edited.

![Pickups](https://github.com/mmmdule/RetroFPS-LevelEditor/assets/113645355/0e15414d-91b9-49e1-a831-0f8a0da6f50b)\
(items are listed in same order as image)\
There are 4 types:
- **Health**
- **Shotgun Shells**
- **Plasma Ammo** (_for the Uzi_)
- **Bullets** (_for the Revlover_)

### Editing Story Segments
To edit a story segment after adding it, double click on the segment's name in the Map list.


### Keyboard shortcuts
- **Ctrl + S** - Save (_in Grid and Story Editor mode_)
- **Ctrl + W** - Close (_in Grid and Story Editor mode_)

- **D** - Draw Mode (_in Grid Mode_)
- **S** - Select Mode (_in Grid Mode_)
- **MouseWheel Up/Down** - Scroll Up/Down (_in Grid Mode_)
- **Shift + MouseWheel Up/Down** - Scroll Left/Right (_in Grid Mode_)
- **Ctrl + MouseWheel Up/Down** - Zoom In/Out (_in Grid Mode_)
- **MouseWheel Click** - Toggles Mouse Movement scrolling (_in Grid Mode_)
