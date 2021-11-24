using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public float PullPower 
    {
        get { return _pullPower; }
        set { _pullPower = value; }
    }
    public int ThrowPower { get =>  _throwPower; set => _throwPower = value; }
    public int HookNumber { get => _hookNumber; set => _hookNumber = value; }

    [SerializeField]private float _pullPower;
    [SerializeField]private int _throwPower;
    [SerializeField] private int _hookNumber;
    [SerializeField] ScoreManager _scoreManager;
    private Animator _anim = null;
    private float _movePos = 0.01f;
    private bool _isCatchUp = false;

    private float _score;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        GameStart();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0) && !_isCatchUp)
        {
            this.gameObject.transform.Translate(0, _movePos * _pullPower, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            _isCatchUp = true;
            var gameObjects = GameObject.FindGameObjectsWithTag("Hook");
            foreach(var g in gameObjects)
            {
                var fish = g.gameObject.GetComponent<FishingHook>();
                _score = fish.Score;
                _scoreManager.AddMoney(_score);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            _isCatchUp = false;
        }
    }
    public void GameStart()
    {
        switch (_hookNumber)
        {
            case 1:
                break;
            case 2:
                Hook2Active();
                break;
            case 3:
                Hook3Active();
                break;
        }
        switch (_throwPower)
        {
            case 1:
                _anim.Play("Power1");
                break;
            case 2:
                _anim.Play("Power2");
                break;
            case 3:
                _anim.Play("Power3");
                break;
        }
    }
    private void Hook1Active()
    {
    }
    private void Hook2Active()
    {
        var hook2 = transform.Find("Fishhook2");
        hook2.gameObject.SetActive(true);
    }
    private void Hook3Active()
    {
        Hook2Active();
        var hook3 = transform.Find("Fishhook3");
        hook3.gameObject.SetActive(true);
    }
    private void ApplyRootMotion()
    {
        _anim.applyRootMotion = true;
    }
}
