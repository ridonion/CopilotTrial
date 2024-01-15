using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameResultController : MonoBehaviour
{
    Animator _Animator;
    [SerializeField] TMP_Text _ScoreText;
    [SerializeField] Button _RetryButton;

    Action _RetryAction;

    void Awake()
    {
        this._Animator = GetComponent<Animator>();
    }

    public void Init(Action retryAction)
    {
        // リザルトを非表示
        _ = this._Animator.PlayAsync("Hide");
        // ゲーム終了イベントを受け取る
        IngameEventHolder.Instance.OnGameEndEvent += ShowResult;

        this._RetryAction = retryAction;
    }

    void ShowResult(int score)
    {
        this._ScoreText.text = score.ToString();
        this._RetryButton.onClick.AddListener(() =>
        {
            // リトライ
            this._RetryAction?.Invoke();
        });

        _ = this._Animator.PlayAsync("Finish");
    }
}
