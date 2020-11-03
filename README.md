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

#### Graphics Pipeline

As advised in the lectures, the intensive tasks of illuminating the objects and the vertex shader that creates the wave effects are all done in the GPU, so the game can run smoothly. We experimented with buoyancy that would effectively be moving fixed points on the objects in the same manner as the function that displaces the wave. This would make the objects on the water surface behave in sync with the waves and give the illusion of buoyancy. For this, each object has 3-4 points that repeat what the vertex shader does, in the CPU but since it is only a few points in total, compared to every single point like in the vertex shader and illumination, it is not as intensive for the CPU. This effect will be tested and if possible, be implemented before the due date.

#### Camera

As mentioned in the explanation of the game, several camera placements and control options were tested. Among those tested, the main contenders were:

* A fixed camera that looks down at the entire environment.
* A camera that is always in the same spot relative to the player, but can be controlled via mouse movements
* A stationary camera that is in the same spot relative to the player, that always points straight at the player boat

Among these the final option of having the camera move with the boat, and not have independent controls received the best results from testers. This was due to the relative miniature size of the boat compared to the environment being highlighted, as well as the ease of control. Some users expected the camera to be moved with the mouse, as it usually is in most third person games. These users found the gameplay less than ideal but still engaging and playable. More detail about testing and feedback can be found in the Evaluation section.

## Shaders

Two main shaders are used in our game. One is the Phong Illumination Shader, that gives the objects their glossy cartoonish look, and the other is the water shader that gives it the realistic waves effect. Along with the shaders, there are various shaders for clouds and shadows in outdoor levels, and particle effects for steam and fog, as well as effects for when objects get destroyed.

#### Illumination

The Phong Illumination that is implemented in this project is applied to every object and it is based on a Toon Shader that we came across online. This shader gives the objects in the game their glossy, bright look. The inspiration for this illumination style came from the following source: https://roystan.net/articles/toon-shader.html

#### Water

For the water effects, we experimented with texture distortion and waves. Texture distortion has smaller changes in where the height of every point is rendered, compared to waves. In the end we decided to go with waves instead, due to the camera being so close to the player boat. The water shader was not visible enough for the user otherwise. The wave shader used is similar to what our team used in project 1, with a few improvements.

Once again the shader uses Gerstner Waves instead of regular sine waves. This slightly more advanced wave allows for a rolling effect on the water surface, and can easily be combined with numerous other gerstner waves to have a realistic water surface. The wave shader is used across all levels with slight changes depending on the perceived size of the environment. The source of the water shaders we experimented with can be found in the following website: https://catlikecoding.com/unity/tutorials/flow/

#### Particle Effects

The main particle effects that are used in our game are for steam, smoke and explosion rubble. The first two (steam and smoke) are used in the levels to create a better and more engaging atmosphere. The explosion rubble effect is used when enemies are destroyed.

#### Skybox and Clouds

Finally we used a skybox that looks realistic but not too crowded, along with clouds that cast a shadow on the game area. These features are added to have an interesting environment that is not bland and boring while not being too distracting for the player. Since the game is simple, we wanted the visuals and the fact that the player is a miniature boat exploring a large world, be the focus of the game.

## Evaluation

During the development of the game, before the project was finalised, the game was tested by volunteers that were willing to try the game and answer a few questions. Two sessions of evaluations were done, with none of the participants attending both sessions. The first sessions was an Observational Evaluation in the form of an interview with the users. The second session was in the form of a questionnaire, which consisted of 10 questions, and resulted in a score out of 100 for each tester. The following section explains the evaluation method performed, the feedback received, the changes implemented due to the feedback and the demographic of attendees.

#### Observational Evaluation - Interview

The Observational Evaluation was performed on 5 different volunteers. Details on the volunteers like their gender, age, occupation, and how often they play games can be found in the following link, along with the feedback they gave:
https://docs.google.com/spreadsheets/d/15s1P81z5PMBD3wThfoDwGw6tzvZ6cSav_Fd_MvWyszc/edit?usp=sharing

3 out of 5 participant in the observational study were male, and 2 participant were female. Their age average was 27.2. 4 out of 5 claimed they play games daily, and one claimed they play games weekly. The evaluation asked players to play the first two levels of the game, due to the final level not being ready when the evaluation was performed. The participants were asked questions about the level, what their goal was, how they were completing their goal and why they were performing the actions that they were performing. Along with their responses, possible bugs or issues were noted as well.

We preferred this method of observational evaluation due to the simplicity of our game. Such a method might have been difficult if the game required complex actions. Also by answering questions while playing the game, their opinions were fresh and casual. The information gathered at this session shaped some of the key features of the game, and how various aspects such as camera control, speed of the player and movement of enemies were fine tuned.

#### Query Evaluation - Questionnaire

For the Query Evaluation, a questionnaire of 10 questions was prepared. The questionnaire included questions from similar questionnaires that focused on user experience and usability. 5 of the questions were positive and 5 were negative, and each question would be answered with a number from 1 to 5, 1 representing strongly disagree, and 5 representing strongly agree. The data on participants and their feedback can be found in the following link:
https://docs.google.com/spreadsheets/d/1vfUzc1E4kwl1uiQgPP4BZ0X3KmxF5EIeuL662xEXXw0/edit?usp=sharing

With the provided feedback, a total score out of 100 could be calculated for each participant. A total of 10 participants attended the session. None of which had seen the game before. 6 of the participants were Male, and 4 were female. Their age average was 29.9, 3 participants claimed they played games daily, 5 answered weekly, 1 answered monthly and 1 answered occasionally. The lowest score among the participants was 75, and the highest was 100. We assume these scores were biased, considering the attendees were family and friends, and they were aware the game was for a school project. The average score for all 10 participants was **89.75**.

This evaluation was performed later in the games development, so the questions were aimed toward fine tuning some of the features, instead of making big changes. We wanted to see how the game would be received closer to its final form. We decided on a questionnaire due to its ease of use, hoping for a larger number of volunteers to participate compared to the observational evaluation.

## Technologies

The project was created with `Unity 2019.4.3f1`
Various online articles, websites and tutorials were explored during development. The sources of inspiration for the illumination model and shaders were mentioned in detail in the Shaders section.

The models, sounds and UI elements used are all free to use, and the creator is given credit in both the credits section of the game, as well as in the following document:
https://docs.google.com/document/d/1qZcus2QuRUVmayrbVskIxwgNyBjR7xuz6crLTubMabs/edit?usp=sharing
The document also contains two soundtracks from other games that were used in the demo footage that are copyrighted. They were not used in the game, and are only used in the video briefly.

## Contributions of Team Members

During the project, every member took responsibility of different aspects of the project. That isn't to say they were expected to work on that task alone, but that they had final say and governance on that task. Other members were allowed and encouraged to work on the same tasks when needed.

Since the same worked for us in Project 1, the team once again split into two main responsibilities. While Edward and Bixin focused on the gameplay aspects such as the player, camera and enemies; Zhirui and Mehmet focused on building the environments for various levels and the shaders. As mentioned in the Team Members section, each member took responsibility of a task within this division, and we got together to combine our efforts routinely in order to make sure everyone was on the same page.

Toward the end of the project, once the basics of the game was finalised, Edward took responsibility to fine tune the game and polish the game to its final form, with the help of evaluations we received, especially focusing on Enemy AI. Bixin single handedly created the demo video that was required and kept working on perfecting the UI. Zhirui focused on the environment by finalising the shaders, illumination and skybox. And Mehmet focused on the documentation, writing the report and the evaluations.

In the end we are proud of the game we created. All of us wish we had more time to delve deeper into making the game look and feel the way we had envisioned it, but we had to make sacrifices along the way due to time restrictions and other responsibilities. We are aware of some of the aspects that could have been better, and we tried to focus on changing aspects that were not well received during evaluations, while trying to improve upon what testers found enjoyable.
