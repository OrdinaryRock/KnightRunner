using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Prompt : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float depth = 0.75f;
    [SerializeField]
    private UnityEvent OnInteract = new UnityEvent();
    
    private Vector3 initialScale;


    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float scaleOffset = Mathf.Sin(Time.time * speed) * depth;
        transform.localScale = initialScale + Vector3.one * scaleOffset;

        if(Input.GetMouseButtonDown(0))
        {
            OnInteract.Invoke();
            Destroy(gameObject);
        }
    }
}
