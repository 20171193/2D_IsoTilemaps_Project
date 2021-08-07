using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseButton : MonoBehaviour
{
    bool isPaused = false;
    Text text;
    [SerializeField]
    GameObject PauseMenu;
    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }
    public void OnClickPause()
    {
        if (isPaused)
        {
            Time.timeScale = 1.0f;
            text.text = "| |";
            isPaused = false;
            PauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            text.text = "▷";
            isPaused = true;
            PauseMenu.SetActive(true);
        }
    }
}
