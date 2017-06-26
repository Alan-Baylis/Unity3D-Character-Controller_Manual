# This Repository and It's Content
Use of these scripts is free (http://unlicense.org). Crediting the author (me! :D) is not required at all, although it is not discouraged or unwelcomed - though I do ask that anyone using these assets contribute to the public domain as well by releasing as many scripts and projects as you feel comfortable with under the Unlicense or similar licenses where you can legally and ethically do so.
These scripts may sometimes serve purposes already covered by standard Unity assets, but mine are generally easier to understand and shorter/ lighter weight, allowing for more customizability. They will, furthermore, generally be made to fit standard/ default PC control schemes where applicable and may not work on other platforms.

# Important Reminder:
Whenever you use a script from this repository, make sure to read the documentation comment attached to the top of the script, as well as the usage comments beside public variables to make sure you are using the script correctly. Also attached are explanatory comments that explain code segments, but these should not be necessary to use unless you are editing the script directly.

# How To Use These Scripts:
1. Create either a 3D game object, or an empty game object with a collider component.
2. Create a new C# script named "characterMoveController" and attach it to the game object.
3. From the inspector, add a "Rigidbody" script to the game object.
4. In the Rigidbody component, open the constraints menu and freeze the following:    X Rotation    Y Rotation
5. Open the "characterMoveController" with Monodevelop, remove the prewritten code and paste in the code from the    "characterMoveController.cs" file on this repository.
6. Create a new camera game object (or use the one that comes with every new scene).
7. Create a new C# script and name it "characterLookController," then paste in the code like you did in step #5.
8. Drag the script on to the camera.
9. Drag the camera on to the rigidbody object, parenting it.
10. On the rigidbody in the inspector under the script component, fill in the variables with your desired values.    (Examples are given as comments in the actual script.)
11. On the camera in the inspector under the script component, choose wether or not to invert axes.
12. Ensure that your character is on a surface with a collider.
