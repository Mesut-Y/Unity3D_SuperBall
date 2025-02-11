using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerTransform.position + offset;  // this ile bu script component yap�lm�� kamerada pozisyonu player+offset yap�l�r.
    }
}
