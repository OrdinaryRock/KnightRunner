using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeletion : MonoBehaviour
{
    [SerializeField]
    private float delay = 2f;

    private void OnEnable()
    {
        Destroy(gameObject, delay);
    }
}
