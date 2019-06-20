using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif 

public class MenuPause : MonoBehaviour
{
    Canvas Menu;

    public delegate void Paused();
    public static event Paused PausedAction;
    private bool PlayerIsDead = false;

    private Text TotalTime;

    private void Awake()
    {
        TotalTime = transform.Find("TotalTimeUI").GetComponent<Text>();

        Menu = GetComponent<Canvas>();
    }
    void Start()
    {
        Menu.enabled = false;
        
    }

    private void Update()
    {
        TotalTime.text = "Total Time :  " + Time.time.ToString();

        if (InputManager.GetKey("p") || Input.GetKeyDown(KeyCode.Escape) && !PlayerIsDead) {

            if (PausedAction != null) {
                PausedAction();
            }

            Cursor.visible = true;
            Menu.enabled = !Menu.enabled;
            Time.timeScale = 0;
        }
    }

    public void DeadPause()
    {
        PlayerIsDead = true;

        transform.Find("Continue").gameObject.SetActive(false);
        transform.Find("Text").GetComponent<Text>().text = "Has perdido";
        transform.Find("Text").GetComponent<Text>().color = Color.red;
        if (PausedAction != null)
        {
            PausedAction();
        }

        Cursor.visible = true;
        Menu.enabled = !Menu.enabled;
        Time.timeScale = 0;
    }

    public void Continue() {

        if (!PlayerIsDead)
        {
            if (PausedAction != null)
            {
                PausedAction();
            }

            Cursor.visible = false;
            Menu.enabled = !Menu.enabled;
            Time.timeScale = 1;
        }
    }

    public void Retry() {

        Time.timeScale = 1;

        string scene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(scene);
    }

    public void StartScreen()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void Quit() {

#if !UNITY_EDITOR
        Application.Quit();
#endif

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
