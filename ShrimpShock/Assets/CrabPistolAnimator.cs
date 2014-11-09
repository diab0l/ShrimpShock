using System;

using UnityEngine;

public class CrabPistolAnimator : MonoBehaviour {
    public Sprite[] Sprites;
    public float FramesPerSecond;
    
    private SpriteRenderer spriteRenderer;

    private float startTime;


    public void ResetAnimation() {
        this.startTime = Time.timeSinceLevelLoad;
    }

    // Use this for initialization
    private void Start() {
        this.spriteRenderer = this.renderer as SpriteRenderer;	
    }
    
    // Update is called once per frame
    private void Update() {
        var index = (int)((Time.timeSinceLevelLoad - this.startTime) * this.FramesPerSecond);

        if (index > this.Sprites.Length) {
            index = this.Sprites.Length - 1;
        }

        this.spriteRenderer.sprite = this.Sprites[index];
    }
}
