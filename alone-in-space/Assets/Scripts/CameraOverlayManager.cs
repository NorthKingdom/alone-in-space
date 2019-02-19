using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverlayManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // FADE OUT CAMERA OVERLAY

    public static void Logger() {
        Debug.Log("loggin works!");
    }   

    public static IEnumerator FadeOut(float _duration, Material mat)
    {
        //Debug.Log("fade out!");
        float _time = 0.0f;

        while (_time <= _duration)
        {
            float _progress = _time / _duration;
            float _alpha = Mathf.Lerp(1.0f, 0.0f, _progress);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, _alpha);
            _time += Time.deltaTime;
            yield return null;
        }
    }

    // FADE IN CAMERA OVERLAY

    public static IEnumerator FadeIn(float _duration, Material mat)
    {
        //Debug.Log("fade in!");
        float _time = 0.0f;

        while (_time <= _duration)
        {
            float _progress = _time / _duration;
            float _alpha = Mathf.Lerp(0.0f, 1.0f, _progress);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, _alpha);
            _time += Time.deltaTime;
            yield return null;
        }
    }
}
