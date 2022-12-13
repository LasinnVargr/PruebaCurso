using System;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public enum Direccion { Vertical, Horizontal }

    [SerializeField] Direccion direccion;

    [SerializeField] GameObject punto_a;
    [SerializeField] GameObject punto_b;

    Vector3 posicion_a = Vector3.zero;
    Vector3 posicion_b = Vector3.zero;

    Vector3 desplazamiento = Vector3.zero;

    int direccion_x = 1;
    int direccion_y = 1;

    [SerializeField][Range(1, 10)] int velocidad = 1;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 distancia = punto_b.transform.position - punto_a.transform.position;

        posicion_a.x = punto_a.transform.position.x - (distancia.x / 2);
        posicion_b.x = punto_b.transform.position.x + (distancia.x / 2);

        posicion_a.y = punto_a.transform.position.y - (distancia.y / 2);
        posicion_b.y = punto_b.transform.position.y + (distancia.y / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (direccion == Direccion.Horizontal)
        {
            if (transform.position.x >= posicion_b.x)
            {
                direccion_x = -1;
            }

            if (transform.position.x <= posicion_a.x)
            {
                direccion_x = 1;
            }

            desplazamiento.x = direccion_x * velocidad * Time.deltaTime;
        }

        if (direccion == Direccion.Vertical)
        {
            if (transform.position.y <= posicion_b.y)
            {
                direccion_y = 1;
            }

            if (transform.position.y >= posicion_a.y)
            {
                direccion_y = -1;
            }

            desplazamiento.y = direccion_y * velocidad * Time.deltaTime;

            Debug.Log(desplazamiento.y);
        }

        transform.position += desplazamiento;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        //Gizmos.color = Color.yellow;

        //Gizmos.DrawSphere(punto_a.transform.position, 1);
        //Gizmos.DrawSphere(punto_b.transform.position, 1);
    }
}
