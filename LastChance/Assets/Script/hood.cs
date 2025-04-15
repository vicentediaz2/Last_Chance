using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 2f;
    public float fuerzaSalto = 9f;
    public Vector3 offset = new Vector3(0f, 2f, -10f);
    Animator animator;
    private Rigidbody2D rb;
    private Camera camara;
    private bool enSuelo;
    private Vector3 posicionInicial;

    void Start()
    {
        animator = GetComponent<Animator>();
        camara = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimiento = Vector3.zero;
        float movX = Input.GetAxis("Horizontal") * velocidad;
        rb.linearVelocity = new Vector2(movX, rb.linearVelocity.y);
        //logica correr
        if (Input.GetKey(KeyCode.LeftControl))
        {
            velocidad = 6f;
        }
        if (!(Input.GetKey(KeyCode.LeftControl)))
        {
            velocidad = 2f;
        }
        //caminar izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimiento.x = -velocidad * Time.deltaTime;
            transform.localScale = new Vector2(-1, 1);
        }
        //caminar derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movimiento.x = velocidad * Time.deltaTime;
            transform.localScale = new Vector2(1, 1);
        }
        //saltar
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enSuelo = false;
        }
        transform.position += movimiento;
        camara.transform.position = transform.position + offset;
        Debug.Log(Mathf.Abs(movX));
        animator.SetFloat("speed", Mathf.Abs(movX));


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            animator.SetBool("IsJumping", false);
            enSuelo = true;
        }

    }
}
