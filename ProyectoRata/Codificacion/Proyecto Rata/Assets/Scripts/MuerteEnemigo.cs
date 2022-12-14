using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    AudioSource audioSource;

    public delegate void MuerteDelEnemigo(GameObject game);
    public static MuerteDelEnemigo OnMuerteDelEnemigo;

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

        OnMuerteDelEnemigo.Invoke(gameObject);
    }
}
