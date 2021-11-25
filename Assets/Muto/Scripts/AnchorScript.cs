using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorScript : MonoBehaviour
{
    [SerializeField] string _fishTag = default;
    [SerializeField] Vector3 _offSet;
    bool isOn;
    GameManager _gm;
    FishingHookScript _FHS;
    Collider2D _c;
    GameObject _fish;

    private void Start()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();
        _FHS = GameObject.FindObjectOfType<FishingHookScript>();
        _c = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(!_FHS.IsOn)
        {
            if(_fish)
            Destroy(_fish);
            _c.enabled = true;
            isOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_fishTag))
        {
            if (!isOn)
            {
                _fish = collision.gameObject;
                var fish = collision.GetComponent<FishScript>();
                fish.transform.SetParent(this.transform);
                fish.transform.position = this.transform.position + _offSet;
                fish.transform.right = this.transform.up;
                _gm.Money += fish.Score;
                var fc = collision.GetComponent<Collider2D>();
                fc.enabled = false;
                _c.enabled = false;

                isOn = true;
            }
        }
    }
}
