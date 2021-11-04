using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verde : MonoBehaviour
{
    public void DestroyBuff(){
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        DeivenMove Daven = other.GetComponent<DeivenMove>();

        if (Daven != null)
        {
            Daven.AumentoEner();
            DestroyBuff();
        }
    }
}
