using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogotypesAnimation : MonoBehaviour {

    public GameObject firstLogo;
    public GameObject secondLogo;
    public float timePerLogo;

    private GameManager _gameManager;

	// Use this for initialization
	void Start () {
        gameObject.transform.SetParent(Camera.main.transform, false);
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayIntro() {
        StartCoroutine(AnimateLogos());
    }

    IEnumerator AnimateLogos()
    {
        //Fade the first logo
        StartCoroutine(FadeIn(0.3f, firstLogo.GetComponent<Image>()));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(FadeOut(0.3f, firstLogo.GetComponent<Image>()));
        yield return new WaitForSeconds(1.0f);

        // Fade the second logo
        StartCoroutine(FadeIn(0.3f, secondLogo.GetComponent<Image>()));
        yield return new WaitForSeconds(timePerLogo);
        StartCoroutine(FadeOut(0.3f, secondLogo.GetComponent<Image>()));
        yield return new WaitForSeconds(2.0f);


        // Launch the game
        _gameManager.LaunchGame();

    }


    // FADE IN LOGO

    IEnumerator FadeOut(float _duration, Image logo)
    {
        //Debug.Log("fade out!");
        float _time = 0.0f;

        while (_time <= _duration)
        {
            float _progress = _time / _duration;
            float _alpha = Mathf.Lerp(1.0f, 0.0f, _progress);
            logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, _alpha);
            _time += Time.deltaTime;
            yield return null;
        }
        logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, 0.0f);
    }

    // FADE OUT LOGO

    IEnumerator FadeIn(float _duration, Image logo)
    {
        //Debug.Log("fade in!");
        float _time = 0.0f;

        while (_time <= _duration)
        {
            float _progress = _time / _duration;
            float _alpha = Mathf.Lerp(0.0f, 1.0f, _progress);
            logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, _alpha);
            _time += Time.deltaTime;
            yield return null;
        }
    }
}
