using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 1f;
    private MeshRenderer meshRenderer;
    private Vector2 offset = new Vector2();


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(Time.time * scrollSpeed, 0);
        meshRenderer.material.mainTextureOffset = offset;
    }
}
