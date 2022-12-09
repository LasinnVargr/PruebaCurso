using UnityEngine;

public class Rata : MonoBehaviour
{
    //Vector para crear el movimiento del personaje
    Vector3 movimiento = Vector3.zero;
    Vector3 gravedad = Vector3.zero;
    Vector3 salto = Vector3.zero;

    Vector3 origen;

    //Velocidad del personaje
    [SerializeField] float velocidad = 2;

    //Aceleración del salto
    [SerializeField] float aceleracionSalto = 10;

    //Se sustituye el Collider original de la cápsula, por Charcter Controller 
    CharacterController characterController;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        characterController = GetComponent<CharacterController>();

        origen = characterController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Gestión del salto del personaje
        if (characterController.isGrounded)
        {
            gravedad.y = -0.01f;
            salto.y = 0;

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetButton("Fire1"))
            {
                salto.y = aceleracionSalto;
            }
        }
        else
        {
            gravedad.y -= .2f;
        }

        //Asignación del valor x al movimiento, en función de los cursores o del gamepad
        movimiento.x = (Input.GetKey(KeyCode.LeftArrow) ? 1 : Input.GetKey(KeyCode.RightArrow) ? -1 : 0) * velocidad;
        movimiento.x = Input.GetAxis("Horizontal") * velocidad;

        //Movimiento del personaje
        characterController.Move((gravedad + movimiento + salto) * Time.deltaTime);
    }

    /// <summary>
    /// Muerte del personaje
    /// </summary>
    public void Muerte()
    {
        gameObject.transform.position = origen;
        gameController.Reaparecer(gameObject.transform, origen);
    }
}
