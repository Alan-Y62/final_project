using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suitwalker : MonoBehaviour
{
	public float speed;
	Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
	rb = GetComponent<Rigidbody2D> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2 (speed * 1 + move, rb.velocity.y);
	}


}
