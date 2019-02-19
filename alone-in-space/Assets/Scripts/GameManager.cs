using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool DEBUG; // show/hide intro
    public GameObject firstRoom; // the first room, where we start our experience
    public GameObject introCanvas;
    public GameObject audioManager;
    public GameObject viewsManager;

    private GameObject _spaceship;
    private Material _cameraOverlay;

    // game state
    private const string PRELAUNCH = "prelaunch";
    private const string INTRO = "intro";
    private const string GAME = "game";

    private string _gameState = PRELAUNCH;

    // Use this for initialization
    void Awake () {
        _spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        _cameraOverlay = GameObject.FindGameObjectWithTag("CameraOverlay").GetComponent<Renderer>().material;
        if (DEBUG)
        {
            StartCoroutine(Game());
        }
	}

    public static string GetGameState() {
        return GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>()._gameState;
    }

    public void LaunchGame() 
    {
        StartCoroutine(Game());
    }

    public void LaunchIntro()
    {
        StartCoroutine(Intro());
    }

    // INTRO SEQUENCE

    IEnumerator Intro() {
        _gameState = INTRO;
        yield return new WaitForSeconds(0.5f);
        audioManager.GetComponent<AudioManager>().PlayIntroSounds();
        yield return new WaitForSeconds(1.0f);
        Debug.Log("play intro!");
        introCanvas.GetComponent<LogotypesAnimation>().PlayIntro();
        yield return null;
    }

    // GAME TRANSITION SEQUENCE

    IEnumerator Game() {
        _gameState = GAME;
        Destroy(introCanvas);
        _cameraOverlay.color = new Color(_cameraOverlay.color.r, _cameraOverlay.color.g, _cameraOverlay.color.b, 1.0f); // put on the overlay
        Camera.main.transform.parent.position = firstRoom.transform.position; // move the camera to the first room
        viewsManager.GetComponent<ViewsManager>().RoomsSetActive(true); // show rooms in the background
        StartCoroutine(FadeOut(0.6f, _cameraOverlay)); // fade out the overlay
        audioManager.GetComponent<AudioManager>().PlayGameSounds();
        yield return null;
    }

    // CAMERA OVERLAY 

    IEnumerator FadeOut(float _duration, Material mat)
    {
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
}
