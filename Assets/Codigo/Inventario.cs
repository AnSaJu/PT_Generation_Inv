using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    //----------------------------------- Agregar
    public struct InventarioObjeto
    {
        public string nombre;
        public int cantidad;
        public Sprite spriteProducto;
    }

    public InventarioObjeto[] inventario = new InventarioObjeto[4];
    private int numObjetos = 0;

    //----------------------------------- Mostrar

    public TextMeshProUGUI[] textoCantidad;
    public Image[] imgCasilla;


    //-------------------------------------Eliminar

    public void AsignarBoton(int index)
    {
        EliminarObjeto(inventario[index].nombre);
    }

    public InventarioObjeto Preparar(int index)
    {
        return inventario[index];        
    }

    //---------------Mensajes
    public GameObject textoInventarioLLeno;



    public void AgregarObjeto(string nombreObjeto, int cantidad, Sprite spriteProducto)
    {
        // Busca si el objeto ya está en el inventario
        for (int i = 0; i < numObjetos; i++)
        {
            if (inventario[i].nombre == nombreObjeto)
            {
                
                // Si el objeto ya está en el inventario, incrementa su cantidad              
                inventario[i].cantidad += cantidad;
               MostrarInventario();
                return;
            }
        }

        // Si el objeto no está en el inventario, agrega un nuevo objeto
        if (numObjetos < inventario.Length)
        {
           
            inventario[numObjetos] = new InventarioObjeto { nombre = nombreObjeto, cantidad = cantidad, spriteProducto = spriteProducto };
            numObjetos++;
            MostrarInventario();
        }
        else
        {
            textoInventarioLLeno.SetActive(true);
            Invoke("DesactivarMensaje", 3f);
            Debug.Log("Inventario lleno. No se pudo agregar el objeto.");
        }
    }

    void DesactivarMensaje()
    {
        textoInventarioLLeno.SetActive(false);
    }

    //-------------------------Mostrar

    public void MostrarInventario()
    {
        for (int i = 0; i < numObjetos; i++)
        {
            // Configura el texto para mostrar el nombre y la cantidad del objeto
            textoCantidad[i].text = inventario[i].nombre + " x" + inventario[i].cantidad;
            imgCasilla[i].sprite = inventario[i].spriteProducto;
        }
       

    }

    //--------------------------Eliminar


    public void EliminarObjeto(string nombreObjeto)
    {
        int objetoIndex = -1;
        for (int i = 0; i < numObjetos; i++)
        {
            if (inventario[i].nombre == nombreObjeto)
            {
                objetoIndex = i;
                break;
            }
        }

        if (objetoIndex >= 0)
        {
            for (int j = objetoIndex + 1; j < numObjetos; j++)
            {
                inventario[j - 1] = inventario[j];
            }
            inventario[numObjetos - 1] = new InventarioObjeto();
            textoCantidad[numObjetos - 1].text = "";
            imgCasilla[numObjetos - 1].sprite = null;
            numObjetos--;
            MostrarInventario();
        }
        else
        {
            Debug.Log("El objeto noDebug.Log");
        }
    }


}
