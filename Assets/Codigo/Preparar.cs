using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Preparar : MonoBehaviour
{   

    //----------------- Inventario
    public Inventario inventario;

    public Inventario.InventarioObjeto producto;

    int cantidadManzana = 2;
    int cantidadQueso = 2;
    int cantidadBanano = 2;
    int cantidadChocolate = 2;
    int cantidadPlato = 2;
    int cantidadPan = 2;

    bool listaManzana;
    bool listaQueso;
    bool listaBanano;
    bool listaChocolate;
    bool listaPlato;
    bool listaPan;

    string textManzana;
    string textQueso;
    string textBanano;
    string textChocolate;
    string textPlato;
    string textPan;

    int restaNumero;

    public TextMeshProUGUI textoIngrediente1;
    public TextMeshProUGUI textoIngrediente2;
    public TextMeshProUGUI textoIngrediente3;
    public TextMeshProUGUI textoIngrediente4;


    public GameObject textoResetaCompleta;

    private void Start()
    {
        RandonPedido();
        mostrarReseta();
    }


    void mostrarReseta()
    {
        if(restaNumero == 0)
        {
            textoIngrediente1.text = "Manzana x " + cantidadManzana + " - " + textManzana;
            textoIngrediente2.text = "Plato x" + cantidadPlato + " - " + textPlato;
            textoIngrediente3.text = "Banano x" + cantidadBanano + " - " + textBanano;
            textoIngrediente4.text = "Pan x" + cantidadPan + " - " + textPan;
        }

        if (restaNumero == 1)
        {
            
            textoIngrediente1.text = "Queso x " + cantidadQueso + " - " + textQueso;
            textoIngrediente2.text = "Manzana x" + cantidadManzana + " - " + textManzana;
            textoIngrediente3.text = "Chocholate x" + cantidadChocolate + " - " + textChocolate;
            textoIngrediente4.text = "Plato x" + cantidadPlato + " - " + textPlato;
        }

        if (restaNumero == 2)
        {

            textoIngrediente1.text = "Banano x " + cantidadBanano + " - " + textBanano;
            textoIngrediente2.text = "Plato x" + cantidadPlato + " - " + textPlato;
            textoIngrediente3.text = "Queso x" + cantidadQueso + " - " + textQueso;
            textoIngrediente4.text = "Chocolate x" + cantidadChocolate + " - " + textChocolate;
        }
    }



    public void BotonPreparar(int index)
    {
        producto = inventario.Preparar(index);

        if(producto.nombre == "Manzana" && producto.cantidad >= cantidadManzana)
        {
            inventario.EliminarObjeto(producto.nombre);
            listaManzana = true;
            textManzana = "Completo";
         
            Debug.Log("Ingrediente correcto");
        }
        else
        {
            Debug.Log("Faltan ingredientes");
        }

        if (producto.nombre == "Banano" && producto.cantidad >= cantidadBanano)
        {
            inventario.EliminarObjeto(producto.nombre);
            listaBanano = true;
            textBanano = "Completo";
           
            Debug.Log("Ingrediente correcto");
        }
        else
        {
            Debug.Log("Faltan ingredientes");
        }

        if (producto.nombre == "Chocolate" && producto.cantidad >= cantidadChocolate)
        {
            inventario.EliminarObjeto(producto.nombre);
            listaChocolate = true;
            textChocolate = "Completo";
           
            Debug.Log("Ingrediente correcto");
        }
        else
        {
            Debug.Log("Faltan ingredientes");
        }

        if (producto.nombre == "Pan" && producto.cantidad >= cantidadPan)
        {
            inventario.EliminarObjeto(producto.nombre);
            listaPan = true;
            
            textPan = "Completo";
            Debug.Log("Ingrediente correcto");
        }
        else
        {
            Debug.Log("Faltan ingredientes");
        }

        if (producto.nombre == "Plato" && producto.cantidad >= cantidadPlato)
        {
            inventario.EliminarObjeto(producto.nombre);
            listaPlato = true;
          


            textPlato = "Completo";
            Debug.Log("Ingrediente correcto");
        }
        else
        {
            Debug.Log("Faltan ingredientes");
        }

        if (producto.nombre == "Queso" && producto.cantidad >= cantidadQueso)
        {
            inventario.EliminarObjeto(producto.nombre);
            listaQueso = true;
            textQueso = "Completo";
            Debug.Log("Ingrediente correcto");
        }
        else
        {
            Debug.Log("Faltan ingredientes");
        }

        PrepararReseta();
    }

    void PrepararReseta()
    {
        
        if (restaNumero == 0 && listaManzana && listaPlato && listaBanano && listaPan)
        {
            Debug.Log("Reseta lista Felicidades");
            textoResetaCompleta.SetActive(true);
            Invoke("DesactivarMensaje", 3f);
            RandonPedido();
        }

        if (restaNumero == 1 && listaManzana && listaPlato && listaQueso && listaChocolate)
        {
            Debug.Log("Reseta lista Felicidades");
            textoResetaCompleta.SetActive(true);
            Invoke("DesactivarMensaje", 3f);
            RandonPedido();
        }

        if (restaNumero == 2 && listaBanano && listaPlato && listaQueso && listaChocolate)
        {
            Debug.Log("Reseta lista Felicidades");
            textoResetaCompleta.SetActive(true);
            Invoke("DesactivarMensaje", 5f);
            RandonPedido();
        }

        mostrarReseta();
    }

    void DesactivarMensaje()
    {
        textoResetaCompleta.SetActive(false);
    }

    void RandonPedido()
    {
        restaNumero = Random.Range(0, 3);

        cantidadManzana = Random.Range(1, 5);
        cantidadQueso = Random.Range(1, 5);
        cantidadBanano = Random.Range(1, 5);
        cantidadChocolate = Random.Range(1, 5);
        cantidadPlato = Random.Range(1, 5);
        cantidadPan = Random.Range(1, 5);

        listaManzana = false;
        listaQueso = false;
        listaBanano = false;
        listaChocolate = false;
        listaPlato = false;
        listaPan = false;

        textManzana = "";
        textQueso = "";
        textBanano = "";
        textChocolate = "";
        textPlato = "";
        textPan = "";
    }

}
