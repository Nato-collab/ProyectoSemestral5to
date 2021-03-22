using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_in_game : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public Text score;
    public Text HScore;
    public Text Timer;
    void Start()
    {
        if (gameManager == null) {
            gameManager=GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>();
        }

        HScore.text ="High Score: " + gameManager.SD.Data.HighScore.ToString();// obtenenr high score gaurdado
    }

    // Update is called once per frame
    void Update()
    {
        if (score.text != "Score: " + gameManager.score.ToString()) {
            score.text = "Score: " + gameManager.score.ToString();//acutalizar el valor del score
        }
        if (HScore.text != "High Score: " + gameManager.SD.Data.HighScore.ToString())
        {
            HScore.text = "High Score: " + gameManager.SD.Data.HighScore.ToString();//acutalizar el valor del high score
        }
    }
}
