using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1); 
    
    [SerializeField] float packageDestroyTime = 0.1f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;
    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Idiot...");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Pizza Picked Up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, packageDestroyTime);
            
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered Pizza!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
 