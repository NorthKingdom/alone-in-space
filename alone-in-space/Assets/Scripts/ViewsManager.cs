using UnityEngine;
using System.Collections;
using Gvr;

// toggles the model/360 photo view on Daydream controller press

public class ViewsManager : MonoBehaviour
{

    public GameObject spaceship; // spaceship object
    GameObject cameraOverlay; // overlay object
    public GameObject[] rooms;  // spaceship rooms (360 photos)
    private bool _transitionIsActive; // changing view boolean
    private bool _spaceshipIsActive; // boolean controlling the visibility of spaceship in the scene

    // SETUP

    void Start() 
    {
        // set default values
        _transitionIsActive = false; 
        _spaceshipIsActive = false;
        spaceship.SetActive(_spaceshipIsActive);

        cameraOverlay = GameObject.Find("Fader"); //Find the camera overlay
    }

    // -------------------------------------------------------------------- //

    // VIEWS TRANSITION CALL
    public void Transition() {
        StartCoroutine(ViewTransition());
    }

    // VIEWS TRANSITION
    IEnumerator ViewTransition() 
    {
        _spaceshipIsActive = spaceship.activeSelf; // store the current visibility state of the spaceship
        Debug.Log("start transition");

        //Ensure we have a camera overlay
        if (cameraOverlay != null)
        {
            // turn transition bool on 
            _transitionIsActive = true;

            //Fade to the camera overlay
            StartCoroutine(FadeIn(0.3f, cameraOverlay.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.3f);

            // Switch the views
            SwitchViews();

            //Fade the Quad object out 
            StartCoroutine(FadeOut(0.3f, cameraOverlay.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.3f);

            // turn transition bool off 
            _transitionIsActive = false;
        }
        else
        {
            // No camera overlay, just switch the views
            SwitchViews(); 
        }
    }

    // SHOW/HIDE THE ROOM SPHERES

    public void RoomsSetActive(bool visibilityBool)
    {
        foreach (GameObject room in rooms)
        {
            room.SetActive(visibilityBool);
        }
    }

    // SWICH VIEWS BETWEEN SPACESHIP AND SPHERE

    private void SwitchViews () 
    {
        spaceship.SetActive(!_spaceshipIsActive);
        foreach (GameObject room in rooms)
        {
            room.SetActive(_spaceshipIsActive);
        }
    }

    // FADE OUT CAMERA OVERLAY

    IEnumerator FadeOut(float _duration, Material mat)
    {
        //Debug.Log("fade out!");
        float _time = 0.0f;

        while(_time <= _duration)
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