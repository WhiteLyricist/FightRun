using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Restart() 
    {
        MoveController.stop = false;
        SceneManager.LoadScene("Game");
    }

    private void Update()
    {
        if (Input.GetKey("escape")) 
        {
            Application.Quit();
        }
    }

}
