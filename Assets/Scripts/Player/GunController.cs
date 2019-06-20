using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    protected bool hasShoot,hasRecharge;
    protected int ammo = 60;
    protected bool paused = false;

    public int Ammo
    {
        get { return ammo; }
        set { ammo = value; }

    }

    public enum TypeShoot {

        gameobject,
        raycast
    }

    public TypeShoot TypeActive;

    private GameObject Bullet;

    public SFManager SoundManager;

    private void Awake()
    {
        SoundManager = GameObject.Find("SFManager").gameObject.transform.GetComponent<SFManager>();
    }

    
    void Start()
    {
        Bullet = Resources.Load("Bullet") as GameObject;
        MenuPause.PausedAction += Pause;
    }

    
    void Update()
    {
        Shoot();

        if (Ammo < 20)
        {
            AutoRecharge();
        }
    }

    void Shoot() {

        if (InputManager.MouseButtonDown(0) && !hasShoot && ammo > 0 && !paused)
        {
            Ammo -= 1;
            SoundManager.CreateSound("Shoot");
            CreateBullet();
            hasShoot = true;
            StartCoroutine(coolDownShoot());
        }
    }

    void AutoRecharge() {

        if (!hasRecharge)
        {
            SoundManager.CreateSound("Reload");
            Ammo += 1;
            hasRecharge = true;
            StartCoroutine(coolDownRecharge());
        }
    }

    void AmmoUp(int amount) {

        SoundManager.CreateSound("Reload");
        Ammo += amount;
    }

    GameObject CreateBullet() {

        GameObject bullet = Instantiate(Bullet,transform.position,transform.rotation);

        return bullet;
    }

    IEnumerator coolDownShoot()
    {

        yield return new WaitForSeconds(0.1f);
        hasShoot = false;
    }

    IEnumerator coolDownRecharge()
    {

        yield return new WaitForSeconds(1.3f);
        hasRecharge = false;
    }

    void Pause()
    {
        paused = !paused;  
    }
}
