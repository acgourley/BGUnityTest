//Developed for BitGym 2014
//Test for Doug Kinnison

//Script enables spinning on the object by getting a hold of it's transform and
//rotating around it's z axis by the speed variable multiplied by deltaTime.

using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	//Set my speed variable to change in the editor.
	public int speed;
	
	void Start () {}
	
	//Rotate the Z transform every frame.
	void Update () {
		transform.Rotate (0,0,this.speed*Time.deltaTime);
	}
}
