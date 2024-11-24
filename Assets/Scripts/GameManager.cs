using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header ("Game Data")]
    [SerializeField] public float gameSpeed = 1f;
    [Header ("Player Info")]
    [SerializeField] private GameObject player;
    [Header ("UI Elements")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    private void Awake()
    {
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }
}
