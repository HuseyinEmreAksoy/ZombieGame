# ZombieGame
This project is for developing C# skills. I added fps camera animations and HTTP requests with the use backendless website. Also, I use canvas UI, TMP, and Image.
In the game, mechanics have detect player locations with the use ray and follow the player and try to kill. The Player also has 2 guns one of the long-shot other one is short-range but with high damage.
On the map, you can find ammo and you can pick them.
HTTP requests are to check the register and sign in for the game. In the register, I use GET request for checking Email and the Username is already taken. If not taken I add Email Username and Password into the backend with POST request. Otherwise, console writes an error.
Sign in I check the user is registered before. If the user registered already console writes a success message. Otherwise, console gets an error.
