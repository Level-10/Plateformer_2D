using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParentComponent : MonoBehaviour
{
    [SerializeField] protected Player playerRef = null;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        playerRef = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
