using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveData SD;
    public int score;
    public int spill_penalty;
    // Start is called before the first frame update
    void Start()
    {
        SD.Cargar();//obtnener datos guardados
        //SD.Data.HighScore = 0;
        score = 0;
    }

    private void OnApplicationQuit()
    {
        SD.Guardar();//guardar los datos cuando se cierra el juego
    }

    // Update is called once per frame
    void Update()
    {
        if (score > SD.Data.HighScore)
        {
            print("nuevo high score: " + score);
            SD.Data.HighScore = score;//actualizar el highscore guardado cuando sea menor que el score
        }
    }
}
