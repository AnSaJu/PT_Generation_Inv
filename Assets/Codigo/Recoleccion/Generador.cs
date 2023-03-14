using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject[] objetos;

    public Transform[] posiciones;

    public float tiempoDeEspera = 2f;


    private void Start()
    {
        InvokeRepeating("GenerarObjetoAleatorio", 0f, tiempoDeEspera);
    }


    private void GenerarObjetoAleatorio()
    {
        int indexObjetoAleatorio = Random.Range(0, objetos.Length);
        int indexPosicionAleatoria = Random.Range(0, posiciones.Length);

        Instantiate(objetos[indexObjetoAleatorio], posiciones[indexPosicionAleatoria].position, Quaternion.identity);
    }
}
