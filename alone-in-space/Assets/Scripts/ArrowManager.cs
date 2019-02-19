using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowManager : MonoBehaviour
{

    //public GameObject progressBar;
    public GameObject arrow;
    int arrowAnimHash = Animator.StringToHash("arrowIsActive");
    public float attentionSpan;

    //private Image _progressImage;
    private Animator _arrowAnimator;
    private bool _timerIsRunning;


    // Use this for initialization
    void Awake()
    {
        //_progressImage = progressBar.GetComponent<Image>();
        _arrowAnimator = arrow.GetComponent<Animator>();
        _timerIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SwitchRooms()
    {
        gameObject.GetComponent<SphereChanger>().ChangeRooms();
    }

    public void StartTimer()
    {
        StartCoroutine(CountAttention(attentionSpan));
        //_arrowAnimator.SetBool(arrowAnimHash, true);
        _arrowAnimator.SetBool("arrowIsActive", true);
    }

    public void StopTimer()
    {
        if (_timerIsRunning)
        {
            _timerIsRunning = false;
            //_arrowAnimator.SetBool(arrowAnimHash, false);
            _arrowAnimator.SetBool("arrowIsActive", false);
        }
    }

    private IEnumerator CountAttention(float _duration)
    {
        _timerIsRunning = true;
        float _time = 0;

        while (_timerIsRunning && _time <= _duration)
        {
            float _amount = _time / _duration;
            _time += Time.deltaTime;
            yield return null;
        }

        if (!_timerIsRunning) yield break;
        _timerIsRunning = false;
        //_arrowAnimator.SetBool(arrowAnimHash, false);
        _arrowAnimator.SetBool("arrowIsActive", false);
        SwitchRooms();
    }


}
