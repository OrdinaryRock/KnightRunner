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
        if(Input.GetMouseButtonDown(0) && onGround)
        {
            onGround = false;
            animator.SetBool("jumping", true);
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
        }

        // Animate();
    }

    public void EnableGravity()
    {
        rb.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        animator.SetBool("jumping", false);
        // UpdateHighScore();
        // EndGame();
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

    private void EndGame()
    {
        GlobalVar.SaveHighScore();
        GlobalVar.score = 0;
        AudioSource.PlayClipAtPoint(impactSound, Camera.main.transform.position);
        OnEndGame.Invoke();
    }

    private void Animate()
    {
        if(rb.velocity.y > 0.3f) spriteRenderer.sprite = risingSprite;
        else if(rb.velocity.y < -0.3f) spriteRenderer.sprite = fallingSprite;
        else spriteRenderer.sprite = neutralSprite;
    }
    */
}
