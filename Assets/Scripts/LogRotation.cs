using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogRotation : MonoBehaviour
{
    [System.Serializable] 
    private class RotationElement
    {
#pragma warning disable 0649
        public float Speed;
        public float Duration;
#pragma warning restore 0649
    }

    [SerializeField] 
    private RotationElement[] rotationPattern;

    [SerializeField]
    private GameObject Log;
    float degrees = 90;
    Vector3 to;

    int rotationIndex = 0;  

    private void Awake()
    {
        StartCoroutine("PlayRotationPattern");

        
    }
    private void FixedUpdate()
    {
            degrees = rotationPattern[rotationIndex].Speed;
            to = new Vector3(0,degrees,0);
            transform.Rotate(to * Mathf.Abs(rotationPattern[rotationIndex].Speed) * Time.deltaTime);
           
    }

    private IEnumerator PlayRotationPattern()
    {
        //infinite coroutine loop
        while (true)
        {
            yield return new WaitForFixedUpdate();
            //let the motor do its thing for the specified duration
            yield return new WaitForSecondsRealtime(rotationPattern[rotationIndex].Duration);
            rotationIndex++;
            //infinite loop through the rotationPattern
            rotationIndex = rotationIndex < rotationPattern.Length ? rotationIndex : 0;
        }
    }
    public void DestroyObj()
    {
        Destroy(this);
    }
}
