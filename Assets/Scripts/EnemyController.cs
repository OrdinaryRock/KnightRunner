using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    public int rewardPoints;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lifeTime = 10f;

    private float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        speedMultiplier = GameManager.Instance.gameSpeed;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVar.dead) Destroy(gameObject);
        transform.Translate(Vector2.left * speed * speedMultiplier * Time.deltaTime);
    }
}
