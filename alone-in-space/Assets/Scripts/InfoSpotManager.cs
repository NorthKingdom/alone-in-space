using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSpotManager : MonoBehaviour {

    public GameObject hotspotInfo;
    int infoAnimHash = Animator.StringToHash("hotspotIsActive");

    private Animator _infoBoxAnimator;
    Collider _infoBoxCollider;

    // Use this for initialization
    void Awake()
    {
        _infoBoxAnimator = hotspotInfo.GetComponent<Animator>();
        _infoBoxCollider = hotspotInfo.GetComponent<Collider>();
        _infoBoxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ShowInfo() {
        _infoBoxCollider.enabled = true;
        _infoBoxAnimator.SetBool(infoAnimHash, true);
    }

    public void HideInfo()
    {
        _infoBoxAnimator.SetBool(infoAnimHash, false);
        _infoBoxCollider.enabled = false;
    }

}
