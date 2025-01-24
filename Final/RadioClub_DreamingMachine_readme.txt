i. Starting scene file 
Scenes/GameScene: 
User name: player
Password: 1234
ii. How to play and what parts of the level to observe technology requirements 
Level1: 
Gameplay Overview and How to play:
* This level primarily serves as a tutorial level and will introduce the user into basic movement as well as various interactables throughout the game
* The goal is to get the key and obtain enough collectables to level up to proceed to the next level.
* There are a few puzzles and interactables the user must complete in order to proceed but they are relatively straight forward.
* Since this is a tutorial level, there are pressure plates around the map to guide the player.
Controls:
* Movement: USE WASD
Key Features:
* Pressure plate and moving objects puzzle
* Wall climbing powerup and mechanic
* Collectable spheres
Level2:
Gameplay Overview and How to play:
* In this level, the player will enter a colonial city scene.
* The goal is to collect ALL 6 Yellow craves before you consume all the power; When a robot touches Yellow crave, they will just disappear.
* Try avoiding those moving obstacles The robot will lose 10% power if touch them
* The robot can charge 50% more power from the power station when you have 3 or less craves left, but you can only charge once in this level
* After collecting all the craves, run to the black pillar for the next level. You can jump to the next level only if you collect all the yellow craves.
Controls:
* Movement: Use WASD to move.
* Use esc button to restart game or quit game or see the instruction panel
Key Skills of the Level:
* Strategic Thinking: Managing power levels while prioritizing grave collection and avoiding obstacles.
* Timing and Precision: Avoiding moving obstacles and interacting with graves effectively.
* Navigation Skills: Exploring the map to locate graves and understanding the layout for efficient gameplay.
* Resource Management: Balancing power decay with recharge opportunities at the charging station.


Level3:
Gameplay Overview:
In Level 3, the player continues their journey as a robot, tasked with testing their patience and sensitivity in a new challenge. The player must survive for 60 seconds in a confined area while avoiding roaming enemy robots. Once the timer is up, the exit door will open, and the player can proceed to the final NPC to complete their mission.
The level is designed to push the player's ability to stay alert and strategic, avoiding enemy robots while managing their position in the room.


Controls:
* Movement: Use WASD to move the robot around the room.


Objective:
* Survive for 60 seconds while avoiding enemy robots.
* Once the timer ends, the glass door will disappear, allowing the player to exit the room.
* Reach the final NPC to complete the level.


 Key Features of the Level:
* Enemy Robot AI:
   * Patrolling Behavior: The enemy robots roam the room randomly, creating dynamic obstacles for the player.
   * Collision Penalty: If the player collides with an enemy robot, they lose and must restart the level.
   * The enemy robots move within a predefined boundary, ensuring they stay within the play area.


* Survival Timer:
   * A 60-second timer begins as soon as the player enters the glass door.
   * The glass door blocks the exit until the timer ends, adding tension to the gameplay.


* NPC Interaction:
   * After completing the survival task, the player can interact with the final NPC.
   * The NPC congratulates the player for their success and provides the final challenge of the level.


 Key Points and Considerations:
1. Enemy Robots:
   - The enemy robots move unpredictably, increasing the difficulty of avoiding them.
   - Use careful movement and timing to avoid collisions.


2. Glass Door Mechanism:
   - The glass door seals the room as the player enters.
   - It will only disappear after the 60-second survival task is completed.


3. Final NPC Interaction:
   - Once the player exits the room, they must find and interact with the final NPC.
   - The NPC will present a multiple-choice puzzle that the player must solve to progress.


4. Final Challenge:
   - Solve the NPC's puzzle to learn more about the story and gain access to the next level.
   - Completing the puzzle successfully will transition the player to the next stage of their journey.


Design Highlights:
* Dynamic Enemy Movement: Enemy robots utilize random direction changes and boundary constraints to create unpredictable challenges.
* Tense Survival Mechanic: The countdown timer adds urgency, encouraging players to strategize their movement while staying alert.
* Narrative Integration: The final NPC provides closure to the level, blending gameplay and story progression seamlessly.








Level4:
Gameplay Overview:
* The player takes on the role of a robot whose goal is to reach the charging tower and successfully charge to complete the mission.
* At the start of the game, a hint will guide the player to the left room to find something useful.
* The player must avoid patrolling guards—if caught, the game will prompt a restart.
Controls:
* Movement: Use WASD to move.
* Interaction:
   * Pick Up Items: Approaching items like the X-ray Cube will automatically collect them.
   * Activate X-ray Vision: Press F to activate X-ray vision, which allows the player to see guards and key items (such as keys and the charging tower) through obstacles.
* Objective: Use the X-ray feature to find the key, activate the trap area to immobilize the dangerous yellow guards, and ultimately reach the charging tower to complete the charging task.
Key Features of the Level:
* Trap Area: Players must find a key to activate the trap area. Once activated, the trap rises and can immobilize enemies, demonstrating interactive environment features.
* X-ray Vision: Players can use X-ray vision to see through obstacles, locating guards and key items. This feature is an important technical implementation that combines visual effects with gameplay elements.
* Patrolling Guard AI:
   * There are two types of guards:
      * Green Guards: These guards move at a slower speed and have a narrower field of view.
      * Yellow Guards: Located outside the charging tower room, these guards are faster and have a wider field of view, making them more challenging to avoid.
   * All guards have three behavior modes: patrolling, chasing, and searching. Guards will patrol their designated paths, chase the player if they spot them, and enter a searching mode if they lose sight of the player.
Key Points and Considerations:
* Room Items: The X-ray Cube in the left room is a crucial item to progress; make sure to pick it up.
* Key for Trap Activation: You need to find the key to activate the trap area, which will help in immobilizing the yellow guards. The X-ray vision can assist in locating the key.
* Dangerous Yellow Guards: The yellow guards are fast and have a wide field of view. It is recommended to lure them into the trap area once it is activated.
* Charging Tower: The final goal is to reach the charging tower and complete the charging task. After completion, a level selection screen will appear.
iii. Known problem areas 
Level1:
1. Lack of Sound effect
   1. There are little sound effects for collisions and other actions.
Level2:
1. Lack of Sound Effect:
Due to lack of sound assets, there is no sound or audio imported to this scene which is one of the main problems. It will let players have a less immersive experience on the game.
2. Difficulty balancing:
The level may feel either too easy or too hard depending on the player's skill level, particularly due to the power decay rate and the single-use recharge mechanic.
3. Obstacles Improvement:
The obstacle type is a little bit simple and could add more different movements like rotation and collision. Introduce random movement patterns or vary obstacle speeds to increase unpredictability.
Level3:
1. Lack of Sound Effects:  
* The game currently lacks sound effects for key actions such as collecting balls, enemy robot collisions, or completing tasks, which could improve player feedback and immersion.


2. Difficulty of the Second Game (Avoiding Enemies):  
* The second game may feel overly challenging for some players due to the unpredictable movement patterns of enemy robots and the confined space of the room.


3. Limited Visual Feedback for Timer:  
* In the second game, the 60-second countdown timer is not visually represented, making it harder for players to track how much time remains.




Level4:
1. Guard AI Pathfinding Issues:
* Guards may occasionally get stuck during chasing, or appear to chase around "invisible obstacles" in certain areas.
2. X-ray Vision Clarity:
* When X-ray vision is activated, there is no outline on transparent objects, making it difficult to clearly identify them.
3. Lighting Issues in Level Selection:
* Due to the use of additive scene loading, lighting may not always load correctly when switching levels. Currently, this is the only way to handle scene transitions, but it may result in inconsistent lighting.
4. Chase Mode Audio:
* The siren audio during chase mode sometimes continues to play longer than expected, even after escaping from guards.




iv. Manifest of which files authored by each teammate: 
Weijian Liu:
Weijian was responsible for the design and implementation of Level 4, including all core game mechanics and their integration.
* Avoiding Guards: Designed and implemented the guard AI behavior, including patrolling, chasing, and searching modes. Players need to strategically avoid guards by understanding their line of sight and patrol paths.
* X-ray Vision Feature: Implemented the X-ray vision feature, allowing players to press F to see guards and key items through obstacles, aiding in route planning and locating important items.
* Trap System: Developed the trap area activation and rising mechanism, where players need to find a key to activate the trap and use it to immobilize the yellow guards in front of the charging tower room for safe passage.
* UI Design: Created the end-of-level UI, including completion messages, level selection options, and restart options when the player is caught by guards, providing clear guidance on game state and progression.
* Audio Integration: Integrated multiple sound effects, including level completion, X-ray activation, key pickup, and chase sirens, as well as the initial mission briefing voice, trap area hints, and trap activation sounds, enhancing the game's immersive experience.
Asset List:
Patrol Guard:
1. RobotSoldier(7)
2. PatrolPoint(15)
Trap:
1. TrapZone
2. TriggerTile
3. KeyItem
XRay:
1. XRayCube
2. XRay Camera
Charging Tower:
1. ChargingZoneTrigger
UI:
1. Mission Panel (in the beginning of game)
2. Restart Panel (get caught by guards)
3. LevelFinish Panel
4. Level Selection Buttons
5. TrapText
6. XRayUIText
Audio (sources in Assets/Guard/Sound):
1. Initial Mission Briefing Voice
2. X-ray Activation Sound
3. Key Pickup Sound
4. Trap Zone Hint Sound
5. Trap Activation Sound
6. Chase Alarm
7. Mission Complete Sound
Special Effects:
1. X-ray Vision Effect
2. Trap Rising Animation Effect




C# Script List(mostly in Assets/Guard):
1. GuardPatrol.cs
2. XRayUIController.cs
3. XRayPickup.cs
4. TriggerTileController.cs
5. TrapTriggerTile.cs
6. SirenPlayerController.cs
7. PlayerXRayVision.cs
8. OnCollisionEnter.cs
9. MissionManager.cs
10. LevelCompleteController.cs
11. KeyItemController.cs
12. GuardCollisionHandler.cs
13. GameManager.cs (when caught by guards)
14. ChargingZoneController.cs


Mingming Yang:
Mingming was responsible for the design and implementation of Level 2, including the scene, all core game mechanics and their integration.
Overall contributions:
* Designed the Colonial City Scene and overall game mechanism, including Yellow Graves, moving obstacles, and the Power Station.
* Integrated animations for moving obstacles and implemented their automatic back-and-forth movement.
* Set up UI elements such as instruction panels, game over panels, and a power tracker.
* Added Obstacle Collision Logic to deduct power when the robot collides with moving obstacles.
* Developed the Grave Behavior script to handle interactions, disappearance, and updates to the remaining grave count.
* Created the Scene Transition System, allowing players to move to the next level upon meeting all conditions.
* Edited the Power Management System, including gradual decay, recharging mechanisms, and restrictions (only charging once).
C# Script Files:
* ChargingStation2.cs
* RobotPower2.cs
* MingmingGameManager.cs
* MovingObjects.cs
* GraveBehavior.cs
* SceneTransition2.cs


Assets:
* Colonial Graveyard
* Church
* StreetLight
* UI: GameStartPanel, GameOverPanel, PauseMenu, InstructionPanel
* MovingObjects: three capsules, one sphere
* Scene transition building




Team Member: Jacob Nguyen


Contributions:


C# Script Files:
* RobotPower.cs: Manages the power level display for the robot, updating the power percentage in real-time on the screen as the robot interacts with the environment.
* ChargingStation.cs: Script for our charging stations, features include pulsing lights, disabling when out of charge, having a set amount of given charge, and having a line renderer to tell player when they’re connected.
* ClimbPowerUp.cs: Script to handle Climbing powerup, including visual effects, deleting after pickup, and updating inventory script.
* ObjectPressurePlate.cs: Handles logic for detecting object on pressure plate, and opening the associated door.
* DoorKeyPickup.cs: Handles our door key animations, as well as updating player inventory and scene when picked up.
* PressurePlateDoor.cs: Handles animations and movement of our Pressure Plate activated doors.
* RobotPower.cs: Handles reading, updating, and displaying the current power level of the robot.
* PlayerInventory.cs: Handles a trigger for when a player can climb, and has the climbable power up for our inventory handler and other inventory related attributes.


Assets:
* Power Station Prefab
* UI Canvas In Level 1:
   * Power Level Text
   * Inventory Text
* Climb Up PowerUp in Level 1
* Object Triggerable Pressure plate in Level 1
* Door Key Pickup in Level 1
* Pressure Plate and Key doors in Level 1
* Climbable Walls


What I did:
* Robot Power System and UI Display:
   * Designed a power system for the robot, where movement is tied to available power.
   * Implemented a mechanism to disable the robot’s movement when the power is depleted, adding a layer of strategy and resource management to gameplay.
   * Created a UI element to display the robot’s current power level, ensuring players can track and manage their power usage effectively.
   * Integrated power stations within the level to allow the robot to recharge, encouraging exploration and planning.
* Level One Design
   * Pressure Plate Door Design
      * Developed a system where doors are triggered to open when the robot or objects like crates activate a pressure plate.
      * Included visual and audio feedback to indicate when the plate is activated, enhancing player understanding.
   * Object Pressure Plate
      * Designed pressure plates that can be activated by objects, such as crates, rather than just the robot.
      * Implemented a mechanic to allow the robot to push crates onto pressure plates, creating engaging puzzles.
   * Door Key and Corresponding Opening Door
      * Created keys that the robot can collect to open locked doors.
      * Designed corresponding doors with key requirements, making the level progression dependent on exploration and item collection.
   * Climbable Wall Elements
      * Added specific wall elements that the robot can climb after acquiring the Climbable PowerUp.
      * These walls are visually distinct to ensure players can easily identify them.
   * Climbable PowerUp
      * Designed and implemented a collectible power-up that grants the robot the ability to climb walls.
      * Integrated this mechanic into the PlayerInventory script, ensuring players must first obtain the power-up before climbing is possible.
* Overall Level Design
   * Planned the layout of Level One, incorporating a mix of puzzles, exploration, and challenges to create an engaging gameplay experience.
   * Included power stations, climbable walls, and power-ups to encourage exploration and strategic play.
   * Balanced the placement of interactive elements to maintain a smooth difficulty curve while keeping the level exciting.
* Player Inventory
   * Developed the PlayerInventory script to manage collected items like keys and power-ups.
* Tutorial for First Level
   * Created an interactive tutorial to guide players through the mechanics of the game, including:
      * Explaining the power system and how to recharge.
      * Introducing pressure plates, climbable walls, and collectible power-ups.
      * Teaching how to interact with doors and keys.
   * Designed tutorial pop-ups that trigger contextually, such as when stepping on a pressure plate for the first time or finding the Climbable PowerUp.
* Doors for First Level
   * Designed several doors with different requirements, such as keys, pressure plates, or power to unlock.
   * Implemented animations for door opening and closing to enhance visual feedback.
   * Ensured the doors integrate seamlessly with the level’s puzzles and progression flow.


Team Member: Victor Wu
C# Script Files:
1. StoryTrigger.cs
2. ThirdPersonCamera.cs
3. PressurePlateManager.cs
4. RobotLegSpawn.cs
5. RobotMovement.cs
Assets:
1. RobotSphere sprite
2. Animator for RobotSphere (custom done not a prefab)
3. Shipping crate material
4. RobotSphere Animator Controller
5. RobotSphere animations
What I did:
1. RobotSphere 
   1. Imported a unity asset to get the model and some of the animations
2. RobotSphere Animator 
   1. Custom setup the animator based off the available animations that were given as part of the import
   2. Created a “wake-up” animator that will play and prevent the user from moving until the animation is complete.
   3. Set up idle animations
   4. Scaled animation based off speed as well as reversed the animation when walking backwards
3. Primary Camera
   1. Created the third person camera that is above the player
   2. Created the script to follow the player as well as rotate as the player moves (smoothened)
4. Cinematic Cameras
   1. Not shown in the gameplay, but set up cameras that could be used to capture the robot moving across certain hallways for the trailer
5. Tutorial Pressure Plate Logic
   1. Cleaned up the tutorial pressure plates to be dynamic rather than statically displaying the same text at all stages.
   2. Will now show different text based off which pressure plate is being pushed on
   3. Previously only showed the same static block of text but now will only show the necessary information of each pressure plate and guide the user to progress through the level.
6. Character Mapping to each Level
   1. Given that each level was worked on individually by other team members, inconsistencies appeared in each level and the robot had weird clippings. 
   2. Overall clean up of how the character was mapped to the ground on each level.
7. Various bug fixes across all levels when encountered during playtesting
   1. Fixed bugs from visual to gameplay across every level


Team Member: Ruijia Peng
Ruijia Peng was responsible for the design and implementation of Level 3, including all game mechanics, player interactions, and narrative progression. Also in charge of scenes transition, Login Menu and Game Menu.


Game 1: Memory Challenge with Collectibles
* Gameplay Design: Designed and implemented a memory-based challenge where players must recall and locate four disappearing balls after an initial preview.
* Scoring Mechanism: Integrated a scoring system that rewards players for collecting balls in the correct locations.
* Visual Feedback: Adjusted instructional cubes to ensure clearer guidance for players without overcrowding the game environment.
Game 2: Avoidance and Survival
* Enemy Robot AI: Developed patrolling enemy robots with random movement behavior within defined room boundaries, adding unpredictability and challenge.
* Survival Timer: Implemented a countdown timer requiring players to avoid robots for 60 seconds to unlock the glass door.
* Game Feedback: Added score increments when the player completes the survival challenge, rewarding progress while integrating into the overall scoring system.
* Visual Improvements: Changed enemy robot models for better thematic consistency and added additional enemy robots to increase difficulty.
Game 3: Final NPC and Puzzle Challenge
* NPC Interaction: Designed and scripted the final NPC that congratulates the player on completing the survival challenge and presents a multiple-choice quiz.
* Puzzle Mechanics: Implemented a quiz system where players answer questions to progress further into the game.
* Scene Transition: Integrated a seamless level transfer system to transition the player to the next stage upon successful task completion.


Additional Contributions:
1. Scenes Transition:  
   - Designed and implemented seamless scene transition logic for the game. Players can smoothly move between levels based on progress or task completion.  
   - Ensured the transitions maintain game continuity and avoid lighting inconsistencies.  
2. Login Menu:  
   - Created a login menu that initializes the game and provides players with a clear starting point.  
   - Integrated user-friendly UI components to make the menu intuitive for first-time players.  
3. Game Menu:  
   - Developed a fully functional game menu with options to restart, quit, or pause gameplay.  
   - Enhanced the user experience by allowing players to easily manage their in-game actions and settings.  
4. Glass Door Mechanics:  
     - In Level 3, glass doors enforce score requirements to restrict player progression until objectives are met.
5. Lighting and Visuals:  
   - Adjusted and refined lighting settings across levels to ensure a consistent and immersive environment.  
   - Addressed issues with scene transitions to maintain proper lighting and avoid abrupt visual changes.  
6. Ball Visibility and Scoring:  
   - Managed ball visibility mechanics in Level 1, ensuring balls disappear and reappear based on the player's interactions.  


C# Script List (Stored in Assets/Script/RP):
1. CollectibleBall.cs: Handles collectible ball logic in Level 1.
2. DoorMechanism.cs: Manages glass door visibility and interaction mechanics.
3. EnemyRobotMovement.cs: Defines enemy robot behavior, including random movement and boundary enforcement.
4. EnemyGameManager.cs: Handles game restart logic when the player collides with an enemy robot.
5. FinalTaskGlassDoor.cs: Controls the final glass door's behavior in Level 3.
6. FinalTaskNPC.cs: Implements the NPC dialogue and quiz system in Level 3.
7. HallwayBallController.cs: Manages ball visibility and scoring for Level 1.
8. LevelSystem.cs: Tracks and manages the player's level progression.
9. LoginManager.cs: Handles initial game login and setup (if applicable).
10. PauseMenu.cs: Implements the pause menu with restart and quit functionality.
12. SceneTransition.cs: Simplifies scene transfer logic.
13. ScoreManager.cs: Manages the player's score across levels.
14. StoryTrigger.cs: Controls NPC dialogue triggers and storytelling elements.


Asset List:
1. Game 1 Assets:
* Hallway Balls: Memory-based collectible balls with visibility mechanics.
* Instruction Cubes: Guide players to understand the first challenge.
* ScoreManager: Script to track and display the player’s score.
2. Game 2 Assets:
* Enemy Robots: AI-driven patrolling robots with randomized movement behavior.
* RoomStayTimer: Script to manage the countdown for survival tasks.
* Glass Door: Dynamic door that appears and disappears based on gameplay conditions.
3. Game 3 Assets:
* FinalTaskNPC: NPC that provides the final challenge and explains the backstory.
* FinalTaskGlassDoor: Glass door enforcing score-based progression.
* QuizPanel: UI for presenting multiple-choice questions in the final task.
* DialoguePanel: UI for displaying NPC dialogue and story elements.