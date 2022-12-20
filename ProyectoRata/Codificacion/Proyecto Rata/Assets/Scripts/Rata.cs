using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Rata
/// </summary>
public class Rata : MonoBehaviour
{
    public delegate void Marcador(int puntuacion);
    public static Marcador OnMarcador;
    public static Marcador OnResetMarcador;

    //Vector para crear el movimiento del personaje
    Vector3 movimiento = Vector3.zero;

    //Origen de coordenadas de inicio del personaje
    Vector3 origen;

    [SerializeField][Tooltip("Velocidad del personaje")] float velocidad = 2;

    //Aceleración del salto
    float aceleracionSalto = 0.0f;

    //Gravedad
    float aceleracionGravedad = -10.0f;

    [SerializeField][Tooltip("Altura máxima del salto")] float alturaMaxima = 2f;

    [SerializeField][Tooltip("Tiempo máximo de vuelo en el salto")] float tiempoMaximoVuelo = .5f;

    //Se sustituye el Collider original de la cápsula, por Charcter Controller 
    CharacterController characterController;

    //GameController del juego
    GameController gameController;

    //Audios que interactuan con el personaje
    /*
     * 0 - Salto
     * 1 - Muerte
     * 2 - MuerteEnemigo
     */
    AudioSource[] audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Búsqueda del GameController por el tag
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        //Objetos de audio
        audioSource = gameObject.GetComponents<AudioSource>();

        //Obtener el CharacterControler del personaje
        characterController = GetComponent<CharacterController>();

        //Origen del personaje al comienzo del script
        origen = characterController.transform.position;

        aceleracionGravedad = InicializacionGravedad();
        aceleracionSalto = InicializacionSalto();

        MuerteEnemigo.OnMuerteDelEnemigo = (game) =>
        {
            audioSource[2].Play();

            Destroy(game.transform.parent.transform.parent.gameObject);

            aceleracionGravedad = InicializacionGravedad();
            aceleracionSalto = InicializacionSalto();

            OnMarcador.Invoke(100);
        };

        if (SceneManager.GetActiveScene().name == "Escena_1")
        {
            OnResetMarcador.Invoke(0);
        }
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
            audioSource[0].Play();

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
        audioSource[1].Play();

        gameObject.transform.position = origen;
        gameController.Reaparecer(gameObject.transform, origen);
    }
}
