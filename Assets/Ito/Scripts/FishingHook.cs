using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHook : MonoBehaviour
{ 
    public float Score { get => _score; set => _score = value; }
    public FishScript FishScript { get => _fishScript; set => _fishScript = value; }

    [SerializeField] string _fishTag;
    [SerializeField] Vector3 _offSet;
    private float _score;
    private float _fishRotate = 90f;
    private bool _isHit = false;
    private FishScript _fishScript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _fishTag)
        {
            if (_isHit) return;

            var fish = collision.GetComponent<FishScript>();
            fish.transform.SetParent(transform);
            fish.transform.position = this.transform.position + _offSet;
            fish.transform.Rotate(0f, 0f, _fishRotate);
            _score = fish.Score;

            _fishScript = fish;

            var collider = GetComponent<Collider2D>();
            collider.enabled = false;

            _isHit = true;
        }
    }
}
