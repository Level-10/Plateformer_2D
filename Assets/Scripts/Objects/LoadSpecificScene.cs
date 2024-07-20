using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    [SerializeField] SceneAsset sceneToLoad = null;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeScene();
    }
}
