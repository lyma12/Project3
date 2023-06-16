using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool loss = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        loss = false;
    }
    private void OnCollisionExit(Collision collision)
    {
    }

    public bool getOverGame() { return !loss; }
}
