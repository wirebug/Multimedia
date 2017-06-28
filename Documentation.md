# Documentation

## Project structure
Our project is splitted into two scenes. One for the game menu (gamemenu.scene) and one for the game world (world.scene)

### World Scene
AR Camera is holding the perspective of the user looking on the 3D World. Thats why it contains the Camera (camera of the user device) and the shoot controller which kept the crossair and shooting animation logic.

The ImageTarget represents the qr code needed to scan for displaying the 3d model in the AR-World. Thats why its holding our Earth model.
Earth model is holding the spawn script, which is responsible for spawning enemy prefabs randomly on predefined paths. You can also defined how many enemies are spawned at maximum or which duration is between each enemy wave.
Paths are defined as simple sets of 3D-Vectors, which for easier handling as an icon attached in the modeling enviroment.
On the time logic script you can configure the duration of a game session.

Canvas is the UI. The BackButton for going back to the main menu is here. Furthermore you can find the score and the time is left for the game session.

All scrips can be found in the project assets "scripts" folder.
