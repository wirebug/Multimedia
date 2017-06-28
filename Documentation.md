# Documentation

## Setup
Unity 5.6.1
Vuforia 6.2

## Project structure
Our project is splitted into two scenes. One for the game menu (*gamemenu.scene*) and one for the game world (*world.scene*)

### World Scene
- __ARCamera__ is holding the perspective of the user looking on the 3D World. Thats why it contains the
  - __Camera__ (camera of the user device)
  - __ShootController__, which contains the
    - [__ShootScript__](Assets/Scripts/Shoot.cs), which defines the shooting logic (incl. animation) and talks to the [**_ScoreLogicScript_**](Assets/Scripts/ScoreLogic.cs). It also uses a line renderer to show a laser animation
  - [__CrosshairScript__](Assets/Scripts/Crosshair.cs), which draws the crooshair on the middle of the screen
  - [__GameLogicScript__](Assets/Scripts/GaneLogic.cs), which initializes the [**_ScoreLogicScript_**](Assets/Scripts/ScoreLogic.cs) and manages a blink animation for the [**_TimeLeft_**](Assets/Scripts/GameLogic.cs#L50), if it falls under 10 sec.

- __ImageTarget__ represents the QR code needed to scan for displaying the 3D model in the AR-World. Thats why it's holding our
  - __Earth__ model. To the earth model attached are:
    - [__SpawnScript__](Assets/Scripts/SpawnScript.cs), which is responsible for spawning enemy prefabs randomly on predefined paths. You can also defined how many enemies are spawned at maximum or which duration is between each enemy wave.
    - [__TimeLogicScript__](Assets/Scripts/TimeLogic.cs), where you can configure the duration of a game session.
  - __Paths__ are defined as simple sets of 3D-Vectors, which for easier handling as an icon attached in the modeling enviroment.

- __Canvas__ is the UI. It contains the
  - __BackButton__ for going back to the main menu
  - __Score__ (text element for the current score)
  - __TimeLeft__ (text element for the time left in the current game session)

All scripts can be found in the in [Assets/Scripts](/Assets/Scripts).  
The prefabs for the different ship types are located in [Assets/Prefabs](/Assets/Prefabs).

### ScoreLogicScript
- The [__ScoreLogicScript__](Assets/Scripts/ScoreLogic.cs) itself is not attached to anything, but is used by the [**_GameLogicScript_**](Assets/Scripts/GameLogic.cs) and the [**_ShootScript_**](Assets/Scripts/Shoot.cs). It holds the *current score* of the current game session, the *last score* of the last game session and the *highest score* of all game sessions. Also it [__serializes__](Assets/Scripts/ScoreLogic.cs#L44) the scores (*last* and *highest*) when the game is exited and [__deserializes__](Assets/Scripts/ScoreLogic.cs#L60) the saved scores on starting the game.

### Game Menu Scene
- __SF Scene Elements__ is holding the camera for the view on the start menu as well as the background of the menu
- __Canvas__ within this are all elements for interaction and information
  - [__InitStartMenuScript__](Assets/Scripts/InitStartMenu.cs): Initializes the [**_ScoreLogicScript_**](Assets/Scripts/ScoreLogic.cs) to load (deserialize) previously saved (serialized) scores
  - __MainMenuPanel__ includes the buttons for Start, Credits and Exit
  - __CreditsPanel__ is activated when clicked on "Credits" and shows all names of the developers
  - __Scores__ displays the last and the high score from the [**_ScoreLogicScript_**](Assets/Scripts/ScoreLogic.cs)

The scripts and textures for the menu are located in [assets/game menu](Assets/Game%20Menu)

Both scenes are directly within the [assets](/Assets) folder.  
