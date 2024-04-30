using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedParticle : MonoBehaviour
{

    public float charge = 1;
    // Start is called before the first frame update
    void Start()
    {
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateColor()
    {
        Color color = (charge > 0) ? Color.blue:Color.red;
        GetComponent<Renderer>().material.color = color;
    }
}