using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour {

    public int raycastDistance;
    public LayerMask layers;

    private GameObject _activeRoomHotspot;

    // Use this for initialization
    void Start () {
        _activeRoomHotspot = null;
    }
    
    // Update is called once per frame
    void Update () {
        Raycast ();
        
    }

    void Raycast() {
        Vector3 forward = transform.forward;
        RaycastHit hit;

        if(Physics.Raycast(transform.position, forward, out hit, raycastDistance, layers)){
            string tag = hit.collider.gameObject.tag;
            //Debug.Log("we hit something!");
            //Debug.Log(hit.collider.gameObject);
            

            if(tag == "Hotspot_Room" && _activeRoomHotspot == null)
            {
                // set active Room Hotspot
                // start timer
                Debug.Log("start progress bar!");
                _activeRoomHotspot = hit.collider.gameObject;
                _activeRoomHotspot.GetComponent<CircleProgressBar>().StartTimer();


                //hit.collider.gameObject.GetComponent<SphereManager> ().ChangeTag ("Non-interactable");
            }
        } else {
            if(_activeRoomHotspot != null) {
                Debug.Log("stop progress bar!");
                _activeRoomHotspot.GetComponent<CircleProgressBar>().StopTimer();
                _activeRoomHotspot = null;
            }
        }
    }
}