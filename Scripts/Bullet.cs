using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Rigidbody2D rigidbody;
   public float speed = 500.0f;
   public float maxLifetime = 10.0f;

   private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        rigidbody.AddForce(direction*this.speed);
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D (Collision2D collsion) {
       
        Destroy(this.gameObject);
      
    }
    
}
