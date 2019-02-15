using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChanger : MonoBehaviour
{



    //This object should be called 'Fader' and placed over the camera
    GameObject cameraOverlay;

    //This ensures that we don't mash to change spheres
    bool changing = false;


    void Awake()
    {

        //Find the fader object
        cameraOverlay = GameObject.Find("Fader");

        //Check if we found something
        if (cameraOverlay == null)
            Debug.LogWarning("No Fader object found on camera.");

    }


    public void ChangeView()
    {

        //Start the fading process
        Debug.Log("change views!");
        StartCoroutine(FadeCamera());

    }


    IEnumerator FadeCamera()
    {

        //Ensure we have a camera overlay
        if (cameraOverlay != null)
        {
            //Fade to the camera overlay
            StartCoroutine(FadeIn(0.75f, cameraOverlay.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.75f);

            // Turn switch the views

            //Fade the Quad object out 
            StartCoroutine(FadeOut(0.75f, cameraOverlay.GetComponent<Renderer>().material));
            yield return new WaitForSeconds(0.75f);
        }
        else
        {
            //No fader, just swap the layer visibility
           
        }


    }


    IEnumerator FadeOut(float time, Material mat)
    {
        //While we are still visible, remove some of the alpha colour
        while (mat.color.a > 0.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }


    IEnumerator FadeIn(float time, Material mat)
    {
        //While we aren't fully visible, add some of the alpha colour
        while (mat.color.a < 1.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }


}
