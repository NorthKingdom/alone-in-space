using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChanger : MonoBehaviour {


    public GameObject nextRoom;
    //This object should be called 'Fader' and placed over the camera
    GameObject m_Fader;

    void Awake()
    {

        //Find the fader object
        m_Fader = GameObject.Find("Fader");

        //Check if we found something
        if (m_Fader == null)
            Debug.LogWarning("No Fader object found on camera.");

    }


    public void ChangeRooms()
    {

        //Start the fading process
        Debug.Log("switch rooms!");
        StartCoroutine(FadeCamera(nextRoom.transform));

    }


    IEnumerator FadeCamera(Transform nextSphere)
    {

        //Ensure we have a fader object
        if (m_Fader != null)
        {
            //Fade the Quad object in and wait 0.75 seconds
            StartCoroutine(FadeIn(0.3f, m_Fader.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.3f);

            //Change the camera position
            Camera.main.transform.parent.position = nextSphere.position;

            //Fade the Quad object out 
            StartCoroutine(FadeOut(0.3f, m_Fader.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.3f);
        }
        else
        {
            //No fader, so just swap the camera position
            Camera.main.transform.parent.position = nextSphere.position;
        }


    }


    // FADE OUT CAMERA OVERLAY

    IEnumerator FadeOut(float _duration, Material mat)
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

    IEnumerator FadeIn(float _duration, Material mat)
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
