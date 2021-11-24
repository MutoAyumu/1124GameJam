using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishScript : MonoBehaviour
{
    [SerializeField] int _score = 100;
    [SerializeField] float _moveSpeed = 1;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    private void Update()
    {
        Move();
    }
    void Move()
    {
        _rb.velocity = this.transform.right * Mathf.PerlinNoise(Time.time, 0) * _moveSpeed;
    }
}
