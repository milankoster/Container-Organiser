Container-Organiser was an algorithm challenge in which the goal was to sort an unknown list of containers on a container ship with an unknown size.

Cooled containers needed to sorted on the front of the ship, whereas valuable containers needed to be at the front or back, but only in the highest spot.
The ship needed to remain balanced with a maximum left/right difference of 60/40 to refrain it from tipping over. 
If more than 120kg was placed on top of a container it would collapse.  

The main goal was split the code into small functions to comply with the single reposibility of the SOLID principles.

If the sorting is impossible the code throws a custom exception. If all goes well the code opens a new window in google chrome.
The calculated setup is rendered in unity using an existing program of Jan Oonk
