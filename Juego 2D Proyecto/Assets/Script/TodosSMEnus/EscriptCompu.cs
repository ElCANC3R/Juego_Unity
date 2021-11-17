using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscriptCompu : MonoBehaviour
{
    public GameObject FelicitacionesKLN;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<DeivenMove>() != null){
            GameObject Celular = Instantiate(FelicitacionesKLN, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
