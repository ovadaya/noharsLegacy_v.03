using UnityEngine;
using UnityEngine.UI;

public class InventarioUI : MonoBehaviour
{
    public Text contadorTexto;

    void Update()
    {
        // Actualiza el texto con la cantidad de objetos en el inventario
        if (contadorTexto != null)
        {
            contadorTexto.text = "Objetos: " + Inventario.itemsRecogidos.Count;
        }
    }
}
