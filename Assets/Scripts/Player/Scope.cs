using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    Rect scopeRect;
    Texture scopeTex;

    void Awake()
    {

        float scopeSize = Screen.width * 0.05f;

        scopeTex = Resources.Load("UI/scope") as Texture;

        scopeRect = new Rect(Screen.width / 2 - scopeSize / 2, Screen.height / 2 - scopeSize / 2, scopeSize, scopeSize);
    }

    private void Start()
    {
        MenuPause.PausedAction += Pause;
    }

    void OnGUI()
    {

        if(Score.MyType == Score.CameraType.FPS)
            GUI.DrawTexture(scopeRect, scopeTex);
    }

    void Pause()
    {
      
    }
}
