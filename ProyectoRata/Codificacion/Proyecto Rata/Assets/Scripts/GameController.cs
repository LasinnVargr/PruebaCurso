using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Limnitación de fotogramas
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Gestión de la muerte del personaje y reaparecer del mismo
    /// </summary>
    /// <param name="personaje">Posición del personaje</param>
    /// <param name="origen">Origen en el que va a reaparecer el personaje</param>
    public void Reaparecer(Transform personaje, Vector3 origen)
    {
        //Desaparece, asigna el origen y vuelve a aparecer
        personaje.gameObject.GetComponent<CharacterController>().enabled = false;
        personaje.position = origen;
        personaje.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
