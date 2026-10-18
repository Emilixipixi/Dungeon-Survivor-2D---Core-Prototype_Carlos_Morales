using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Estado")]
    public bool isGrounded;
    private bool mirandoDerecha = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

       
        if (move > 0 && !mirandoDerecha)
        {
            Voltear();
        }
        else if (move < 0 && mirandoDerecha)
        {
            Voltear();
        }

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Voltear()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}