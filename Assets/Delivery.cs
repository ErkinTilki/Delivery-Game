using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  public bool checkPackage = false;
  [SerializeField] float destroyDelay = 0.5f;
  [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
  [SerializeField] Color32 noPackageColor = new Color32(0, 0, 0, 0);
  public SpriteRenderer carSpriteRenderer;

     void Start() {
        carSpriteRenderer = GetComponent<SpriteRenderer>();
    }
     void OnCollisionEnter2D(Collision2D other) 
     {
        Debug.Log("Ouch!");
     }

      void OnTriggerEnter2D(Collider2D other) 
      {
        if(other.tag == "Package" && (!checkPackage)){
          Debug.Log("Package Picked Up");
          carSpriteRenderer.color = hasPackageColor;
          checkPackage = true;
          Destroy(other.gameObject, destroyDelay);
          
        }
        
        if(other.tag == "Customer" && (checkPackage) ){
          Debug.Log("Delivered Package");
          carSpriteRenderer.color = noPackageColor;
          checkPackage = false;
          
        }
      }
      
}
