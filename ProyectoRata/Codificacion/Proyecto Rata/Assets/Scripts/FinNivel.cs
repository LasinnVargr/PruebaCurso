using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinNivel : MonoBehaviour
{
    [SerializeField][Tooltip("Nombre de la escena a la que se quiere cambiar")] string escena;

    [SerializeField] Text TextoMarcador;
    [SerializeField] Text TextoMarcadorMaximo;

    //Las variables deben ser declaradas estáticas, para que se conserven durante la partida
    static int marcador = 0;
    static int marcador_maximo = 0;

    private void Awake()
    {
        //Necesario para conservar los valores de las escenas a lo largo del desarrollo del juego
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Rata.OnMarcador = (puntuacion) =>
        {
            marcador += puntuacion;
            TextoMarcador.text = $"Puntuación: {marcador}";

            if (marcador >= marcador_maximo)
            {
                marcador_maximo = marcador;
            }
        };

        Rata.OnResetMarcador = (puntuacion) =>
        {
            marcador = puntuacion;

            if (TextoMarcador != null)
            {
                TextoMarcador.text = $"Puntuación: {marcador}";
            }
        };

        if (TextoMarcador != null)
        {
            TextoMarcador.text = $"Puntuación: {marcador}";
        }

        if (TextoMarcadorMaximo != null)
        {
            TextoMarcadorMaximo.text = $"Puntuación máxima: {marcador_maximo}";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        CambioDeEscenario(escena);
    }

    private void CambioDeEscenario(string escena_destino)
    {
        if (!string.IsNullOrEmpty(escena_destino))
        {
            SceneManager.LoadScene(escena_destino);

            escena = string.Empty;
        }
        else
        {
            Debug.LogWarning("No se ha especificado ninguna escena a la que navegar");
        }
    }

    public void OnInicioPartidaClick()
    {
        CambioDeEscenario(escena);
    }
}
