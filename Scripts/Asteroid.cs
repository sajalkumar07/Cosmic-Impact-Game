using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    public float speed = 5.0f;
    public float maxLifetime = 30.0f;
    public AudioSource audioPlayer;

    private void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Start() 
    {
    
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        
        rigidbody.mass = this.size * 2.0f;
         
    
    }
    public void SetTrajectory(Vector2 direction)
    {
        rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collsion)
    {

       
        if(collsion.gameObject.tag == "Bullet")
        {
            if((this.size * 0.5f) >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            Destroy(this.gameObject);
        }
        
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this,  position, this.transform.rotation);
        half.size = this.size / 2;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }
}
