using UnityEngine;

/// <summary>
/// Rata
/// </summary>
public class Rata : MonoBehaviour
{
    //Vector para crear el movimiento del personaje
    Vector3 movimiento = Vector3.zero;

    //Origen de coordenadas de inicio del personaje
    Vector3 origen;

    //Velocidad del personaje
    [SerializeField] float velocidad = 2;

    //Aceleración del salto
    float aceleracionSalto = 0.0f;

    //Gravedad
    [SerializeField] float aceleracionGravedad = -10.0f;

    //Altura máxima
    [SerializeField] float alturaMaxima = 2f;

    //Tiempo máximo de vuelo
    [SerializeField] float tiempoMaximoVuelo = .5f;

    //Se sustituye el Collider original de la cápsula, por Charcter Controller 
    CharacterController characterController;

    //GameController del juego
    GameController gameController;

    //Audio para el salto del personaje
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Búsqueda del GameController por el tag
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        //Objeto de audio
        audioSource = gameObject.GetComponent<AudioSource>();

        //Obtener el CharacterControler del personaje
        characterController = GetComponent<CharacterController>();

        //Origen del personaje al comienzo del script
        origen = characterController.transform.position;

        aceleracionGravedad = InicializacionGravedad();
        aceleracionSalto = InicializacionSalto();

        MuerteEnemigo.OnMuerteDelEnemigo = (game) =>
        {
            Destroy(game.transform.parent.transform.parent.gameObject);
        };
    }

    private float InicializacionGravedad()
    {
        return -8 * alturaMaxima / Mathf.Sqrt(tiempoMaximoVuelo);
    }

    private float InicializacionSalto()
    {
        return Mathf.Sqrt(-2f * alturaMaxima * aceleracionGravedad);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Ac gravedad: {aceleracionGravedad} - Ac salto: {aceleracionSalto}");
        //Debug.Log(characterController.isGrounded ? "Suelo" : "Saltando");

        if (characterController.isGrounded)
        {
            aceleracionSalto = 0;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Fire1")) && characterController.isGrounded)
        {
            //Activa el audio a cada salto
            audioSource.Play();

            aceleracionGravedad = InicializacionGravedad();
            aceleracionSalto = InicializacionSalto();
        }

        aceleracionSalto += aceleracionGravedad * Time.deltaTime;
        movimiento.y = aceleracionSalto * Time.deltaTime;

        if ((Input.GetAxis("Horizontal") > 0) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if ((Input.GetAxis("Horizontal") < 0) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }

        //Asignación del valor x al movimiento, en función de los cursores o del gamepad
        movimiento.x = (Input.GetKey(KeyCode.LeftArrow) ? 1 : Input.GetKey(KeyCode.RightArrow) ? -1 : 0) * velocidad;
        movimiento.x = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;

        //Movimiento del personaje
        characterController.Move(movimiento);
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
