using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameLogic
{
    public enum State
    {
        None,
        Init,
        Playing,
        End,
    }
    // ゲーム状態
    public State GameState { get; private set; } = State.None;

    IngameView _View;

    // 残り時間
    float p_remainTime;
    float _RemainTime
    {
        get { return this.p_remainTime; }
        set
        {
            this.p_remainTime = value;
            if (value > this.MAX_TIME) value = this.MAX_TIME;
            if (value < 0) value = 0;

            // UIに反映
            IngameEventHolder.Instance.ChangeRemainTime(value);
        }
    }
    readonly float MAX_TIME = 60f;

    public void Init(IngameView view)
    {
        this._View = view;
        this.GameState = State.Init;
        this._RemainTime = this.MAX_TIME;

        // UI初期化
        view.GameUIController.Init();

        // 3D初期化
        view.CharaBehaviour.Init();
        view.CameraController.Init(view.CharaBehaviour.gameObject);

        view.ItemSpawner.Init();
    }

    public void Start()
    {
        this.GameState = State.Playing;
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        if (this.GameState != State.Playing) return;

        // 残り時間を減らす
        this._RemainTime -= Time.deltaTime;
        if (this._RemainTime <= 0)
        {
            this.GameState = State.End;
            IngameEventHolder.Instance.GameEnd(this._View.CharaBehaviour.Score);
            return;
        }

        // キャラクターの移動
        this._View.CharaBehaviour.OnUpdate();
        this._View.CameraController.OnUpdate();

        // アイテムの生成
        this._View.ItemSpawner.OnUpdate();
    }
}
