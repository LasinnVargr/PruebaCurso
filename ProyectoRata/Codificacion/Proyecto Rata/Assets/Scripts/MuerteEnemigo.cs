using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    public delegate void MuerteDelEnemigo(GameObject game);
    public static MuerteDelEnemigo OnMuerteDelEnemigo;

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
        OnMuerteDelEnemigo.Invoke(gameObject);
    }
}
