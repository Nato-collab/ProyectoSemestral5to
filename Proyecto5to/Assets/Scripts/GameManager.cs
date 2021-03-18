using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveData SD;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        SD.Cargar();
        //SD.Data.HighScore = 0;
        score = 0;
    }

    private void OnApplicationQuit()
    {
        SD.Guardar();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > SD.Data.HighScore)
        {
            print("nuevo high score: " + score);
            SD.Data.HighScore = score;
        }
    }
}
