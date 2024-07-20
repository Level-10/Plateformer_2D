using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<GameObject> objetsToKeep = new List<GameObject>();

    void Awake()
    {
        foreach (GameObject _objet in objetsToKeep)
        {
            DontDestroyOnLoad(_objet);
        }
    }

}
