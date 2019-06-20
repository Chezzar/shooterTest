using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private float lifeTime;
    private Rigidbody rb;
    private int BulletForce = 1;
    private string sceneName;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {

        lifeTime += Time.deltaTime;

        if (lifeTime > 1.5f) {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3 vel = transform.forward * Time.fixedDeltaTime * 600f;
        rb.velocity = vel;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {

            other.SendMessage("LifeReduction", BulletForce);
            Destroy(gameObject);
        }
    }
}
