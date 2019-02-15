using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeMaterial : MonoBehaviour {

    private Renderer _renderer;

	// Use this for initialization
	void Start () {
        _renderer = gameObject.GetComponent<Renderer>();
	}

    public void OnEnter() {
        Debug.Log("controller entered!");
        _renderer.material.color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
