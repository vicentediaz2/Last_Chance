using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public Vector3 offset = new Vector3(0f, 2f, -10f);
    private Camera camara;

    void Start()
    {
        camara = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    Debug.Log("Presionaste: " + key);
                }
            }
        }
        Vector3 movimiento = Vector3.zero;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            movimiento.x = -velocidad * Time.deltaTime;
            transform.localScale = new Vector2(-1,1);
            Debug.Log("Tecla detectada");
        }
        else
        if(Input.GetKey(KeyCode.RightArrow))
        {
            movimiento.x = velocidad * Time.deltaTime;
            transform.localScale = new Vector2(1,1);
            Debug.Log("Tecla detectada");
        }
        else
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space key was released.");
        }

        transform.position += movimiento;
        camara.transform.position = transform.position + offset;
    }
}
