using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public float Power 
    {
        get { return _power; }
        set { _power = value; }
    }
    [SerializeField]private float _power;
    private float _movePos = 0.01f;
    private bool _isCatchUp = false;
    private void Start()
    {

    }
    private void Update()
    {
        if(Input.GetMouseButton(0) && !_isCatchUp)
        {
            this.gameObject.transform.Translate(0, _movePos * _power, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            _isCatchUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            _isCatchUp = false;
        }
    }
}
