using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public SAVEDATACLASS Data; //es visible desde Inspector

    public void Guardar()
    {
        //Generamos el formato Json
        string Archivo = JsonUtility.ToJson(Data);
        //Lo guardamos con PlayerPrefs
        PlayerPrefs.SetString("KeySave", Archivo);
    }
    public void Cargar()
    {
        string Archivo = PlayerPrefs.GetString("KeySave");
        //Solo seguridad que si exista algo
        if (!string.IsNullOrEmpty(Archivo))
        {
            Data = JsonUtility.FromJson<SAVEDATACLASS>(Archivo);
        }
    }
}

[System.Serializable]
public class SAVEDATACLASS
{
    public int HighScore;
}
