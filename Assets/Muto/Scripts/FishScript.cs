using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishScript : MonoBehaviour
{
    [SerializeField] int _score = 100;
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] string _areaTag = "";
    Rigidbody2D _rb;
    float _noiseY;

    public int Score { get => _score;}

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _noiseY = Random.Range(0f, 10f);
    }

    private void Update()
    {
        Move();
    }
    void Move()
    {
        _rb.velocity = this.transform.right * Mathf.PerlinNoise(Time.time, _noiseY) * _moveSpeed;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(_areaTag))
        {
            Destroy(this.gameObject);
        }
    }
}
