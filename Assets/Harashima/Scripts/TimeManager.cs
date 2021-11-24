using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Text _timerText;
    float _timer = 0f;
    float _timeJougen = 60f;
    bool isStop = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            TimeToString();
        }
        

        if (_timer > _timeJougen)
        {
            isStop = true;
        }
    }

    public void TimerONOF(bool isTimer)
    {
        isStop = isTimer;
    }

    void TimeToString()
    {
      
            _timer += Time.deltaTime;
        
        _timerText.text = "Time:" + _timer.ToString("");
    }
}
