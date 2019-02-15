using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOtherRooms : MonoBehaviour {

    private GameObject[] rooms;  // spaceship rooms (360 photos)

	// Use this for initialization
	void Start () {
        rooms = GameObject.FindGameObjectsWithTag("Room"); //Find all the rooms
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
