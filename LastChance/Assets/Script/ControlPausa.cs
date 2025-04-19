using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPausa : MonoBehaviour
{
    public GameObject canvasPausa;
    public GameObject canvasConfirmacion;
    public AudioSource sonidoPausa;
    private bool juegoPausado = false;

    void Start()
    {
        if (sonidoPausa != null)
        {
            sonidoPausa.ignoreListenerPause = true; // Esto permite que el sonido funcione aunque el tiempo est� pausado
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (sonidoPausa != null)
            {
                sonidoPausa.Play();
            }

            Debug.Log("Tecla detectada");
            AlternarPausa();
        }
    }

    public void AlternarPausa()
    {
        juegoPausado = !juegoPausado;
        canvasPausa.SetActive(juegoPausado);
        Time.timeScale = juegoPausado ? 0f : 1f; // Detiene o reanuda el tiempo del juego
    }

    public void BotonAtras()
    {
        AlternarPausa(); // Simplemente alterna la pausa para volver al juego
    }

    public void BotonExit()
    {
        canvasConfirmacion.SetActive(true); // Muestra la ventana de confirmaci�n
    }

    public void ConfirmarSalirAlInicio()
    {
        Time.timeScale = 1f; // Asegura que el tiempo vuelva a la normalidad
        SceneManager.LoadScene("MenuInicial"); // Carga la escena de men� principal (ajusta el nombre si es diferente)
    }

    public void CancelarSalirAlInicio()
    {
        canvasConfirmacion.SetActive(false); // Cierra la ventana de confirmaci�n
    }
}