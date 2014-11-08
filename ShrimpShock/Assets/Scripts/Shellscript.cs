using UnityEngine;
using System.Collections;

public class Shellscript : MonoBehaviour {
    public bool cracked;
    public Sprite cr_sprite;
    public Sprite uc_sprite;
	// Use this for initialization
	void Start () {
        //uc_sprite = Resources.Load("Orange_Box64x64", typeof(Sprite)) as Sprite;
        //cr_sprite = Resources.Load("DarkGrey_Box64x64", typeof(Sprite)) as Sprite;
        cracked = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (cracked) 
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = cr_sprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = uc_sprite;
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        
        cracked = true;
        
    }
}
