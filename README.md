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

Explanation of UI and controls in general

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

A description of the contributions made by each member of the group. Briefly mention the contributions of team members.
