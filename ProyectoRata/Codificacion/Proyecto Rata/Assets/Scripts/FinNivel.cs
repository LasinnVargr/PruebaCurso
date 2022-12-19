using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNivel : MonoBehaviour
{
    [SerializeField][Tooltip("Nombre de la escena a la que se quiere cambiar")] string escena;

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
        if (!string.IsNullOrEmpty(escena))
        {
            SceneManager.LoadScene(escena);
        }
    }
}
