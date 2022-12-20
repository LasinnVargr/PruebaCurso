using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinNivel : MonoBehaviour
{
    [SerializeField][Tooltip("Nombre de la escena a la que se quiere cambiar")] string escena;

    [SerializeField] Text textoMarcador;

    int marcador = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Necesario para conservar los valores de las escenas a lo largo del desarrollo del juego
        DontDestroyOnLoad(this);

        Rata.OnMarcador = (puntuacion) =>
        {
            marcador += puntuacion;
            textoMarcador.text = $"Puntuación: {marcador}";
        };
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
