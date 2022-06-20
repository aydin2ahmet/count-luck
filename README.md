# Count Luck

Ron and Hermione are deep in the Forbidden Forest collecting potion ingredients, and they've managed to lose their way. The path out of the forest is blocked, so they must make their way to a portkey that will transport them back to Hogwarts.


Consider the forest as an N x M grid. Each cell is either empty (represented by .) or blocked by a tree (represented by X). Ron and Hermione can move (together inside a single cell) LEFT, RIGHT, UR and DOWN through empty cells, but they cannot travel through a tree cell. Their starting cell is marked with the character M, and the cell with the portkey is marked with a *. The upper-left corner is indexed as (0, 0).

.X.X......X
.X*.X.XXX.X
.XX.X.XM...
......XXXX.

In example above, Ron and Hermione are located at index (2, 7) and the portkey is at (1, 2). Each cell is indexed according to Matrix Conventions.
Hermione decides it's time to find the portkey and leave. They start along the path and each time they have to choose a direction, she waves her wand and it points to the correct direction. Ron is betting that she will have to wave her wand exactly k times. Can you determine if Ron's guesses are correct?

The map from above has been redrawn with the path indicated as a series where M is the starting point (no decision in this case), 1 indicates a decision point and 0 is just a step on the path:

.X.X.10000X
.X*0X0XXX0X
.XX0X0XM01.
...100XXXX.

There are three instances marked with 1 where Hermione must use her wand.
Note: It is guaranteed that there is only one path from the starting location to the portkey.


Function Description

Complete the countLuck function in the editor below. It should return a string, either Ompressed if Ron is correct or Oops! if he is not.
countLuck has the following parameters:
matrix: a list of strings, each one represents a row of the matrix
k: an integer that represents Ron's guess