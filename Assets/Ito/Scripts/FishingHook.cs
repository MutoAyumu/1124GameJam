using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHook : MonoBehaviour
{
    [SerializeField] string _fishTag;
    private float _fishRotate = 90f;
    private bool _isHit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _fishTag)
        {
            if (_isHit) return;

            var fish = collision.GetComponent<FishScript>();
            fish.transform.SetParent(transform);
            fish.transform.Rotate(0f, 0f, _fishRotate);

            var collider = GetComponent<Collider2D>();
            collider.enabled = false;

            _isHit = true;
        }

    }
}
