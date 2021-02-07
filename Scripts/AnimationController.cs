using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;

    int VelocityHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");

        
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPress = Input.GetKey("w");
        bool walkPress = Input.GetKey("up");

        bool runPress = Input.GetKey("left shift");
        bool runningPress = Input.GetKey("right shift");


        //Si on clique sur w ou sur la fleche up, le joueur va marcher
        if(forwardPress || walkPress)
        {
            //animator.SetBool("isWalking", true); //isWalking est boleen qui permet d activer l animation de marche
            velocity += acceleration * Time.deltaTime;
        }

        if(!forwardPress || !walkPress)
        {
            //animator.SetBool("isWalking", false);
        }

        if((runPress || runningPress) && (forwardPress || walkPress))
        {
            //animator.SetBool("isRunning", true);
        }
        if((!runPress || !runningPress) && (!forwardPress || !walkPress))
        {
            //animator.SetBool("isRunning", false);
        }

        animator.SetFloat(VelocityHash, velocity);
    }
}
