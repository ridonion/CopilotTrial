using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngameEventHolder
{
    public static IngameEventHolder Instance = new IngameEventHolder();

    public void Init()
    {
        this._Dispose();
    }

    // スタミナ変更イベント
    public delegate void OnChangeStamina(float stamina);
    public event OnChangeStamina OnChangeStaminaEvent;
    public void ChangeStamina(float stamina)
    {
        this.OnChangeStaminaEvent?.Invoke(stamina);
    }

    // スコア変更イベント
    public delegate void OnChangeScore(int score);
    public event OnChangeScore OnChangeScoreEvent;
    public void ChangeScore(int score)
    {
        this.OnChangeScoreEvent?.Invoke(score);
    }

    // 残り時間変更イベント
    public delegate void OnChangeRemainTime(float remainTime);
    public event OnChangeRemainTime OnChangeRemainTimeEvent;
    public void ChangeRemainTime(float remainTime)
    {
        this.OnChangeRemainTimeEvent?.Invoke(remainTime);
    }

    // ゲーム終了イベント
    public delegate void OnGameEnd(int score);
    public event OnGameEnd OnGameEndEvent;
    public void GameEnd(int score)
    {
        this.OnGameEndEvent?.Invoke(score);
    }


    void _Dispose()
    {
        this.OnChangeStaminaEvent = null;
        this.OnChangeRemainTimeEvent = null;
        this.OnGameEndEvent = null;
    }
}