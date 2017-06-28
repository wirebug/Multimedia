# Documentation

## Project structure
Our project is splitted into two scenes. One for the game menu (*gamemenu.scene*) and one for the game world (*world.scene*)

### World Scene
- __ARCamera__ is holding the perspective of the user looking on the 3D World. Thats why it contains the
  - __Camera__ (camera of the user device)
  - __ShootController__, which contains the
    - __ShootScript__, which defines the shooting logic (incl. animation) and talks to the **_ScoreLogicScript_**. It also uses a line renderer to show a laser animation
  - __CrosshairScript__, which draws the crooshair on the middle of the screen
  - __GameLogicScript__, which initializes the **_ScoreLogicScript_** and manages a blink animation for the **_TimeLeft_**, if it falls under 10 sec.

- __ImageTarget__ represents the QR code needed to scan for displaying the 3D model in the AR-World. Thats why it's holding our
  - __Earth__ model. To the earth model attached are:
    - __SpawnScript__, which is responsible for spawning enemy prefabs randomly on predefined paths. You can also defined how many enemies are spawned at maximum or which duration is between each enemy wave.
    - __TimeLogicScript__, where you can configure the duration of a game session.
  - __Paths__ are defined as simple sets of 3D-Vectors, which for easier handling as an icon attached in the modeling enviroment.

- __Canvas__ is the UI. It contains the
  - __BackButton__ for going back to the main menu
  - __Score__ (text element for the current score)
  - __TimeLeft__ (text element for the time left in the current game session)

- The __ScoreLogicScript__ itself is not attached to anything, but is used by the **_GameLogicScript_** and the **_ShootScript_**. It holds the *current score* of the current game session, the *last score* of the last game session and the *highest score* of all game sessions. Also it __serializes__ the scores (*last* and *highest*) when the game is exited and __deserializes__ the saved scores on starting the game.

The scenes are directly within in the `assets` folder.  
All scripts can be found in the in `assets/scripts`.  
The prefabs for the different ship types are located in `assets/prefabs`.
