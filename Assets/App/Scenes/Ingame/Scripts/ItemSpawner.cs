using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _ItemPrefabs;

    // 生成するアイテム位置の範囲(ランダム)
    [SerializeField] Vector3 _SpawnRange = new Vector3(10, 10, 10);

    List<GameObject> _SpawnedItems = new List<GameObject>();

    // 時間
    float _IntervalCount = 0;
    readonly float SpawnInterval = 4;

    public void Init()
    {
        this.Dispose();

        // アイテムを生成
        for (int i = 0; i < 10; i++)
        {
            this._SpawnRandomItem();
        }
    }

    public void OnUpdate()
    {
        // 4秒に1回、アイテムを生成
        this._IntervalCount += Time.deltaTime;
        if (this._IntervalCount > SpawnInterval)
        {
            this._IntervalCount = 0;
            this._SpawnRandomItem();
        }
    }

    void _SpawnRandomItem()
    {
        var itemPrefab = this._ItemPrefabs[Random.Range(0, this._ItemPrefabs.Length)];
        var itemInstance = Instantiate(itemPrefab);

        itemInstance.transform.SetParent(this.transform);
        itemInstance.transform.localPosition = new Vector3(
            Random.Range(-this._SpawnRange.x, this._SpawnRange.x),
            Random.Range(0, 0),
            Random.Range(-this._SpawnRange.z, this._SpawnRange.z)
        );

        this._SpawnedItems.Add(itemInstance);
    }

    public void Dispose()
    {
        // 生成済みのアイテムを削除
        foreach (var item in this._SpawnedItems)
        {
            if (item != null)
                Destroy(item);
        }
        this._SpawnedItems.Clear();
    }
}
