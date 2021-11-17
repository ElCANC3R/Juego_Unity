using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanasteKalan : MonoBehaviour
{

    public GameObject[] enemigos;
    public GameObject Paso;
    private int noEnemigos;
    // Start is called before the first frame update
    void Start()
    {
        noEnemigos = enemigos.Length + 1;
    }

    public void restar()
    {
        noEnemigos--;
        if (noEnemigos == 0)
        {
            GameObject Computadora = Instantiate(Paso, transform.position + Vector3.down * 0.5f, Quaternion.identity);
        }
        else
        {
            foreach (GameObject item in enemigos)
            {
                if (item != null)
                {
                    item.GetComponent<GanasteKalan>().restarLa();
                }
            }
        }
    }

    public void restarLa()
    {
        noEnemigos--;
    }
}
