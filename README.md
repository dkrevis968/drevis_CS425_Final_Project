# drevis, CS425 Final Project

This is a prototype of my final game project, named *Sneaky Snake*.

## Video Demo
https://youtu.be/SRYng0taj-w

## Description
The player is a snake that is attempting to escape a huge lab where it has been experimented on for years. It is on the top floor of the building and must reach the door to the stairs on each floor (level) to escape to the next floor. Each floor is full of walls and obstacles the snake must get by to reach the objective. There are scientists that are patrolling each floor though that the snake must escape from and avoid.

## Technical Components
The main technical component I used for this project were Behavior Trees. I created a few nodes (sequence, selector, task) and implemented a simple behavior tree. I also created some basic behavior for the scientists similar to my submission for PA04. The files are located under Assets/Scripts/.
I also used Unity's built-in NavMesh for navigation, but I know that doesn't exactly count.
