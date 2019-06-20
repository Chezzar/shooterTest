using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuStartScreen : MonoBehaviour
{
    private Text TotalTime;

    private void Awake()
    {
        TotalTime = transform.Find("TotalTimeUI").GetComponent<Text>();
    }

    private void Update()
    {
        string time = Time.time.ToString();
        TotalTime.text = "App Time: "  + time;
    }

    public void ArenaFPS() {
        Score.MyType = Score.CameraType.FPS;

        SceneManager.LoadScene("Arena");
    }

    public void ArenaTPS()
    {
        Score.MyType = Score.CameraType.TPS;

        SceneManager.LoadScene("Arena");
    }

    public void Quit()
    {

#if !UNITY_EDITOR
        Application.Quit();
#endif

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
