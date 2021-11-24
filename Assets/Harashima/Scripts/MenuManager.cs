using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //メニューを表示するパネル
    [SerializeField] GameObject _menuPanel;
    //釣り糸のスクリプトを参照
    [SerializeField] FishingLine _fishingLine;
    //引き上げる速度の上昇値
    [SerializeField] int _powerUp = 1;
    /// <summary>
    /// メニューパネルのオンオフ
    /// </summary>
    /// <param name="isOpen"></param>
    public void SetActiveMenu(bool isOpen)
    {
        _menuPanel.SetActive(isOpen);
    }
    /// <summary>
    /// 釣り糸を引き上げる速度を上げる関数
    /// </summary>
    /// <param name="useMoney"></param>
    public void PowerUp(float useMoney)
    {
        if (ScoreManager.Money < useMoney)
        {
            return;
        }
        else
        {
            //Powerを参照して上げる、お金を減らす。
            ScoreManager.Money -= useMoney;
            _fishingLine.PullPower += _powerUp;
        }
    }

    /// <summary>
    /// 釣りの開始水深を深くする関数
    /// </summary>
    /// <param name="useMoney"></param>
    public void ThrowUp(float useMoney)
    {
        if (ScoreManager.Money < useMoney)
        {
            return;
        }
        else
        {
            //Throwを参照して上げる、お金を減らす。
            ScoreManager.Money -= useMoney;
            _fishingLine.ThrowPower += _powerUp;
        }
    }

    /// <summary>
    /// フックのサイズをでかくする関数
    /// </summary>
    /// <param name="useMoney"></param>

    public void IncreaseHook(float useMoney)
    {
        if (ScoreManager.Money < useMoney)
        {
            return;
        }
        else
        {
            //Hookを参照して数を増やす、お金を減らす。
            ScoreManager.Money -= useMoney;
            _fishingLine.HookNumber += _powerUp;
        }
    }
}
