using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonCreditos : MonoBehaviour
{
    public void VolverAlMenu()
    {
        // Aseg�rate de restablecer el tiempo en caso de que venga de una escena pausada
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicial"); // Usa el nombre exacto de tu escena de men�
    }
}
