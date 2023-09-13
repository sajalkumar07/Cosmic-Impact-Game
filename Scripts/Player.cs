using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float thrustSpeed = 1.0f ;
    public float turnSpeed = 1.0f ;
    private bool thrust;
    private float turnDirection;
    public Bullet bulletPrefab;

    
    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
     
    private void Update() 
    {
        
        thrust = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1.0f;
        }  
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            turnDirection = -1.0f;
        }
        else{
            turnDirection = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }

    }

    private void FixedUpdate() 
    {
        if(thrust)
        {
            rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }

        if(turnDirection != 0.0f){
            rigidbody.AddTorque(turnDirection * this.turnSpeed); 
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Shoot(this.transform.up);
    }
}
