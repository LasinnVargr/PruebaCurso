using UnityEngine;

public class Rata : MonoBehaviour
{
    //Vector para crear el movimiento del personaje
    Vector3 movimiento = Vector3.zero;
    Vector3 gravedad = Vector3.zero;
    Vector3 salto = Vector3.zero;

    //Velocidad del personaje
    [SerializeField] float velocidad = 2;

    //Aceleración del salto
    [SerializeField] float aceleracionSalto = 10;

    //Se sustituye el Collider original de la cápsula, por charcterController 
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetButton("Fire1"))
            {
                salto.y = aceleracionSalto;
            }
        }

        //Asignación del valor x al movimiento, en función de los cursores o del gamepad
        movimiento.x = (Input.GetKey(KeyCode.LeftArrow) ? 1 : Input.GetKey(KeyCode.RightArrow) ? -1 : 0) * velocidad;
        movimiento.x = Input.GetAxis("Horizontal") * velocidad;

        characterController.Move((gravedad + movimiento + salto) * Time.deltaTime);
    }
}
