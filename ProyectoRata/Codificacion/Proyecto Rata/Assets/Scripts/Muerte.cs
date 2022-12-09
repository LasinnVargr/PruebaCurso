using UnityEngine;

public class Muerte : MonoBehaviour
{
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
        //El disparador obtiene el gameObject del collider y ejecuta el método Muerte.
        other.gameObject.GetComponent<Rata>().Muerte();
    }
}
