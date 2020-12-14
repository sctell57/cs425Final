using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{







    public CharacterController2D controller;
    public Animator animator;
   
    
    //Stats
    public int curHealth;
    public int maxHealth = 100;

    
    //floats

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    //booleans
    bool jump = false;
    bool crouch = false;
    //variables
    private gameMaster gm;
    private Rigidbody2D rb2d;

    

    void Start() //Start is called before the first frame update
    {
        gm = GameObject.FindGameObjectWithTag("gameMaster").GetComponent<gameMaster>();

        curHealth = maxHealth;

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
 




    }

    
    void Update() // Update is called once per frame
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
            {
                
                jump = true;
                animator.SetBool("IsJumping", true);
         
            
       
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
 
        }
        if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if(curHealth <= 0)
        {
            Die();
        }

       







      

    }
    

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("coin"))
            {
            Destroy(col.gameObject);

            gm.points += 1000;
            

        }
       


    }

    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
        animator.Play("Player_Hurt", 0, 0f);




    }


    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(knockbackDir.x * 25, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        yield return 0;






    }






}
