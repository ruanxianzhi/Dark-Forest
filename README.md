# Dark-Forest
A rapid game prototype


<p>Members:</p>
<ul>Buting Ma,</ul>
<ul>Xianzhi Ruan ,</ul>
<ul>Jie Wang </ul>
<ul> Yihan Li </ul>

Justification of the game

We got the idea from a popular science fiction "The Three-Body Problem" in China. There is a "Dark Forest Theorem" in the book: “The universe has already been filled with civilizations and the universe is a dark forest. Every civilization is a hunter with guns. They are sneaking through the forest like ghosts, trying to carefully hide their traces and keep extremely quiet, because there are numberless other hunters who are as dangerous. If a hunter discovers another hunter, the only choice is to kill him. In the forest, others are hell and eternal threat. Anyone who reveals his exact location is bound to be doomed.” We then want to make this multiplayer game and the players will have limited sight distance, and they will leave traces when they are searching other players. 

In our first prototype, the grid map made the game much less fun. The player could only move and shoot in four directions (right, left, up, backward) and the player hided on the corner of the map could not be found and killed easily. Additionally, players could choose not to scan in the first prototype so that they could always hide in the dark to protect themselves. If all players used the same strategy, they would never meet and as the result, the game would never end.

To solve the first problem, in the subsequent versions, we made the player move and shoot in any directions. Therefore, if an enemy appears in your sight, you can definitely kill that enemy if you want. Moreover, we made the map circular. For example, if you walk through the left border of the map, you will get to the right border directly. In this map, players cannot hide on corners any more. Moreover, the trace that players left will propagate after each turn. With these settings, players can encounter each other more often. 

To solve the second problem, we tried many different ways. In the second prototype, we forced the player to scan at the end of the turn. But this rule made the game less strategic. Eventually, we decided to add the following rules to make the game more balanced. Firstly, players must scan in his/her turn, but they can choose the time to scan within the limitation of steps. Secondly, we give player larger sight distance if they scan. Even more, the earlier the player scans, the farther the player can see. To avoid the possibility that players will all choose to scan at the beginning of their turns, which will give them the largest sight distance, we add a penalty on scanning. In each turn, a player will has a long but still limited distance, which is the “green” distance, to move before the player scans and a short distance, called yellow distance, to move after the player scans. If player runs out of the green distance, the only thing he/she can do is to scan and get the short distance to move. If player chooses to scan before the green distance finishes, he/she will abandon all other green distance and start to use yellow distance directly. In this way, players can change their strategies during the game under different situations.

In the future, we plan to add an item system to encourage players to explore the map more.
