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
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;

    [SerializeField]
    private Sprite neutralSprite, fallingSprite, risingSprite;

    [SerializeField]
    private AudioClip flapSound, scoreSound, impactSound;

    [SerializeField]
    private UnityEvent OnEndGame = new UnityEvent();

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = neutralSprite;

        GlobalVar.GetScore();
        highScoreText.text = GlobalVar.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(flapSound, Camera.main.transform.position);
        }

        Animate();
    }

    public void EnableGravity()
    {
        rb.gravityScale = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PipeController pipe = collision.GetComponent<PipeController>();
        GlobalVar.score += pipe.rewardPoints;
        if(scoreText != null) scoreText.text = GlobalVar.score.ToString();
        UpdateHighScore();
        AudioSource.PlayClipAtPoint(scoreSound, Camera.main.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateHighScore();
        EndGame();
    }

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
}
