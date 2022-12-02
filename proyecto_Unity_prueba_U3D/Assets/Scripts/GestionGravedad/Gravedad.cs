using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravedad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    CharacterController characterController;
    [SerializeField] float gravedad = -9.8f;
    [SerializeField] Vector3 fuerzaSalto = Vector3.zero;
    [SerializeField] float salto = 5f;
    float reloj = 0;
    bool saltando = false;
    

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            saltando = true;
            fuerzaSalto.y = salto;
            reloj = 0;
        }
        if (Input.GetButtonUp("Jump") && reloj < 0.15f)
        {
            fuerzaSalto.y = salto * 0.7f;
        }

        reloj += Time.deltaTime;
    }
}
