using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocidad = 3f;
    public float fuerzaSalto = 9f;
    public Vector3 offset = new Vector3(0f, 2f, -10f);
    private Rigidbody2D rb;
    private Camera camara;
    private bool enSuelo;
    private Vector3 posicionInicial;
    void Start()
    {
        camara = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal") * velocidad;
        rb.linearVelocity = new Vector2(movX, rb.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enSuelo = false;
        }
        camara.transform.position = transform.position + offset;
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

    }
}
