using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float slowSpeed = 20f;
    [SerializeField] float boostSpeed = 40f;
    bool hasPackage;

    SpriteRenderer SpriteRenderer;

    void Start()
    {
       SpriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("You tough bastard!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked Up!");
            hasPackage = true;
            SpriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, 0.25f);
        }
        else if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered Package!");
            hasPackage = false;
            SpriteRenderer.color = noPackageColor;
        }
    }
}
