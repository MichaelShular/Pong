using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private TextMeshProUGUI AIScore;
    [SerializeField] private Canvas winOrLoseState;
    [SerializeField] private TextMeshProUGUI whoWonText;
    private int numPlayerScore = 0;
    private int numAIScore = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numPlayerScore == 11 || numAIScore == 11)
        {
            openWinOrloseScreen();
        }
    }

    public void changePlayerScore()
    {
        numPlayerScore++;
        playerScore.text = numPlayerScore.ToString();
    }

    public void changeAIScore()
    {
        numAIScore++;
        AIScore.text = numAIScore.ToString();
    }

    public void openWinOrloseScreen()
    {
        Time.timeScale = 0;
        winOrLoseState.enabled = true;
        if (numPlayerScore == 11)
        {
            whoWonText.text = "winner";
        }
        else
        {
            whoWonText.text = "loser";
        }
    }
}
