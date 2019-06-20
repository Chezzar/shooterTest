using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private MenuPause PausedData;
    private bool Hited = false;
    private Rigidbody rb;
    public SFManager SoundManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SoundManager = GameObject.Find("SFManager").gameObject.transform.GetComponent<SFManager>();
        PausedData = GameObject.Find("MenuPause").GetComponent<MenuPause>();
    }
    
    void Start()
    {
        Life = 20;
    }

    
    void Update()
    {

        if (Hited) {
            StartCoroutine(HitedWaitTime());
        }
        
    }

    void Damage(int amount) {

        Life -= amount;
        PushHit();
        SoundManager.CreateSound("Hit");

        if (Life <= 0)
            PausedData.DeadPause();

        Hited = true;
    }

    void PushHit() {

        rb.AddForce(-transform.forward  * 500);
    }

    IEnumerator HitedWaitTime() {

        yield return new WaitForSeconds(1);
        Hited = false;
    }

    protected void HealtUp(int size)
    {

        Life += size;

        SoundManager.CreateSound("Healt");

        if (Life > 30)
            Life = 30;

    }
}
