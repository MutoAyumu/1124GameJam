using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishingHookScript : MonoBehaviour
{
    [SerializeField] LineRenderer _line = default;
    [SerializeField] Transform[] _anchorPos = default;
    [SerializeField] Transform _linePos = default;
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _stopDistance = 0.2f;

    Vector2 _move;
    Rigidbody2D _rb;
    int _count;
    bool isOn;
    int _num;

    public bool IsOn { get => isOn; set => isOn = value; }
    public int Num { get => _num; set => _num = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Throw();
        DrawLine();
    }

    void Throw()
    {
        if(Input.GetButtonDown("Fire1") && !IsOn)
        {
            IsOn = true;
        }

        float distance = Vector3.Distance(this.transform.position, _anchorPos[_count].position);

        if(!IsOn)
        {
            _rb.velocity = Vector2.zero;
        }
        else if (distance > _stopDistance && IsOn)
        {
            _move = (_anchorPos[_count].transform.position - this.transform.position);
            //_rb.velocity = new Vector2(_move.x, _move.y).normalized * _moveSpeed;
            this.transform.Translate(_move.normalized * _moveSpeed * Time.deltaTime);
        }
        else if(IsOn)
        {
            _count = (_count + 1) % _anchorPos.Length;
            Num++;
        }

        if(Num % 2 == 0 && Num != 0)
        {
            IsOn = false;
            Num = 0;
        }
    }
    void DrawLine()
    {
        if(_line)
        {
            _line.SetPosition(0, this.transform.position);
            _line.SetPosition(1, _linePos.transform.position);
        }
    }
}
