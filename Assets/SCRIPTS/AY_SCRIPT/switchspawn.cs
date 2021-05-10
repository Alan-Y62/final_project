using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchspawn : MonoBehaviour
{
    public GameObject tackler;

    private float nextSpawnTime;
    private float spawnDelay = 2;

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        spawnDelay += Mathf.Sin(Time.deltaTime);
        nextSpawnTime = Time.time + spawnDelay;
        var clone = Instantiate(tackler, transform.position, transform.rotation);
        clone.transform.parent = gameObject.transform;
    }

    private bool ShouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }
}
