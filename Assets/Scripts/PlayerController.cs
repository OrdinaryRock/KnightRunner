using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private AudioClip jumpSound, scoreSound, impactSound;

    [SerializeField]
    private UnityEvent OnEndGame = new UnityEvent();

    private Rigidbody2D rb;
    private Animator animator;
    private bool onGround = false;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // GlobalVar.GetScore();
        // highScoreText.text = GlobalVar.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(onGround)
            {
                onGround = false;
                animator.SetBool("jumping", true);
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
            }
            else
            {
                animator.SetTrigger("attack");
                attacking = true;
            }
        }

        // Animate();
    }

    public void EnableGravity()
    {
        rb.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground"))
        {
            onGround = true;
            attacking = false;
            animator.SetBool("jumping", false);
            // UpdateHighScore();
            // EndGame();
        }
        else if(collision.gameObject.tag.Equals("Enemy") && GlobalVar.dead == false)
        {
            if(collision.collider is CapsuleCollider2D) EndGame();
            else if(collision.collider is CircleCollider2D)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(attacking && collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void EndGame()
    {
        onGround = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        animator.SetBool("dead", true);
        GlobalVar.dead = true;
        GameManager.Instance.ActivateDeathScreen();
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    /* Legacy Methods
    private void UpdateHighScore()
    {
        if(GlobalVar.score > GlobalVar.highScore)
        {
            GlobalVar.highScore = GlobalVar.score;
            if(highScoreText != null) highScoreText.text = GlobalVar.highScore.ToString();
        }
    }

    

    private void Animate()
    {
        if(rb.velocity.y > 0.3f) spriteRenderer.sprite = risingSprite;
        else if(rb.velocity.y < -0.3f) spriteRenderer.sprite = fallingSprite;
        else spriteRenderer.sprite = neutralSprite;
    }
    */
}
