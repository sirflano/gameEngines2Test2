# Game Engines 2 Lab Test Summer 2017

The goal of this test is to create the AI for the blue resource gathers depicted in the video below. 

[![YouTube](http://img.youtube.com/vi/dRVBgMaKsU8/0.jpg)](https://www.youtube.com/watch?v=dRVBgMaKsU8)

What is happening:

- The yellow boxes represent flowers that contain pollen, a resource that the bees want to collect. Bees are represented by the blue boxes with the wings. The bees collect pollen from the flowers and bring it back to the hive. The hive is represented by a purple box.  
- The hive can create a maximum of 10 bees at a rate of 1 every 2 seconds. A bee costs 5 units of pollen to make. The hive starts with 10 units of pollen and so it will be able to make 2 bees initially. 
- As the bees collect more pollen, the hive makes more bees
- Bees have the following behaviour:
    - Bees explore their environment looking for flowers. 
    - To do this, bees pick a spot within range of the flowers to move to. 
    - They slow down as they approach the spot. 
    - If the bee comes within 20 units of a flower whilst it is exploring, it will head towards the flower in order to load up with pollen
    - When the bee arrives at a flower, it will gather pollen from the flower at a rate of 1 unit of polen per second until the pollen is all gathered. 
	- When the flower has no more pollen, it gets removed from the scene and the bee heads back to the hive to deposit the pollen. 
    - If a bee doesn't find any flowers, it will pick a new spot to approach. 
    - The bees state machine updates 5 times a second.

# Rules
- This is a closed book test. 
- No use of any internet resources apart from the Unity and Visual Studio API reference pages.  

# Instructions - READ CAREFULLY
- Create a new blank github repository and select the Unity gitignore
- Clone the repo to your local computer
- Unzip this [starter project](StarterCode.zip) into the folder containing your repo
- Open scene1 in the starter project and make your additions here
- Commit and push your work to this repository regularly
- Submit the link to the repository [here](https://docs.google.com/forms/d/e/1FAIpQLSfuEjjWEzX44YB3pmT5JZ4CO-p1y04T5AZEKghpNOS63P2jCg/viewform)


# Marking Scheme
| Description | Marks |
|-------------|-------|
| Creating new bees from the hive as described above | 20 |
| Bee movement | 25 |
| Bee resource gathering | 35 |
| Polish & flair | 20 |

Marks will be awarded for creative, elegent and efficient soultions

# Rubric

| Description | Marks |
|-------------|-------|
| 1 | Everything works as per the video. Code is organised into seperate game components for the AI, boid and arrive behaviour. A finite state machine implemented using the state machine design pattern (or some other high leve AI framework is used). The movement of the bees is fluid, with techniques such as lerping used as appropriate in the integration function. There is some visual enhancement or AI enhancement such as an animation, trails or sound  |
| 2.1 | Mostly everything works and the code is organised into a Bee class and a Hive class. Finite state machine is included based on enumerated types. Movement is mostly smooth but with some occasional glitchyness. No additional visual or AI enhancements |
| 2.2 | Bee movement is working ok based on a rigid body or an integration function in a Bee class. Bugs or incomplete bee spawning.  Bee AI has bugs or is incomplete. No additional visual or AI enhancements included. |
| Pass | Program compiles and the bees move, but significant bugs in bee spawning and AI  |
| Fail | Program wont compile and nothing works |  
