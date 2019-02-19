using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour {

    public GameObject gameManager;
    public GameObject viewsManager;

    // game state
    private const string PRELAUNCH = "prelaunch";
    private const string INTRO = "intro";
    private const string GAME = "game";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GvrControllerInput.ClickButtonDown){
            Debug.Log(GameManager.GetGameState());
            switch (GameManager.GetGameState())
            {
                case PRELAUNCH:
                    Debug.Log("launch intro!");
                    gameManager.GetComponent<GameManager>().LaunchIntro();
                    break;
                case GAME:
                    viewsManager.GetComponent<ViewsManager>().Transition();
                    break;
                default:
                    break;
            }

            if (string.Equals(GameManager.GetGameState(), PRELAUNCH)) 
            {
                //Debug.Log("start the intro!");
                gameManager.GetComponent<GameManager>().LaunchIntro();
            } 
            else if (string.Equals(GameManager.GetGameState(), INTRO)) 
            {
                //Debug.Log("clicked during intro");
            } 
            else if (string.Equals(GameManager.GetGameState(), GAME))
            {
                //Debug.Log("clicked during game");
                viewsManager.GetComponent<ViewsManager>().Transition();
            }
        } 

        if(GvrControllerInput.TouchDown){
            Debug.Log("touching!!!");
        }
    }
}
