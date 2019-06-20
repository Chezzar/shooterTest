using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommon : Character
{

    private GameObject Player;
    private Rigidbody rb;
    private GameObject Loot;

    public bool IsSearch;

    private enum EnemyState {

        wander,
        seach
    }

    private EnemyState MyState = EnemyState.wander;

    private void OnEnable()
    {
        Score.enemyHelp += enemyHelp;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;

        Loot = GenerateLoot();
    }

    // Start is called before the first frame update
    void Start()
    {
        Life = 2;
        Speed = 200;

    }

    private void Update()
    {
        if (IsSearch) {

            StartCoroutine(search());
            IsSearch = false;
        }
    }

    private void FixedUpdate()
    {
        if (MyState == EnemyState.seach)
            SearchPlayer(Player);
        else if (MyState == EnemyState.wander)
            Move();
    }

    void LifeReduction(int force) {

        Life -= force;

        if (Life <= 0)
        {
            Dead();
        }
    }

    void Dead() {

        GameObject.Find("Score").SendMessage("ScoreUp");

        if(Random.Range(0,5) <= 1)
            Instantiate(Loot,transform.position,Quaternion.identity);

        Destroy(gameObject);
    }

    protected override void Move(){}

    void SearchPlayer(GameObject PlayerChar) {

        transform.LookAt(Player.transform);

        Vector3 mov_forward = transform.forward * Speed * Time.deltaTime;

        rb.velocity = new Vector3(mov_forward.x, rb.velocity.y, mov_forward.z);

    }

    //funcion creada por si se quieren poner mas estados a este enemigo
    IEnumerator search() {


        float dist = Vector3.Distance(transform.position , Player.transform.position);


        if (dist < 100)
            MyState = EnemyState.seach;
        else if (dist >= 100)
            MyState = EnemyState.wander;

        yield return new WaitForSeconds(0.01f);

        IsSearch = true;
    }

    void enemyHelp() {

        Speed += 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.SendMessage("Damage",1);
        }
    }

    GameObject GenerateLoot() {


        int lootClue = Random.Range(0, 4);

        if (lootClue >= 0 && lootClue <= 2)
        {
            return Resources.Load("Ammo") as GameObject;
        }
        else
        {

            return Resources.Load("MedicKit") as GameObject;
        }
    }
}
