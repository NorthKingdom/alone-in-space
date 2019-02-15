using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr;

public class TestEventListener : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        //if (GvrControllerInputDevice.GetButtonDown(GvrControllerButton.TouchPadTouch))
        //{

        //}
        //if (GvrControllerInput.HomeButtonDown)
        if(GvrControllerInput.ClickButtonDown)
        {
            Debug.Log("works");
        }
    }

    public void LogClick() 
    {
        Debug.Log("we were clicked!");
    }

    public void LogAnother()
    {
        Debug.Log("we were also clicked!");
    }
}
