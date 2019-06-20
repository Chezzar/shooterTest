using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public enum CameraType {
        FPS,
        TPS
    }

    public static CameraType MyType = CameraType.FPS;

    public delegate void EnemyUpVelocity();
    public static event EnemyUpVelocity enemyHelp;

    private float timeTotal;
    public float TimeTotal
    {

        get { return timeTotal; }
        set { timeTotal = value; }
    }

    private float timeScene;
    public float TimeScene{

        get { return timeScene; }
        set { timeScene = value;}

    }

    private int myScore;
    public int MyScore {

        get { return myScore; }
        set { myScore = value; }
    }

    
    void Start()
    {
        
    }

    
    void Update()
    {

        TimeScene += Time.deltaTime;
        TimeTotal = Time.time;
    }

    void ScoreUp() {

        MyScore += 1;

        if (((MyScore % 2) == 0)  && enemyHelp != null) {
            enemyHelp();
        }
    }
}
