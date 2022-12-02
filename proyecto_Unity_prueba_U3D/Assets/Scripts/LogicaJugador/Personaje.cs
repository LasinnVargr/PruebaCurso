using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] float velocidadMovimiento = 2;
    [SerializeField] Animator anim;

    Vector3 movimiento = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento

        movimiento.x = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;


        if (movimiento.x < 0)
        {
            anim.transform.rotation = Quaternion.AngleAxis(-90f, Vector3.up);
        }
        else if (movimiento.x > 0)
        {
            anim.transform.rotation = Quaternion.AngleAxis(90f, Vector3.up);
        }


    }
}
