using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFManager : MonoBehaviour
{
    private GameObject ShootSound;
    private GameObject HitSound;
    private GameObject ReloadSound;
    private GameObject HealtSound;

    private void Start()
    {
        ShootSound = Resources.Load("ShootSound") as GameObject;
        HitSound = Resources.Load("HitSound") as GameObject;
        ReloadSound = Resources.Load("ReloadSound") as GameObject;
        HealtSound = Resources.Load("HealtSound") as GameObject;
    }

    public void CreateSound(string Soundname) {

        switch (Soundname) {

            case "Shoot": {

                    Instantiate(ShootSound);
                    break;
                }

            case "Hit":
                {
                    Instantiate(HitSound);
                    break;
                }

            case "Reload":
                {
                    Instantiate(ReloadSound);
                    break;
                }

            case "Healt":
                {
                    Instantiate(HealtSound);
                    break;
                }

        }

    }
}
