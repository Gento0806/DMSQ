using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyObject;
    [SerializeField] float SpawnTime;
    [SerializeField] Vector3 Spawnrotate;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time >= SpawnTime)
        {
            Instantiate(EnemyObject,this.transform.position,Quaternion.Euler(Spawnrotate));
            time = 0;
        }
    }
}
