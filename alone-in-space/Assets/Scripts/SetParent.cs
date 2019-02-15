using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour {

    // get the spaceship object
    public GameObject Spaceship;

	// Use this for initialization
	void Start () {
        if (!Spaceship) {
            Debug.LogError("Add the spaceship model to: " + gameObject);
        } else {
            gameObject.transform.SetParent(Spaceship.transform, true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
