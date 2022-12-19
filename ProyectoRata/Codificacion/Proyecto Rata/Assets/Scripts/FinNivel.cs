using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinNivel : MonoBehaviour
{
    [SerializeField][Tooltip("Nombre de la escena a la que se quiere cambiar")] string escena;
    
    [SerializeField] GameObject boton;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("cambio");

        if (!string.IsNullOrEmpty(escena_destino))
        {
            SceneManager.LoadScene(escena_destino);
        }
    }

    public void OnInicioPartidaClick() 
    {
        CambioDeEscenario(escena);
    }
}
