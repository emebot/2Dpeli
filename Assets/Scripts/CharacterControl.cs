using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Animator animator; // kutsutaan jos halutaan muokata animaatioiden ajoa
    public Rigidbody2D rb2D; // 

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool grounded;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animator = GetComponent<Animator>();
       rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Ground Check
        if(Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer))
            {
            grounded = true;
            }
            else
            {
            grounded = false;
            }
        
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            // Meillä on joko A tai D pohjassa = ollaan liikkeessä
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Walk", true);
        }
        else
        {
            // ajetaan vain jos ei liikuta
            animator.SetBool("Walk", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            // välilyönti painettu
            rb2D.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("Jump");
        }
    }
}
