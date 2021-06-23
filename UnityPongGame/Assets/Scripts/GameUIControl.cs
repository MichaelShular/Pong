using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIControl : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private GameObject playerPaddle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
            playerPaddle.GetComponent<PlayerControl>().enabled = false;
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 1;
        pauseCanvas.enabled = false;
        playerPaddle.GetComponent<PlayerControl>().enabled = true;

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void gameVolumeControl(float a)
    {
        AudioListener.volume = a;
    }
}
