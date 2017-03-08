# satellites
CS426

Satellites is a strategy game based on a hexagon map. It tells a story of a planet travelling around the space to collect satellites.

Basic mechanics of the game:
At the beginning of the game, the player will be given a target(e.g. collect 3 green satellites to gain the color green). Then the player start to move the planet, each round we can either move 1 step or stay.

both satellites and planet stays in the center of map units.

If the planet moves to the map unit adjacent to a satellite, and stay for a while, say 1 sec, the satellite is collected.

The collected satellites will rotate around the planet in the adjacent map units periodically, e.g. 1 map unit per sec.

if the collected satellites shares the map unit with the new satellites, collision happens, both of them disappear.

if the target is achieved, then victory.

Level set:
we can set several levels based on the following parameters:
1  the difficulty of the target, e.g. the number of satellites with the same color to collect;
2  AI obstacles;
3 the map construction, e.g. second floor;
