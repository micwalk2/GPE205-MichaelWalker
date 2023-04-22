using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Controller : MonoBehaviour
{
    // Container for Pawn
    public Pawn pawn;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    // Child classes MUST override the way they process inputs
    public virtual void ProcessInputs()
    {

    }
}
