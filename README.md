# This Repository and It's Content
Use of these scripts is free (http://unlicense.org). Crediting the author (me! :D) is not required at all, although it is not discouraged or unwelcomed - though I do ask that anyone using these assets contribute to the public domain as well by releasing as many scripts and projects as you feel comfortable with under the Unlicense or similar licenses where you can legally and ethically do so.
These scripts may sometimes serve purposes already covered by standard Unity assets, but mine are generally easier to understand and shorter/ lighter weight, allowing for more customizability. They will, furthermore, generally be made to fit standard/ default PC control schemes where applicable and may not work on other platforms.

# Important Reminder:
Whenever you use a script from this repository, make sure to read the documentation comment attached to the top of the script, as well as the usage comments beside public variables to make sure you are using the script correctly. Also attached are explanatory comments that explain code segments, but these should not be necessary to use unless you are editing the script directly.

# Using this script bundle as a first-person controller
1. Create a 3D game object with a collider (a capsule is recommended). This will be referred to as the “player.”
2. From the inspector, apply a Rigidbody to the player. I recommend going into constraints and freezing X rotation and Z rotation. (If the character randomly “jumps” to a certain altitude,ensure that the surface it is standing on is not convex. If this does not fix the issue, consider also freezing the Y position.)
3. Create a camera object and drag it onto the player object, making it a child object of the player. Ensure that the (local) X and Z coordinates are 0 from the transform component.
4. Create a C# file and name it “characterMoveController” (without quotes).
5. Open the file and delete all the starter code, then paste in the code from the characterMoveController.cs file in this repository. 
6. Save the file and drag it onto the player.
7. From the inspector, enter the key ID tags for your preferred controller setup. (recommended values are given in the script as comments).
8. Create a C# file and name it “characterLookController” (without quotes).
9. Open the file and delete all the starter code, then paste in the code from the characterLookController.cs file in this repository.
10. Save the file and drag it onto the camera.
11. From the inspector, enter the values for your preferred mouse setup. (recommended values are given in the script as comments).

# Using this script bundle as a third-person controller
