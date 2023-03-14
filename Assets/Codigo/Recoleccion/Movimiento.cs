using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 1f;
    public int tiempoDestruccion = 20;

    private void Start()
    {
        Destroy(this.gameObject, tiempoDestruccion);
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector3.up);
    }
}
