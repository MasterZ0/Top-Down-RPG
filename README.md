# Top Down RPG

## Character Customizations

The main features is Character Skin Customization. The character's body is composed of several sprites, which allows players to change the appearance of their characters through items.
 
 <div class="row" align="center">

![customization](https://user-images.githubusercontent.com/64444068/234120382-c1d02e8d-3e97-49c2-8aab-26b452597597.gif)
 
</div>
 
A shader has been implemented to dynamically change the colors of each sprite, enabling to create even more item variations with fewer cost.


![image](https://user-images.githubusercontent.com/64444068/234126964-e7f34530-0fe7-4c79-94ba-374dbbd22278.png)


<div class="row" align="center">

<img src="https://user-images.githubusercontent.com/64444068/234126895-125d246c-94f8-4a5f-afe8-18593625d389.png" width=49% height=300px style="margin-right: 10px;">

<img src="https://user-images.githubusercontent.com/64444068/234126869-4e287795-d7d2-4b27-b7c4-b7aaf20a044b.png" width=49% height=300px >
 
</div>


## Inventory

The prototype also includes a UI Inventory with Drag and Drop functionality, which allows players to manage their inventory easily.

![hat](https://user-images.githubusercontent.com/64444068/234120391-e25b2f90-46a8-4d28-8b83-4c39b2dcc372.gif)

## Shop

The game includes a shop where players can buy and sell items.

![image](https://user-images.githubusercontent.com/64444068/234121226-76a03f11-e3bf-41a2-8f60-7fb2dccfa18c.png)

## Basic Interactions

Players can interact with other characters and display messages.

![image](https://user-images.githubusercontent.com/64444068/234121410-9fa1e604-d2af-4af2-bf0d-d9d1558685b6.png)

## Plugins

Included some personal libraries that I created.

- UI Builder: Used to draw a game design screen and facilitate asset access
- Object Pool: Simple to use code and optimizes the game

![image](https://user-images.githubusercontent.com/64444068/234124080-c7506f5c-d601-4bd8-816d-b1edb420657b.png)

![image](https://user-images.githubusercontent.com/64444068/234123985-88b11a21-a48f-4989-8098-795006d8afbd.png)

All Scriptable objects is located in this folder

![image](https://user-images.githubusercontent.com/64444068/234132268-46364510-98de-46d5-8df1-7f4993c5f4b1.png)

## Scripts

Resume: The most important are Character and UI. The others are very simple.

### AI

Used to control input from Characaters NPCs. They have basic movement and interaction behaviors.

![image](https://user-images.githubusercontent.com/64444068/234130336-c03387d9-a02b-4421-9fd7-3cb864b726d3.png)

### Application

Just the quit button in an organized folder

### Character

Here, where most of the code is concentrated, is an architecture based on Unreal's Pawn. Both the player and the AI will own the body of a Character, and it will be responsible for managing the inputs of its controller, including Physics, Inventory Animation and Sprites.

![image](https://user-images.githubusercontent.com/64444068/234130980-ef0691c0-ee40-4bba-a2f3-736126b72c6e.png)

### Editor

Class to display the game's scriptable objects and a tool I created to facilitate the inclusion of components in prefabs.

### Inputs

Integration with the unity input system used in the player

### Items

Scriptable objects and fields, will be interpreted mainly by Character and UI.

### Player

Character controller that uses the input. They also have references of the UIs used by the player

### Shared

Asset paths for Scriptable Objects and a generic class used in CharacterController

### UI

Interface that allows the player to manipulate data from controllers such as the store and inventory
