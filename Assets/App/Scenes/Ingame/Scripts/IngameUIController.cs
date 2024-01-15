using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIController : MonoBehaviour
{
    // タイマー
    [SerializeField] TMP_Text _TimerText;

    // スコア
    [SerializeField] TMP_Text _ScoreText;

    // スタミナゲージ
    [SerializeField] Slider _StaminaGauge;

    public void Init()
    {
        this._StaminaGauge.maxValue = CharaBehaviour.MAX_STAMINA;
        // スタミナ変更イベントを受け取る
        IngameEventHolder.Instance.OnChangeStaminaEvent += ChangeStamina;

        // 残り時間変更イベントを受け取る
        IngameEventHolder.Instance.OnChangeRemainTimeEvent += ChangeRemainTime;

        // スコア変更イベントを受け取る
        IngameEventHolder.Instance.OnChangeScoreEvent += ChangeScore;
    }

    void ChangeStamina(float stamina)
    {
        // スタミナゲージを更新
        this._StaminaGauge.value = stamina;
    }

    void ChangeRemainTime(float remainTime)
    {
        // 残り時間を更新
        this._TimerText.text = remainTime.ToString("F2");
    }

    void ChangeScore(int score)
    {
        // スコアを更新
        this._ScoreText.text = score.ToString();
    }
}
