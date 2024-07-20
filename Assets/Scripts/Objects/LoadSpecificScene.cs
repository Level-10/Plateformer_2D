using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    [SerializeField] SceneAsset sceneToLoad = null;

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ChangeScene();
        }
    }
}
