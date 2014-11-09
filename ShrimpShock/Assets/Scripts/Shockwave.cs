using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {
    public float velocity;
    public float velocityGain;
    public bool shootable;
    public string color;
    public bool slowdown;
    public float slowDownTimer;
    public float slowDownTimeStart;
    public Vector3 startPosition;
    public Vector3 directionPosition;
    public float resetspeed;


	// Use this for initialization
	void Start () {
        shootable = true;
        color = "none";
        //slowDownTimeStart = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
        if (slowdown)
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
                startPosition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                directionPosition = Input.mousePosition - startPosition;
                Vector2 pos = directionPosition-gameObject.transform.position;
                pos.Normalize();
                shoot(pos);
            }
        }
        if (rigidbody2D.velocity.magnitude<=resetspeed)
        {
            reset();
        }
	}
    void reset()
    {
        gameObject.transform.position = new Vector2(0.0f, 0.0f);
        shootable = true;
        slowdown = false;
        slowDownTimer = 0f;
        rigidbody2D.velocity=new Vector2(0.0f,0.0f);
        color = "none";
    }
    void shoot(Vector2 direction){
        shootable = false;
        slowdown = false;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Debug.Log(rigidbody2D.velocity+" "+(-1*rigidbody2D.velocity));
        if (rigidbody2D.velocity.magnitude == 0)
        {
            rigidbody2D.AddForce(direction * velocity);
        }
        else
        {
            rigidbody2D.AddForce(-1 * rigidbody2D.velocity);
//            rigidbody2D.AddForce(direction * velocity * velocityGain, ForceMode2D.Force);
//            rigidbody2D.Force(direction * velocity * velocityGain);
        }

        GameObject.Find("CrabPistolAnimation").GetComponent<CrabPistolAnimator>().ResetAnimation();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        string colliderColor = col.gameObject.tag;
        if (colliderColor!="Untagged")
        {
            slowdown = true;
            slowDownTimer = slowDownTimeStart;
            Time.timeScale = 0.01f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            shootable = true;
            if (color == "none")
            {
                color = colliderColor;
                Destroy(col.gameObject);
            }
            else if (color == colliderColor)
            {
                Destroy(col.gameObject);
            }
            else if (color != colliderColor)
            {
                reset();
            }
        }
    }
}
