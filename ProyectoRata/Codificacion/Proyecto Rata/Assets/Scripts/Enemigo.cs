using System;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] GameObject punto_a;
    [SerializeField] GameObject punto_b;

    Vector3 posicion_a = Vector3.zero;
    Vector3 posicion_b = Vector3.zero;

    Vector3? destino = null;

    [SerializeField] bool GiroCambioSentido = true;

    [SerializeField][Range(1, 5)] int velocidad = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            destino ?? punto_b.transform.position,
            velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino ?? punto_b.transform.position) < 0.001f)
        {
            destino = destino == punto_a.transform.position ? punto_b.transform.position : punto_a.transform.position;
            
            if (GiroCambioSentido)
            {
                transform.rotation = destino == punto_a.transform.position ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawSphere(punto_a.transform.position, .2f);
        Gizmos.DrawSphere(punto_b.transform.position, .2f);
    }
}
