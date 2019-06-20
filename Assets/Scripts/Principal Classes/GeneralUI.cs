using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script echo para que pueda funcionar exista o no un UI
public class GeneralUI : MonoBehaviour
{
    private Text AmmoText, HealtText, ScoreText, TimeText;
    Score ScoreData;
    GunController AmmoData;
    Player HealtData;

    private void Awake()
    {
        Initialize();
        ScoreData = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    private void Update()
    {
        UpdateTextArena();
    }

    void UpdateTextArena() {

        AmmoText.text = "Ammo:  " + AmmoData.Ammo.ToString();
        HealtText.text = "Healt:  " + HealtData.Life.ToString();
        ScoreText.text = "Score:  " + ScoreData.MyScore.ToString();
        TimeText.text = "Time:  " + ScoreData.TimeScene.ToString();
    }

    void Initialize() {

        AmmoText = transform.Find("Ammo UI").GetComponent<Text>();
        HealtText = transform.Find("Healt UI").GetComponent<Text>();
        ScoreText = transform.Find("Score UI").GetComponent<Text>();
        TimeText = transform.Find("Time UI").GetComponent<Text>();

        ScoreData = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        AmmoData = Player.transform.Find("Gun").GetComponent<GunController>();
        HealtData = Player.GetComponent<Player>();

        AmmoText.text = "Ammo:  " + AmmoData.Ammo.ToString();
        HealtText.text = "Healt:  " + HealtData.Life.ToString();
        ScoreText.text = "Score:  " + ScoreData.MyScore.ToString();
        TimeText.text = "Time:  " + ScoreData.TimeScene.ToString();

    }
}
