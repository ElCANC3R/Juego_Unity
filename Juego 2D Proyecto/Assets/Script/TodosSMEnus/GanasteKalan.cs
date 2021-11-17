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
            Vector3 nuevont = new Vector3();
            nuevont.x = 115.507f;
            nuevont.y = -0.525f;
            nuevont.z = 0;
            GameObject Computadora = Instantiate(Paso, nuevont, Quaternion.identity);
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
