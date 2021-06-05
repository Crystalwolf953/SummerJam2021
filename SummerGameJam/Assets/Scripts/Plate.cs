using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ball")
        {
            activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ball")
        {
            activated = false;
        }
    }
}
