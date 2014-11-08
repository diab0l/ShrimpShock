using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {

    public Vector2 direction = new Vector2(10f, 10f);
    public float velocity;

	// Use this for initialization
	void Start () {
        rigidbody2D.AddForce(direction*velocity);
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.localPosition += direction * velocity * Time.deltaTime;
        //Debug.Log("Vorwaerts");
        //rigidbody2D.velocity = rigidbody2D.velocity*0.9999f;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
    }
}
