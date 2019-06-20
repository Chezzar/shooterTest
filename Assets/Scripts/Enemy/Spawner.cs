using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private GameObject Enemy;

    private void Awake()
    {
        Enemy = Resources.Load("Enemy") as GameObject;
    }
    
    void Start()
    {
        InvokeRepeating("Spawn", 5, 5);
    }

    void Spawn() {

        Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    void SpawnForce() {

       GameObject enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
        enemy.GetComponent<Rigidbody>().AddForce(new Vector3(0,400,0));
    }
}
