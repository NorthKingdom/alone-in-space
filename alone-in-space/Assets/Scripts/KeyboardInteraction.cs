using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInteraction : MonoBehaviour {

    public GameObject Views;
    private bool _firstTouch; // boolean used to capture the first frame of keyboard up/down

    // Use this for initialization
    void Start () {
        if (Views == null) Debug.LogError("You have to add the view-switch GameObject to the keyboard interaction script");
        _firstTouch = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("down") == true && _firstTouch == false)
        {
            _firstTouch = true;
            ViewsManager _viewsManager = Views.GetComponent<ViewsManager>();
            _viewsManager.Transition();
        }
        else if (Input.GetKey("down") == false && _firstTouch == true)
        {
            _firstTouch = false;
        }
    }
}
