using UnityEngine;

public class Muerte : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();

        //El disparador obtiene el gameObject del collider y ejecuta el método Muerte.
        other.gameObject.GetComponent<Rata>().Muerte();
    }
}
