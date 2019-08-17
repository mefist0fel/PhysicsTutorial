using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectGenerator : MonoBehaviour {
    public GameObject prefab;
    public int Count = 10;
    public float Delay = 0.2f;
    public float Offset = 1f;

    float timer = 0;
    int spawnedCount = 0;

    void Update() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = Delay;
            if (spawnedCount < Count)
                SpawnObject(prefab);
        }
    }

    private void SpawnObject(GameObject prefab) {
        var obj = Instantiate(prefab);
        obj.transform.position = transform.position + Random.insideUnitSphere * Offset;
        spawnedCount += 1;
    }
}
