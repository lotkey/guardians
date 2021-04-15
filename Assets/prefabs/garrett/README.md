# Guardians/Assets/prefabs/garrett/
This directory contains prefab assets created by Garrett Wells. Below are the assets in this folder, a short description of how to use them, and and what they do.

## Settings_Panel
---
This prefab contains the settings menu for the game and can be dropped into any scene to provide a settings menu that can access sound management, video quality, and window settings.

#### Dependencies
References `SoundManager.cs` and `MusicManager.cs` which should be attached to some GameObject in the scene.

#### Installation
Drag and drop the prefab into the scene. No further configuration should be needed.

## Resources/HUD_Canvas
---
The HUD Canvas provides the HUD display for players in the game. It contains the health bar, player inventory, and pause menu.

#### Dependencies
Requires `GameManager.cs` and the Unity TextMeshPro package.

#### Installation
Drag and drop into a scene.

## Resources/InventoryUI_Icon
---
An instantiable prefab that displays a weapon in the inventory panel.

#### Dependencies
None.

#### Installation/Usage
Use the lines of code below to add a new instance of the GameObject to the inventory and set it as a child of the inventory panel.

    GameObject newEntry = Instantiate(inventoryIcon_Prefab) as GameObject;
    newEntry.transform.SetParent(inventoryPreview_Panel.transform);
    newEntry.transform.localScale = this.transform.localScale;

This should be done automatically by HUD_Canvas `InventoryUIManager.cs` in the prefab above.

## Resources/Sword_drop
---
A template for item drops in the game, can be modified by users to drop different weapons. Merely needs to be instantiated like the prefab above to be used. Requires the user to attach an instance of the scriptable object Inventory Item.
