using System.Collections;
using System.Collections.Generic;
using RdnUnityBase;
using RdnUnityBase.Define;
using UnityEngine;

public class IngameController : MonoBehaviour
{
    IngameLogic _Logic;

    [SerializeField] IngameView _View;


    [SerializeField] IngameResultController _ResultController;

    // Start is called before the first frame update
    void Awake()
    {
        this._Init();
    }

    void _Init()
    {
        // イベント初期化
        IngameEventHolder.Instance.Init();

        this._Logic = new IngameLogic();

        this._Logic.Init(this._View);
        this._ResultController.Init(() => this._Init());

        // ゲーム開始
        this._Logic.Start();
        SoundManager.Instance.Play(BGM.Ingame);
    }

    void Update()
    {
        this._Logic.OnUpdate();
    }
}
