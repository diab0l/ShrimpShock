using UnityEngine;

public class CrabPistolAnimator : MonoBehaviour {
    public Sprite[] Sprites;
    public float FramesPerSecond;
    private bool run;

    private SpriteRenderer spriteRenderer;

    public void ResetAnimation() {
        this.run = true;
    }

    // Use this for initialization
    private void Start() {
        this.spriteRenderer = this.renderer as SpriteRenderer;	
    }
    
    // Update is called once per frame
    private void Update() {
        if (!this.run) {
            return;
        }

        var index = (int)(Time.timeSinceLevelLoad * this.FramesPerSecond);

        if (index >= this.Sprites.Length) {
            this.run = false;
        }

        index = index % this.Sprites.Length;

        this.spriteRenderer.sprite = this.Sprites[index];
    }
}
