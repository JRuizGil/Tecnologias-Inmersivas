using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolaciones : MonoBehaviour
{

    public Transform ObjetoAmover;

    public Vector3 PosInicial = new Vector3 (0f, 0f, 0f);
    public Vector3 PosFinal = new Vector3 (10f, 0f, 0f);

    public float Duracion = 5f;
    public float temporizador = 0f;


    public Light Miluz;

    public Color ColorInicial = Color.white;
    public Color ColorFinal = Color.red;

    void Start()
    {
        InvokeRepeating("MiFuncion", 3.0f, 4.0f);
        Debug.Log("Hola");
    }    
    void Update()
    {
        temporizador += Time.deltaTime;
        float t = Mathf.Clamp01(temporizador/ Duracion);
        ObjetoAmover.position = Vector3.Lerp(PosInicial, PosFinal, t);

        Miluz.color = Color.Lerp(ColorInicial, ColorFinal, t);
    }

    void MiFuncion()
    {
        Debug.Log("Mi Funcion a sido invocada");
    }

}
