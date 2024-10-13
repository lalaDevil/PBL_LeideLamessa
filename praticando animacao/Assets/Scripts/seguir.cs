using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir : MonoBehaviour
{
    public Transform boat; // Arraste o barco aqui no Inspector para referenciá-lo
    public Vector3 offset; // Defina a distância desejada entre a câmera e o barco

    void LateUpdate()
    {
        // Atualiza a posição da câmera para acompanhar o barco com o offset desejado
        transform.position = new Vector3(boat.position.x + offset.x, boat.position.y + offset.y, offset.z);
    }
}
