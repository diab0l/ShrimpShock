using System;

using UnityEngine;

public class CrabPistolAnimator : MonoBehaviour {
    public Sprite[] Sprites;
    public float FramesPerSecond;

    private SpriteRenderer spriteRenderer;
    private float startTime;

    private Vector3 p;
    private float angle;

    private bool runAnimation;

    public void ResetAnimation(Vector3 pos, float angle) {
        this.startTime = Time.timeSinceLevelLoad;
        this.runAnimation = true;

        var col = this.spriteRenderer.material.color;
        this.spriteRenderer.material.color = new Color(col.r, col.g, col.b, 1);

        this.transform.position = this.p;
        this.transform.RotateAround(new Vector3(), new Vector3(0, 0, 1), -this.angle);

        this.angle = angle;
        
        this.transform.RotateAround(new Vector3(), new Vector3(0, 0, 1), this.angle);
        this.p = this.transform.position;
        this.transform.position = pos;
    }

    // Use this for initialization
    private void Start() {
        this.spriteRenderer = this.renderer as SpriteRenderer;

        this.runAnimation = false;
    }
    
    // Update is called once per frame
    private void Update() {
        var index = (int)((Time.timeSinceLevelLoad - this.startTime) * this.FramesPerSecond);

        if (index >= this.Sprites.Length - 1) {
            index = this.Sprites.Length - 1;

            this.runAnimation = false;
        }

        if (!this.runAnimation) {
            var col = this.spriteRenderer.material.color;

            var alpha = col.a * 0.1f;

            if (alpha < 0.2) {
                alpha = 0;
            }

            this.spriteRenderer.material.color = new Color(col.r, col.g, col.b, alpha);
        }

        this.spriteRenderer.sprite = this.Sprites[index];
    }
}
