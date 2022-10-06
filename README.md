# GAME208_Lab3
Lab3 for GAME208 where we learn about game development with Unity.
This lab is focusing on the Animator and how to use already created models in a 3d game.

Game starts with a main menu where the player can start the level.
On the level the player is in third person view and the red marker in front of it is the enemy spawning point.
The player can spawn three different enemies to the map with the numpad1-2-3 buttons.
The enemies will stand idle with animation and the player can shoot them with three types of attack:
Mouseclick; leftcontrol + mouseclick; leftalt + mouseclick. Only the animation is different.
The enemies can be damaged if the bullet is hitting them and a damage animation will play. If the enemy reaches 0 health it will die with a death animation and after the animation is complete, the enemy's gameobject will be destroyed.
