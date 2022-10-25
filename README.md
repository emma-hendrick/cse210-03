# Seeker
Falling through the sky! <i>Jumper</i> might seem easy but 
even the best fall down some time. The rules are simple. The 
user guesses at the hidden word and the program provides a hint.
Guess correctly in time or meet your end.

---
## Getting Started
Make sure you have dotnet 6.0 or newer installed on your machine. Open 
a terminal and browse to the project's root folder. Start the program 
by running the following commands.
```
dotnet build
dotnet run 
```
You can also run the program from an IDE like Visual Studio Code. 
Start your IDE and open the project folder. Select "Run and Debug" on 
the Activity Bar. Next, select the project you'd like to run from the 
drop down list at the top of the Side Bar. Lastly, click the green 
arrow or "start debugging" button.

## Project Structure
The project files and folders are organized as follows:
```
root                        (project root folder)
+-- Game                    (source code folder)
+-- +-- Director.cs         (director class)
+-- +-- HiddenWord.cs       (hidden word class)
+-- +-- Library.cs          (library class)
+-- +-- TerminalService.cs  (terminal service class)
+-- Program.cs              (program entry point)    
+-- README.md               (general info)
+-- Unit03.csproj           (dotnet project file)
```

## Required Technologies
* dotnet 6.0

## Authors
* Michael Hendrick (mhendrick@byui.edu)