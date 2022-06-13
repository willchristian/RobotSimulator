# Robot Simulator
This project simulates a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.

## Using the code
This project was written on [.Net Core version 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1) using Visual Studio 2022.

You can run the code directly through Visual Studio, a different C#/.Net IDE, or via the .Net Cli (dotnet)

## Requirements
* .Net Core 3.1

## Running the code
* Clone the repository
```
git clone https://github.com/willchristian/RobotSimulator
```
* Either:
	* Open the solution RobotSimulator.sln in Visual Studio or IDE of your choice and run the RobotSimulator project
	* or, open the cloned respository in a terminal and open the RobotSimulator project and run it via the dotnet cli.
	```
	cd RobotSimulator
	dotnet run
	```

The program will use the `commands.txt` file found in the RobotSimulator project or you can specify your own `.txt` file to use as the first argument.
e.g
```
dotnet run test.txt
```

## commands.txt
`commands.txt` is a file with a list of commands for the robot to execute. Commands are in the form
* PLACE X,Y,F
	* PLACE robot on `X`, `Y` coordinates `F` facing a direction (NORTH, SOUTH, EAST, WEST)
	* e.g. PLACE 1,1,WEST
* MOVE
	* Moves the robot one unit in the direction it is currently facing
* LEFT
	* Turns the robot to the left.
* RIGHT
	* Turns the robot to the right;
* REPORT
	* Reports the robot's current X,Y,F 
