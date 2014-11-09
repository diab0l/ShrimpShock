using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {
    float velocity =500;
    public bool shootable;
    public string color;
    public bool slowdown;
    public float slowDownTimer;
    public Vector3 startPosition;
    public Vector3 directionPosition;
    public Vector2 direction;

	// Use this for initialization
	void Start () {
        //rigidbody2D.AddForce(direction*velocity);
        shootable = true;
        color = "none";
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.localPosition += direction * velocity * Time.deltaTime;
        //Debug.Log("Vorwaerts");
        //rigidbody2D.velocity = rigidbody2D.velocity*0.9999f;
        if (slowdown && !shootable)
	    {
		    slowDownTimer-=Time.deltaTime;
            if (slowDownTimer<=0)
	        {
		    slowdown=false;
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
	        }
	    }
        if (shootable)
        {
            if(Input.GetMouseButtonDown(0))
            {

                //gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                startPosition = Input.mousePosition;
                startPosition.z = 25f;
                gameObject.transform.position = Camera.main.ScreenToWorldPoint(startPosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                directionPosition = Input.mousePosition - startPosition;
                Vector2 pos = directionPosition;
                if (Mathf.Abs(pos.x) > Mathf.Abs(pos.y))
                {
                    pos.x = pos.x / Mathf.Abs(pos.y);
                    pos.y = pos.y / Mathf.Abs(pos.y);
                }
                else
                {
                    pos.x = pos.x / Mathf.Abs(pos.x);
                    pos.y = pos.y / Mathf.Abs(pos.x);
                }
                direction = pos;
//                direction = pos / (Mathf.Sqrt(pos.x*pos.x+pos.y*pos.y));
                shoot(direction);
            }

            
        }
        if (rigidbody2D.velocity==(new Vector2(0.0f,0.0f)) && !shootable)
        {
            reset();
        }
	}
    void reset()
    {
        gameObject.transform.position = new Vector2(1.0f, 1.0f);
        shootable = true;
        rigidbody2D.velocity=new Vector2(0.0f,0.0f);
    }
    void shoot(Vector2 direction){
        shootable = false;
        slowdown = false;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        rigidbody2D.AddForce(direction * velocity);
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        string colliderColor = col.gameObject.tag;
        if (colliderColor!="Untagged")
        {
            slowdown = true;
            slowDownTimer=0.04f;
            Time.timeScale=0.01f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            shootable=true;
            if (color == "none")
            {
                color = colliderColor;
            }
            else if (color != colliderColor)
            {
                reset();
            }
        }
    }
}
