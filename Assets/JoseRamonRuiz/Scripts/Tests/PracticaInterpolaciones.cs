using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticaInterpolaciones : MonoBehaviour
{
    public GameObject ObjetoAmover;

    public Vector3 PosInicial = new Vector3(0f, 0f, 0f);
    public Vector3 PosFinal = new Vector3(10f, 0f, 0f);

    public float Duracion = 5f;
    public float temporizador = 0f;
    public float suavizado = 1f;

    private bool Corriendo = false;

    public Transform Destino;

    void Start()
    {
        
        Instantiate(ObjetoAmover);
        ObjetoAmover.transform.position = PosInicial;
        InvokeRepeating("MiFuncion", 3.0f, 4.0f);
    }  
    void Update()
    {
        temporizador += Time.deltaTime;
        float t = Mathf.Clamp01(temporizador / Duracion);

        ObjetoAmover.transform.position = Vector3.Lerp(PosInicial, PosFinal, t);

        if (Input.GetKeyDown(KeyCode.E) && !Corriendo)
        {
            Corriendo = true;
            StartCoroutine(MiCorutina(Destino));
        }
    }

    IEnumerator MiCorutina(Transform MiDestino)
    {
        while (Vector3.Distance(transform.position, MiDestino.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, MiDestino.position, suavizado * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(3f);
    }
}
