using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //プレイヤーのお金を保持しておく変数
    static float _money = 0f;

    //お金を表示するテキスト
    static Text _moneyText;

    //お金の数字が変更される速度
    [SerializeField] float _duration;
    public static float Money { get => _money; set => _money = value; }

    private void Start()
    {
        GameObject gm;
        gm = GameObject.Find("MoneyText");
        _moneyText = gm.GetComponent<Text>();
        ResetScore();
    }

    public void AddMoney(float money)
    {
        if (Item.IsTrader)
        {
            money *= 3;
        }
        //釣り上げた魚を参照してmoney変数に足していく
        //お金がヌルヌル動くコルーチンを実行
        StartCoroutine(ScoreAnimation(_money, _money + money, _duration));
        _money += money;
        Debug.Log(_money);
    }
    public void ResetScore()
    {
        _money = 0f;
        int value = Mathf.FloorToInt(_money);
        _moneyText.text = "Score:" + value.ToString("");
    }

    IEnumerator ScoreAnimation(float startScore, float endScore, float duration)
    {
        // 開始時間
        float startTime = Time.time;

        // 終了時間
        float endTime = startTime + duration;

        do
        {
            // 現在の時間の割合
            float timeRate = (Time.time - startTime) / duration;

            // 数値を更新
            float updateValue = (float)((endScore - startScore) * timeRate + startScore);
            int newvalue = Mathf.FloorToInt(updateValue);
            // テキストの更新
            _moneyText.text = "Score:" + newvalue.ToString("");

            // 1フレーム待つ
            yield return null;

        } while (Time.time < endTime);

        // 最終的な着地のスコア
        int newendScore = Mathf.FloorToInt(endScore);
        _moneyText.text = "Score:" + newendScore.ToString("");
    }

}
    

