using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI ScoreUi;
    [SerializeField] private GameObject StartmenuUi;
    [SerializeField] private GameObject EndmenuUi;
    [SerializeField] private TextMeshProUGUI gameoverscore;
    [SerializeField] private TextMeshProUGUI gameoverHighscore;



    ScoreScript score;
    private void Start()
    {
        score = ScoreScript.instance;
        score.gameover.AddListener(Gameover);
    }
    public void StartButton()
    {
        
        score.StartGame();
        EndmenuUi.SetActive(false);

    }
    public void Gameover() 
    {
        
        EndmenuUi.SetActive(true);

        gameoverscore.text = "Очки: " + score.CurrentScore;
        gameoverHighscore.text = "Рекорд: " + score.CurrentScore;
    }
    private void OnGUI()
    {
        ScoreUi.text = score.CurrentScore.ToString();
    }

}
