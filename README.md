BGUnityTest
===========
Instructions 

This project will have you fork, modify and send us back a simple Unity3D project which uses two of the main tools we use at BitGym - Parse.com and NGUI. 

* Fork this project on github.
* Clone your fork to your development machine and open Main.scene in Unity 4.3.4+
* NGUI 2.7 free edition is included because we can distribute it, although we use 3.x in production. NGUI 2.7 starting tutorial can be found here: http://www.tasharen.com/?page_id=185
* Create a new layer called "NGUI" and make sure all NGUI objects are added to this layer. 
* Use the NGUI helper tools to create an NGUI Panel (this will be the root of all the UI for this app)
* Make sure panel is on the NGUI layer and that it's listening to input events on the NGUI layer - if you don't, your buttons won't work later. 
* Create an NGUI Atlas and add all the PNGs in the project to it. 
* Add a user signup form to the screen. It should have one field named “username” and a second named “password” - these can use a tinted blank.png as their background. There shoudl also be a “Login” button using button.png as a sliced sprite background.  ![form](http://bitgymfiles.s3.amazonaws.com/ImagesForBGUnityTest/form.png)
* When a user taps “Login” - the values in the username and password forms should be submitted to our Parse.com backend using the Parse Unity library. A valid account is username “test” and password “foobar” - see: https://www.parse.com/docs/unity_guide#users-login
* Create 7 UISprite objects using the sprites in the atlas. There should be one sprite for each letter in the word LOADING. ![loading](http://bitgymfiles.s3.amazonaws.com/ImagesForBGUnityTest/loading.png)
* While parse is attempting to authenticate the user, the letters LOADING should spin in a circle around their common center point. You do not need to keep the letters upright, so just putting them all on a parent game object and rotating that parent game object on it’s Z axis is sufficient. 
* When Parse returns with a success, the LOADING letters should go away and the screen should say “Login Successful” and have a triumphant particle effect of your choice on display. 
* When Parse returns with an error, the LOADING letters should go away and the screen should return to the login screen and display “Error logging in” above the form. 
* When ready, please commit and push your code to your fork the git project, then issue a pull request to Alex on github (username: acgourley)
