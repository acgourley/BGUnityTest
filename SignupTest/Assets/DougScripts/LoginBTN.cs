//Developed for BitGym 2014
//Test for Doug Kinnison

//This script is the functional part of the Login Button. 

using UnityEngine;
using System.Collections;

public class LoginBTN : MonoBehaviour {

	// Access the script that is on the LoginManager
	public LoginMNG loginManager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	// On click I trigger the public function on the LoginMNG.cs
	void OnClick(){
		loginManager.UserLogin();
	}
}
