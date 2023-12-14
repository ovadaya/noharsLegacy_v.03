using System.Collections.Generic;
using UnityEngine;

public static class Inventario
{
    public static List<Item> itemsRecogidos = new List<Item>();

    public static void AgregarItem(Item item)
    {
        // imprimir el nombre y la descripcion del item:
        Debug.Log("Recogiste un " + item.nombre + ". " + item.descripcion);
        // Agregar el item a la lista de items recogidos si todavia no existe uno con ese id:
        if (!itemsRecogidos.Exists(i => i.id == item.id))
        {
            itemsRecogidos.Add(item);
        }
        // Puedes agregar lógica adicional aquí, como notificar al jugador que recogió un nuevo objeto.
    }
}