using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveData SD;
    public int HS;
    // Start is called before the first frame update
    void Start()
    {
        SD.Cargar();
        //SD.Data.HighScore = 0;
        HS = SD.Data.HighScore;
        print("high score:" + HS);
    }

    private void OnApplicationQuit()
    {
        SD.Guardar();
    }

    // Update is called once per frame
    void Update()
    {
        if (HS > SD.Data.HighScore) {
            print("nuevo high score:" + HS);
            SD.Data.HighScore = HS;
        }
    }
}
