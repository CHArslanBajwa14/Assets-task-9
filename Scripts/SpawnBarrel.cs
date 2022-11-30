using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrel : MonoBehaviour
{
    public GameObject barrelPrefabs;
    public float spawnInterval = 2f;
    public float startDelay = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(barrelPrefabs,transform.position, Quaternion.identity);
        Invoke(nameof(Spawn),Random.Range(spawnInterval,startDelay));
    }
}
