using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{
    public void irMenu(){
        SceneManager.LoadScene(0);
        Debug.Log("Escena actual: "+ SceneManager.GetActiveScene().name);
    }
}
