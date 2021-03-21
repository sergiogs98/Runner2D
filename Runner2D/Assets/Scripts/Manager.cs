using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private int puntuacion = 0;

    // Label de puntuacion
    public Text textoPuntos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementaPuntos(int puntos)
    {
        puntuacion += puntos;
        textoPuntos.text = puntuacion.ToString();
    }
}
