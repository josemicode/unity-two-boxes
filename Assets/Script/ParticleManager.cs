using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private List<ChargedParticle> ChargedParticles;
    private List<MovingChargedParticle> MovingChargedParticles;

    // Start is called before the first frame update
    void Start()
    {
        ChargedParticles = new List<ChargedParticle>(FindObjectsOfType<ChargedParticle>());
        MovingChargedParticles = new List<MovingChargedParticle>(FindObjectsOfType<MovingChargedParticle>());   
    }

    // Update is called once per frame
    void Update()
    {
        foreach(MovingChargedParticle mcp in MovingChargedParticles){
            ApplyForce(mcp);
        }
        
    }

    private void ApplyForce(MovingChargedParticle mcp)
    {
        Vector3 newForce = Vector3.zero;
        foreach(ChargedParticle cp in ChargedParticles){

            if(mcp == cp){
                continue;
            }

            float distance = Vector3.Distance(mcp.transform.position, cp.gameObject.transform.position);
            float force = 10 * mcp.charge * cp.charge / Mathf.Pow(distance,2); 

            Vector3 direction = mcp.transform.position - cp.transform.position;
            direction.Normalize();
            newForce += force*direction;

           
        }

        mcp.rb.AddForce(newForce);
    }

}
