﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //敵プレハブ
    public GameObject enemyPrefab;

    private ObjectPooling _pool;
    
    public float minTime = 2f; // 時間間隔の最小値 
    public float maxTime = 5f; // 時間間隔の最大値
    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;    // 経過時間

    private Vector3 minVec = new Vector3(-1, 0, -1); // 出現場所の最小値  ※ 距離に変える予定
    private Vector3 maxVec = new Vector3(1, 0, 1); // 出現場所の最大値  ※ 距離に変える予定

    private float minDistance = 3;
    private float maxDistance = 5;


    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomF(minTime, maxTime);
        _pool = gameObject.GetComponent<ObjectPooling>();
        _pool.CreatePool(enemyPrefab, 10, enemyPrefab.GetInstanceID());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time > interval)
        {
            _pool.GetPoolObj(enemyPrefab.GetInstanceID(), GetRandomVec(minVec, maxVec).normalized * GetRandomF(minDistance, maxDistance));
            _pool.GetPoolObj(enemyPrefab.GetInstanceID(), GetRandomVec(minVec, maxVec).normalized * GetRandomF(minDistance, maxDistance));
            _pool.GetPoolObj(enemyPrefab.GetInstanceID(), GetRandomVec(minVec, maxVec).normalized * GetRandomF(minDistance, maxDistance));
            _pool.GetPoolObj(enemyPrefab.GetInstanceID(), GetRandomVec(minVec, maxVec).normalized * GetRandomF(minDistance, maxDistance));
            _pool.GetPoolObj(enemyPrefab.GetInstanceID(), GetRandomVec(minVec, maxVec).normalized * GetRandomF(minDistance, maxDistance));
            _pool.GetPoolObj(enemyPrefab.GetInstanceID(), GetRandomVec(minVec, maxVec).normalized * GetRandomF(minDistance, maxDistance));
            time = 0f;
            interval = GetRandomF(minTime,maxTime);
        }
    }
    private float GetRandomF(float min, float max)
    {
        return Random.Range(min, max);
    }
    private Vector3 GetRandomVec(Vector3 min, Vector3 max)
    {
        Vector3 vec;
        vec.x = Random.Range(min.x, max.x);
        vec.y = Random.Range(min.y, max.y);
        vec.z = Random.Range(min.z, max.z);
        return vec;
    }
}
