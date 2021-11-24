using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject _charmImage;
    static bool isCharm = false;
    public static bool IsCharm { get => isCharm; set => isCharm = value; }

    public void GetCharm()
    {
        _charmImage.SetActive(true);
        isCharm = true;
    }
}
