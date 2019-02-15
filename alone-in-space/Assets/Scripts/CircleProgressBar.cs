using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleProgressBar : MonoBehaviour {

    public GameObject progressBar;
    public float attentionSpan;

    private Image _progressImage;
    private bool _timerIsRunning;
    

	// Use this for initialization
	void Start () {
        _progressImage = progressBar.GetComponent<Image>();
        _timerIsRunning = false;
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void SwitchRooms() {
        gameObject.GetComponent<SphereChanger>().ChangeRooms();
    }

    public void StartTimer()
    {
        StartCoroutine(CountAttention(attentionSpan));
    }

    public void StopTimer()
    {
        if(_timerIsRunning){
            _timerIsRunning = false;
            _progressImage.fillAmount = 0.0f;
        }
    }

    private IEnumerator CountAttention(float _duration) 
    {
        _timerIsRunning = true;
        float _time = 0;

        while (_timerIsRunning && _time <= _duration)
        {
            float _amount = _time / _duration;
            _progressImage.fillAmount = _amount;
            _time += Time.deltaTime;
            yield return null;
        }

        if (!_timerIsRunning) yield break;
        _timerIsRunning = false;
        _progressImage.fillAmount = 0;
        SwitchRooms();
    }


}
