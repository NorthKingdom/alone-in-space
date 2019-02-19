using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour {

    public int raycastDistance;
    public LayerMask layers;

    private GameObject _activeRoomHotspot;
    private GameObject _activeInfoHotspot;

    // Use this for initialization
    void Start () {
        _activeRoomHotspot = null;
        _activeInfoHotspot = null;
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
            Debug.Log("we hit something!");
            //Debug.Log(hit.collider.gameObject);
            

            if(tag == "Hotspot_Room" && _activeRoomHotspot == null)
            {
                // set active Room Hotspot
                // start timer
                Debug.Log("start progress bar!");
                _activeRoomHotspot = hit.collider.gameObject;
                //_activeRoomHotspot.GetComponent<CircleProgressBar>().StartTimer();
                _activeRoomHotspot.GetComponent<ArrowManager>().StartTimer();
            } 
                else if (tag == "Hotspot_Info" && _activeInfoHotspot == null) 
            {
                Debug.Log("we hit the info object!");
                _activeInfoHotspot = hit.collider.gameObject;
                _activeInfoHotspot.GetComponent<InfoSpotManager>().ShowInfo();
                //infoHotspot.GetComponent<InfoSpotManager>();
            }

        } else {
            if(_activeRoomHotspot != null) {
                Debug.Log("stop progress bar!");
                _activeRoomHotspot.GetComponent<ArrowManager>().StopTimer();
                _activeRoomHotspot = null;
            } else if (_activeInfoHotspot != null) {
                _activeInfoHotspot.GetComponent<InfoSpotManager>().HideInfo();
                _activeInfoHotspot = null;
            }
        }
    }
}