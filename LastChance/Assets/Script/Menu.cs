using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] string escenaInicial = null;
    [SerializeField] string escenaMusic = null;
    [SerializeField] string escenaCreditos = null;

    public void Iniciar()
    {
        print("Botón Iniciar");
        SceneManager.LoadScene(escenaInicial);
    }

    public void Music()
    {
        print("Botón Musica");
        SceneManager.LoadScene(escenaMusic);
    }

    public void Creditos()
    {
        print("Botón Crédito");
        SceneManager.LoadScene(escenaCreditos);
    }

    public void Salir()
    {
        print("Botón Salir");
        Application.Quit();
    }
}
