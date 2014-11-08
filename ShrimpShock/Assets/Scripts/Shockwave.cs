using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {

    public Vector2 direction = new Vector2(10f, 10f);
    public float velocity;
    public bool shootable;

	// Use this for initialization
	void Start () {
        //rigidbody2D.AddForce(direction*velocity);
        shootable = true;
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.localPosition += direction * velocity * Time.deltaTime;
        //Debug.Log("Vorwaerts");
        //rigidbody2D.velocity = rigidbody2D.velocity*0.9999f;
        if (shootable)
        {
            if(Input.GetMouseButtonDown(0))
            {
                direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)-gameObject.transform.position;
                rigidbody2D.AddForce(direction * velocity);
            }
            
        }
        if (rigidbody2D.velocity==(new Vector2(0.0f,0.0f)))
        {
            gameObject.transform.position = (new Vector2(0.0f, 0.0f));
            shootable = true;
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
    }
}
