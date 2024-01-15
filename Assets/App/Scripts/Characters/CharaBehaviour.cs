using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharaBehaviour : MonoBehaviour
{
    Animator _Animator;
    Rigidbody _Rigidbody;

    //-------------------
    // スタミナ
    //-------------------
    public static readonly float MAX_STAMINA = 100f;
    float p_stamina;
    float _Stamina
    {
        get { return p_stamina; }
        set
        {
            // 最大値を超えないようにする
            if (value > MAX_STAMINA) value = MAX_STAMINA;

            p_stamina = value;
            IngameEventHolder.Instance.ChangeStamina(value);
        }
    }

    //-------------------
    // スコア
    //-------------------
    public static readonly int MAX_SCORE = 999999;
    int p_score;
    public int Score
    {
        get { return p_score; }
        private set
        {
            // 最大値を超えないようにする
            if (value > MAX_SCORE) value = MAX_SCORE;

            p_score = value;
            IngameEventHolder.Instance.ChangeScore(value);
        }
    }

    public void Init()
    {
        this._Animator = GetComponent<Animator>();
        this._Rigidbody = GetComponent<Rigidbody>();

        // 位置を初期化
        this.transform.localPosition = Vector3.zero;
        this.transform.eulerAngles = new Vector3(0, 180, 0);

        // パラメーターを初期化
        this.Score = 0;
        this._Stamina = MAX_STAMINA;
    }

    public void OnUpdate()
    {
        //-------------------
        // 移動
        //-------------------
        // キー入力を取得
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // 重力を受けるように移動
        var tmpY = this._Rigidbody.velocity.y;
        var tmpXZ = new Vector3(x, 0, z).normalized * 5f;

        // 走っている
        bool isRun = Input.GetKey(KeyCode.Space) && this._Stamina > 0;
        if (isRun)
        {
            this._Stamina -= 2f;
            tmpXZ *= 2f;
        }
        else
        {
            // スタミナを回復
            this._Stamina += 1f;
        }
        this._Rigidbody.velocity = new Vector3(tmpXZ.x, tmpY, tmpXZ.z);


        //-------------------
        // キャラクターの向き
        //-------------------
        // 入力方向を向く  
        if (x != 0 || z != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(x, 0, z));
        }

        // Animatorに速度を渡す
        _Animator.SetFloat("Speed", _Rigidbody.velocity.magnitude);
    }

    // 動物と衝突した
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            // 衝突した動物を消す
            Destroy(collision.gameObject);

            // スコアを加算
            this.Score += 100;
        }
    }
}
