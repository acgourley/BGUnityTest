//Developed for BitGym 2014
//Test for Doug Kinnison

//This script acts as the manager for the scene. This is needed because I have to hide the Login Button and this will
//deactivate it's functions. So this must live on a game object that is ever present.
//The script will find all game object needed.
//--Pass values to the Parse service.
//--Initialize responses.
//--Initialize the particle on success.
//--Return the user if the authentication fails.

using UnityEngine;
using System.Collections;
using System;
using Parse;

public class LoginMNG : MonoBehaviour {

	//Strings
	public string username;//I will pass this to the Parse service
	public string password;//I will pass this to the Parse service

	//bools
	public bool isAuthenticated = false; //returned from Parse
	public bool authenticating = false; //So that I can hide and show things when the time is right
	public bool loadingActive = false; //If I'm loading I want to know.

	//UILabels
	public UILabel uname;
	public UILabel pword;
	public UILabel loginSuccess;
	public UILabel loginFail;

	//GameObjects
	public GameObject panel;
	public GameObject loadingGO;
	public GameObject particle;
	public GameObject login;
	

	// Find my objects and set init values.
	void Start () {
		this.uname.text = "Username";
		this.pword.text = "Password";
		this.panel = GameObject.Find ("LoadingParent");
		this.login = GameObject.Find ("Login");
	}
	
	// 
	void Update () {
		this.username = uname.text;
		this.password = pword.text;

		// If I start to authenticate, hide the login GO.
		if (authenticating){
			this.login.SetActive(false);
			this.loadingActive = true;
		} else {
			// As soon as I get a response either way, kill the loading GO.
			Destroy(loadingGO);
		}

		// If we have a successful authentication, get rid of everything.
		if (isAuthenticated) {
			this.loadingActive = false;
			Destroy(loadingGO);
			particle = Instantiate(Resources.Load("Particle")) as GameObject; 

		}else {
			// If we error out, reactivate the login GO.
			this.login.SetActive (true);
		}
	}

	// Parse Docs.
	void authenticateUser(string username, string password){
		
		ParseUser.LogInAsync(username, password).ContinueWith(t =>
		                                                      {
			if (t.IsFaulted || t.IsCanceled)
			{
				// Report that authentication failed and we are not authenticating.
				// Alert User with some helpful text.
				isAuthenticated = false;
				authenticating = false;
				loginFail.text = "Error logging in";

			}
			else
			{
				// We're all good. Log in successful gets printed and authenticated prompts the particle effect.
				isAuthenticated = true;
				loginSuccess.text = "Login Successful";
				authenticating = false;
			}
		});
	}

	// This is my public function for login that is called by the Login Button.
	public void UserLogin(){
		this.login.SetActive (false);
		this.authenticating = true;
		authenticateUser (this.username, this.password);
		loadingGO = Instantiate(Resources.Load("Loading")) as GameObject; 

		//Ensure that the game object stays at a 1-1 scale.
		loadingGO.transform.parent = this.panel.transform;
		loadingGO.transform.localScale = new Vector3(1, 1, 1);
		this.loadingActive = true;
	}

}
