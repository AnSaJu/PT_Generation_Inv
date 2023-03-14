using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerObjeto : MonoBehaviour
{
    public KeyCode tecla;

    private bool activo = false;
    private GameObject producto;


    Sprite spriteProducto;
    //----------------- Inventario
    public Inventario inventario;


    void Update()
    {
        if (Input.GetKeyDown(tecla) && activo)
        {
            activo = false;
            inventario.AgregarObjeto(producto.tag, 1, spriteProducto);
            Destroy(producto);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            activo = true;
            spriteProducto = other.GetComponent<SpriteRenderer>().sprite;
            producto = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        activo = false;
    }
}
