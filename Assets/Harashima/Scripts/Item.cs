using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject _charmImage;
    [SerializeField] GameObject _traderImage;
    static bool isCharm = false;
    static bool isTrader = false;
    public static bool IsCharm { get => isCharm; set => isCharm = value; }
    public static bool IsTrader { get => isTrader; set => isTrader = value; }
    public void GetCharm()
    {
        _charmImage.SetActive(true);
        isCharm = true;
    }
    public void GetTrader()
    {
        _traderImage.SetActive(true);
        isTrader = true;
        Debug.Log(isTrader);
    }
}
