using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _menuPanel;
    void Start()
    {

    }
    public void SetActiveMenu(bool isOpen)
    {
        _menuPanel.SetActive(isOpen);
    }

    public void PowerUp(float useMoney)
    {
        if (ScoreManager.Money < useMoney)
        {
            return;
        }
        else
        {
            ScoreManager.Money -= useMoney;
        }
    }
}
