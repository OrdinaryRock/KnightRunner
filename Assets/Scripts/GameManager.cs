using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // [Header ("Game Data")]
    [SerializeField] public float gameSpeed = 1f;
    
    // [Header ("Player Info")]
    [SerializeField] private GameObject player;
    
    // [Header ("UI Elements")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private GameObject deathScreen;

    private void Awake()
    {
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        // Restart Game
        if(Input.GetKeyDown(KeyCode.R))
        {
            string levelName = SceneManager.GetActiveScene().name;
            GlobalVar.dead = false;
            SceneManager.LoadScene(levelName);
        }
    }

    public void ActivateDeathScreen()
    {
        deathScreen.SetActive(true);
    }
}
