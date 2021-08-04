using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip throwKnife;
    public AudioClip logTouch;


    [SerializeField]
    private Vector2 throwForce;

    //knife shouldn't be controlled by the player when it's inactive 
    //(i.e. it already hit the log / another knife)
    private bool isActive = true;

    //for controlling physics
    private Rigidbody rb;
    //the collider attached to Knife
    private BoxCollider knifeCollider;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        knifeCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        //this method of detecting input also works for touch
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            audiosource.PlayOneShot(throwKnife);
            //"throwing" the knife
            rb.AddForce(throwForce, ForceMode.Impulse);
            //once the knife isn't stationary, we can apply gravity (it will not automatically fall down)
            rb.useGravity=true;
            //Decrement number of available knives
            GameControllerknifehit3d.Instance.GameUI.DecrementDisplayedKnifeCount();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //we don't even want to detect collisions when the knife isn't active
        if (!isActive)
            return;

        //if the knife happens to be active (1st collision), deactivate it
        isActive = false;

        if (collision.collider.tag == "Log")
        {
            //play the particle effect on collision,
            //you don't always have to store the component in a field...
            GetComponent<ParticleSystem>().Play();
            audiosource.PlayOneShot(logTouch);

            //stop the knife
            rb.velocity = new Vector3(0, 0, 0);
            //this will automatically inherit rotation of the new parent (log)
            rb.isKinematic = true;
            transform.SetParent(collision.collider.transform);

            //move the collider away from the blade which is stuck in the log
            knifeCollider.transform.position = new Vector3(knifeCollider.transform.position.x, knifeCollider.transform.position.y, knifeCollider.transform.position.z);
            knifeCollider.size = new Vector3(0.08f, 0.15f, knifeCollider.size.z);
            knifeCollider.center = new Vector3(0, -0.01f, 0);
            //Spawn another knife
            GameControllerknifehit3d.Instance.OnSuccessfulKnifeHit();
        }
        //collision with another knife
        else if (collision.collider.tag == "Knife")
        {
            //start rapidly moving downwards
            rb.velocity = new Vector3(rb.velocity.x, -2,0);
            //Game Over
            GameControllerknifehit3d.Instance.StartGameOverSequence(false);
        }
    }
}
