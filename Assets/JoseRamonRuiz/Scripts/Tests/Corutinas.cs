using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corutinas : MonoBehaviour
{
    public Transform Destino;

    public float suavizado = 1f;
    void Start()
    {
        StartCoroutine(MiCorutina(Destino));
        Debug.Log("El script sigue");
    }    
    void Update()
    {
        
    }
    IEnumerator MiCorutina(Transform MiDestino)
    {
        Debug.Log("Se inicia la rutina");
        while (Vector3.Distance(transform.position, MiDestino.position) > 0.05f) 
        {
            Debug.Log("Moviendo");
            transform.position = Vector3.Lerp(transform.position, MiDestino.position, suavizado*Time.deltaTime);
            yield return null;
        }
        Debug.Log("Se acaba e while");
        yield return new WaitForSeconds(3f);
        Debug.Log("Se acaba la rutina");
    }
}
