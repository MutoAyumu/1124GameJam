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
    [SerializeField,  Range(0.01f, 0.1f)] float _power;
    bool _isCatchUp = false;
    private void Start()
    {

    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            this.gameObject.transform.Translate(0, -_power , 0);
        }
        else if(!_isCatchUp)
        {
           this.gameObject.transform.Translate(0, _power, 0);
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
