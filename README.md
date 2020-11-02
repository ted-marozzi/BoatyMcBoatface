**The University of Melbourne**
# COMP30019 – Graphics and Interaction

This is Project 2 - Unity Game for COMP30019 Graphics and Interaction.
The game is called "The Adventure of Mr. Boaty McBoatface".
A gameplay video and demo of the game can be found in the following link:
https://www.youtube.com/watch?v=FDcy9M_bOSY&t=1s

# Project-2 README

## Table of contents
* [Team Members](#team-members)
* [Explanation of the game](#explanation-of-the-game)
* [How to Guide](#how-to-guide)
* [Objects and Entities](#objects-and-entities)
* [Graphics Pipeline and Camera](#graphics-pipeline-and-camera)
* [Shaders](#shaders)
* [Evaluation](#evaluation)
* [Technologies](#technologies)
* [Contributions of Team Members](#contributions-of-team-members)

## Team Members

| Name | Task | State |
| :---         |     :---:      |          ---: |
| Edward Marozzi  | Enemies & Enemy AI     |  Done |
| Bixin Li    | Player Controls & Camera      |  Done |
| Zhirui Xin    | Environments & Scenes      |  Done |
| Mehmet Koseoglu    | Water Effects & Documentation/Evaluation      |  Done |

## Explanation of the game

Mr. Boaty McBoatface, is a third person shooter that consists of three levels. In the game, the player controls a small toy boat, that can move around with the `WASD` buttons, and shoot cannons by pressing the `SPACE` button. The Camera is in a fixed position with respect to the boat, and rotates with the boat when the boat turns.

In the initial level, the boat is inside a bathtub in a bathroom, and it gets attacked by rubber ducks. The player needs to survive for a set amount of time to pass the level. The player can also shoot the ducks in order to survive. When the timer ends, the first level ends, and the next level begins.

In the second level, the boat is located in a big pool. This gives the player more room to play in. There are also the addition of enemy ships, which are programmed to shoot when they are a predetermined distance away from the player. If they are far away, they try to move towards the player. The player needs to survive without running out of health.

In the final level, the boat is located in an ocean and it is fighting against a giant rubber duck. This is the final boss of the game that the players will need to defeat in order to complete the game.

The game went through a few iterations with respect to how the player should move, how the camera should behave, and what the levels should look like. We experimented with various controls such as a free moving cam that can be controlled with the mouse, that is always in the same spot with respect to the ship. A stationary camera above the game environment was also tested. We found that a fixed camera that rotates with the ship was the most intuitive and fitting for the simplicity of the game.

We wanted to keep the controls simple. We considered side cannons for the player ship and the enemy ships, but this was not implemented due to increased difficulty when aiming. Instead the ships shoot from their fronts.

Along with gameplay changes, various graphical changes were also implemented, such as: how the water should behave in different environments to make it realistic but still fitting the cartoonish style of the game, and adjusting the detail present in the environment so the player sees the world through the eyes of a toy ship while not having too much detail that would slow down the game.

These changes were made either due to the evaluations the game received, or internal testing. The final implementation of each of these components will be discussed further in the following sections, as well as a brief overview of the evaluations received that caused various changes.

## How to Guide

When the game starts, the player sees the main menu screen, which consists of an exit button on the left and a start button in the middle. Other than these two buttons, there is also a credits button that takes the player to the credits screen, and a level select button so players can enjoy different levels again. The start button initiates the first level of the game. A brief explanation of the buttons is introduced when the game starts, At any time players can quit the game and go back to the menu screen. When a player completes the game, they see the end screen where they can choose to go back to the main menu.

The controls are explained before the first level starts. The boat can move forward by pressing `W`, `A` and `D` make the boat turn simultaneously with the camera, so the camera always looks straight at the boat. When the `SPACE` button is pressed, a cannon fires straight from the boat, going in a straight line, affected by gravity. If this cannon collides with an object the cannon is destroyed. And if the object was an enemy, the enemy also gets destroyed.

As mentioned in the introduction, various control methods were considered for the game, including additional buttons for various actions such as speeding up, cannons that possibly face the sides instead of forward, complex cannon controls and alternative methods for controlling how the boat turns, such as turning by moving the mouse (like in most 3rd person games), or independent camera controls through mouse movements. In the end the most simplistic control method was preferred due to how intuitive it was during testing, and how it fits the simple and cartoonish aesthetic of the game.

## Objects and Entities

The objects and entities in the game can be grouped in two categories, the ones that form the **environment** such as the interior of the bathroom in level 1, or the buildings and trees in level 2, and the ones that are **mobile objects** such as the player boat, ducks and enemy ships.

All of these 3D objects and entities were either found online if they were free to use, or were created using 3D modelling tools. The environment objects such as the bathtub and pool create a boundary for the player to move in due to having colliders, while the rest of the environment objects are low detail objects that make the levels look good that are not interact-able. The player boat, ducks and ships all have colliders that keep them from moving beyond the borders of the game. These objects are also bound by the scripts that define their movement, ability to shoot, and health where relevant.

All of the objects in the game use a Toon Shader that gives the objects a cartoonish look and gloss in order to fit the theme and look of the game. Water also has a cartoonish look, that is not strictly realistic, but still has realistic looking waves and some transparency.

Objects like the enemy ships and ducks can collide with the player boat, which causes the player to lose health. They can also be destroyed by cannon fire. Cannon balls are entities that are shot from ships, they get destroyed when they collide with another object, if the object is the player boat, it loses health. If cannon balls hit the ducks or the enemy ships, they get destroyed.

The camera entity will be explained in detail in the following section.

## Graphics Pipeline and Camera

Graphics Pipeline? Details on camera

## Shaders

Two main shaders are used in our game. One is the Unity Toon Shader, that gives the objects their glossy cartoonish look, and the other is the water shader that gives it the realistic waves effect. The shaders work with the Phong illumination model. Along with the shaders, there are various particle effects for when objects get destroyed, or fog effects in various environments.

Explain shaders and illumination in detail

## Evaluation

Description of the querying and observational methods used, including: description of the participants (how many, demographics), description of the methodology (which techniques did you use, what did you have participants do, how did you record the data), and feedback gathered.

## Technologies

A statement about any code/APIs you have sourced/used from the internet that is not your own
talk about the shaders found online, how waves were implemented, models that were found online etc.

Project is created with:
* Unity 2019.4.3f1

## Contributions of Team Members

During the project, every member took responsibility of different aspects of the project. That isn't to say they were expected to work on that task alone, but that they had final say and governance on that task. Other members were allowed and encouraged to work on the same tasks when needed.

Since the same worked for us in Project 1, the team once again split into two main responsibilities. While Edward and Bixin focused on the gameplay aspects such as the player, camera and enemies; Zhirui and Mehmet focused on building the environments for various levels and the shaders. As mentioned in the Team Members section, each member took responsibility of a task within this division, and we got together to combine our efforts routinely in order to make sure everyone was on the same page.

Toward the end of the project, once the basics of the game was finalised, Edward took responsibility to fine tune the game and polish the game to its final form, with the help of evaluations we received, especially focusing on Enemy AI. Bixin single handedly created the demo video that was required and kept working on perfecting the UI. Zhirui focused on the environment by finalising the shaders, illumination and skybox. And Mehmet focused on the documentation, writing the report and the evaluations.

In the end we are proud of the game we created. All of us wish we had more time to delve deeper into making the game look and feel the way we had envisioned it, but we had to make sacrifices along the way due to time restrictions and other responsibilities. We are aware of some of the aspects that could have been better, and we tried to focus on changing aspects that were not well received during evaluations, while trying to improve upon what testers found enjoyable.
