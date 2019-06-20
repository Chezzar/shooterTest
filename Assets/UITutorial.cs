using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : MonoBehaviour
{
    float time;
    
    void Update()
    {

        time += Time.deltaTime;

        if (InputManager.GetKey("t"))
            Destroy(gameObject);

        if (time > 6)
            Destroy(gameObject);
        
    }
}
