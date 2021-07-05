

# Container Organiser

Container Organiser is an algorithm challenge where the goal is to sort an adjustable list of containers on a ship of adjustable size.

![](https://i.imgur.com/U2Z76aA.png)

## Constraints 

The ship needs to meet the following requirements:

-  The maximum weight on top of a container is 120 ton (or adjustable).
-  A full container weights a maximum of 30 ton (or adjustable). 
-  An empty container weights 4 ton (or adjustable).
- Containers can be regular, valuable, cooled or valuable + cooled. 
- Nothing may be stacked on top of a valuable container. Valuable containers may be stacked on top of other containers.
- Valuable containers must be accessible through the front or back. You may assume that containers that are stacked on top of others are accessible.
- All cooled containers need to be placed in the front row of the ship, because the power supply is located at the front end of the ship.
- To prevent capsizing at least 50% of the maximum weight of the ship needs to be utilised.
-  The ship needs to be in balance: the weight of the containers of each side may not differ more than 20% of the total load.
- The size of the ship needs to be adjustable, where you can specify the width and length.


## Personal Goals

I created the container organiser algorithm in my second semester. I wanted the code  to be split into small functions to comply with the single responsibility of the SOLID principles.

If the sorting is impossible the code has to throw a custom exception. If all goes well the code opens a new window in google chrome.

The calculated setup is rendered in unity using an existing visualisation tool of Jan Oonk


