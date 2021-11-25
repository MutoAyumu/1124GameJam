using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _timerText = default;
    [SerializeField] float _timeLimit = 60f;
    [SerializeField] Text _moneyText = default;
    [SerializeField] float _countTime = 3.5f;
    [SerializeField] Text _countTimerText = default;
    [SerializeField] UnityEvent _startEvent = default;
    [SerializeField] UnityEvent _endEvent = default;
    bool isOn;
    bool isEnd;
    int _money;
    int _currentMoney = 0;
    FishingHookScript _FHS;

    public int Money { get => _money; set => _money = value; }
    private void Start()
    {
        _FHS = GameObject.FindObjectOfType<FishingHookScript>();
    }

    private void Update()
    {
        if(!_FHS.IsOn)
        {
            _currentMoney = Money;
        }

        if (!isOn)
            Count();

        if (isOn && !isEnd)
        {
            _timeLimit -= Time.deltaTime;
            _timerText.text = "Timer : " + _timeLimit.ToString("F0") + "秒";

            _moneyText.text = "Money : " + _currentMoney.ToString("F0") + "円";
        }

        if (_timeLimit <= 0 && !isEnd)
        {
            _endEvent.Invoke();
            isEnd = true;
        }
    }

    void Count()
    {
        if (_countTime >= 0)
        {
            _countTime -= Time.deltaTime;
            _countTimerText.text = _countTime.ToString("F0");
        }
        else
        {
            _startEvent.Invoke();
            isOn = true;
        }
    }
}