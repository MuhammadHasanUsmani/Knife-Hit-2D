using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit : MonoBehaviour 
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            print("fruithit");
            GetComponent<ParticleSystem>().Play();
            Score.instance.SetScore();
            Destroy(this.gameObject);
        }

    }
    //Rigidbody rb;
    //Rigidbody Childrb;
    //Collider ChildCollider;
    //Collider SecondCollider;
    //public GameObject pear;
    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    pear = GetComponentInChildren<GameObject>();
    //}
    ////private void OnTriggerEnter (Collision collision)
    ////{
    ////    if (collision.collider.tag == "Knife")
    ////    {
    ////        pear = pear.transform.GetChild(0).gameObject;
    ////        pear.transform.parent=null;
    ////         rb.useGravity = true;
    ////        transform.parent = null;
    ////    }

    ////}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Knife")
    //    {
    //        Childrb = pear.transform.GetChild(1).gameObject.GetComponent<Rigidbody>();
    //        Childrb.useGravity = true;
    //        pear = pear.transform.GetChild(0).gameObject;
    //        Childrb = pear.GetComponent<Rigidbody>();
    //        Childrb.useGravity = true;
    //        rb.useGravity = true;
    //        DelayCollider(pear);

    //    }

    //}
    //public void ColliderOn(GameObject FirstChild, GameObject SecondChild)
    //{
    //    SecondCollider = FirstChild.GetComponent<MeshCollider>();
    //    SecondCollider.enabled = true;
    //    ChildCollider = SecondChild.GetComponent<SphereCollider>();
    //    ChildCollider.enabled = true;
    //}
    //private IEnumerator DelayCollider(GameObject pear)
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    ColliderOn(transform.GetChild(0).gameObject, transform.GetChild(1).gameObject);
    //    pear.transform.parent = null;
    //    transform.parent = null;
    //}
}
