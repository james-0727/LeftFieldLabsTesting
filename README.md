# Left Field Labs: Unity Engineer Take Home

## Pumpkin Shooter

Currently using Unity 2020.3.0f1

1. Data I/O:
	Informations for start menu fields (title and version) are synced with below json file
	Assets/StreamingAssets/Data.json

2. Start Menu:
	- All fields are filled in from data.json file (Title & version number)
	- The play button loads the game scene
	- High score is tracked between sessions

3. Game Scene:
	- Pumpkin prefabs spawn again once they are killed & disappeared
	- Shooting a pumpkin causes the socre to increase and high score UI
	- Game session length and indexes of spawning pumpkin are  synced from data.json file
	- Spawned cannon ball and dead pumpkin prefab destroys after 3 to 5 seconds
	- Made game over UI worked
		* Stop current game play when its pop up
		* Play again button will let you play again
		* Load main menu button will load start menu

4. Polish tasks:
	- Added VFX effect when cannon hitting an enmy and the ground