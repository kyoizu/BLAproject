using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCheck : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
