# Guardians/Assets/src/garrett/
Directory contains code and assets created by Garrett. Below is a summary of features and their functionality. 

# Menu System, HUD, and User Interface
Below are the three general user interface systems and a short description of what functionality will be implemented for each.

| Feature      | Description of Features and Functionality |
| :----------: | :---------------------------------------: |
| Menu System  | Includes implementation of main, settings, and pause menus with options and functionality to control game play. Users will be able to change game state (start, stop, or pause) and interact with game graphics and audio settings. | 
| Heads-Up-Display (HUD) | Provides modular features for conveying information to the player through UI elements while playing in game. Simply put it will contain health and other basic information. | 
| Inventory UI | Allow players to view information about the items they have collected during the game. | 

Each system should consists primarily of gameobjects connected through a series of simple scripts that manage their visibility and state. The HUD will be implemented through a series of scripts inheriting characteristics and functionality from `HUDElement.cs` which will implement the base functionality of hiding and showing the element, initializing it's state, and various other features.