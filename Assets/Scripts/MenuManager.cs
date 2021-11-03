using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("FirstLevel");
        FindObjectOfType<AudioManager>().Play("Start");
        
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Credits");
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void Tuto()
    {
        SceneManager.LoadScene("Tuto");
        FindObjectOfType<AudioManager>().Play("Button");
    }
}