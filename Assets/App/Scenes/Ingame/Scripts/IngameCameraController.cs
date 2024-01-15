using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IngameCameraController : MonoBehaviour
{
    GameObject _Target;
    Vector3 _Offset;

    readonly Vector3 INIT_POS = new Vector3(64, 12, 35);

    public void Init(GameObject target)
    {
        transform.position = INIT_POS;

        this._Target = target;
        this._Offset = transform.position - target.transform.position;
    }

    public void OnUpdate()
    {
        if (this._Target == null) return;

        // ターゲットの位置を追従
        transform.position = this._Target.transform.position + this._Offset;
    }
}
