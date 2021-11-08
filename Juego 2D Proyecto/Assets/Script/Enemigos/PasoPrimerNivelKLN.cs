using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasoPrimerNivelKLN : MonoBehaviour
{
    private int Enemigos = 3;
    public GameObject Paso;
    public GameObject L1;
    public GameObject L2;

    public void restar()
    {
        Enemigos--;
        if (Enemigos == 0)
        {
            GameObject BuffMorado = Instantiate(Paso, transform.position, Quaternion.identity);
        }
        else
        {
            if (L1 != null)
            {
                L1.GetComponent<PasoPrimerNivelKLN>().restarLa();
            }
            if (L2 != null)
            {
                L2.GetComponent<PasoPrimerNivelKLN>().restarLa();
            }
        }
    }

    public void restarLa()
    {
        Enemigos--;
    }

}
