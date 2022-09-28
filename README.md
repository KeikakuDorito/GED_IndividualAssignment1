
# INFR 3110U – Individual Assignment 1
Nathan Woo - 100787454

The purpose of this assignment was to demonstrate our engagement in the laboratory activities and to explain how the material learned inside these labs will assist us in the creation of the course project.

3D Models and Animations can be Attributed to Quaternius using the "Platformer Game Kit": https://quaternius.com/index.html

**The work done leading up to week 2 can be found in the _Scene Folder_ as _"Week2Scene"_**

## Week 1
During week 1 of labs, we were introduced to several basic features. Using a premade Game Asset kit, we were shown how to import FBX models into Unity. As these models contained animations used Unity's built in animation editor to give the player model that we were using a brief loop between the idle and walking animations. We were shown how to use Unity's extremely usefulp Input Action editor, which allows us to creation certain actions and easily assign different inputs towards them. Personally, my takeaway from this lab was the use of the Input Editor to control events inside scripts rather than have a block of code built for each input.

## Week 2
On week 2 we expanded on the project we started during week 1, implimenting general player movement in 2 directions (back and fourth on one axis), jumping and shooting mechanics on the player controller, a singleton pattern Score Manager class and briefly started on a Editor Mode.

The score manager was used for us to create coins in which the player can touch and interact. The score manager was a single-instanced globally accessible class (singleton pattern), meaning that the coin script was able to call the instance of ScoreManager and use the function to change the score value.
Before running out of time, we were also working on a Editor Class that allows us to swap between cameras and place objects, however only the camera switching was fully implimented during the lab time.

## Base project
Expanding on the progress done in labs, we were tasked to use the materials we learned in the labs to create a mini game level. We were to add some new features and had the choice to edit the player controller.

I expanded onto this by making it a 2D Platformer Shooter game. 


The new features that I added were:
- Player Animations based on actions
- The player now changes the direction they are facing depending on input
- Health System, with a heart pickup to increase Health
- A simple enemy that damages the player when they collide with it 
- Destroyable, pushable wooden boxes
- More platforms and aesthetics