using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && enabled)
        {
            string levelName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(levelName);
        }
    }
}
