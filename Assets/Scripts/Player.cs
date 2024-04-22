using UnityEngine;
public class Player : MonoBehaviour{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform bird;
    private int spriteIndex;
    private float strength = 5f;
    private float gravity = -9.81f;
    private float tilt = 5f;
    public Vector3 direction;
    private void Start(){
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    private void OnEnable(){
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Flap();
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }
    private void AnimateSprite(){
        spriteIndex++;
        if (spriteIndex >= sprites.Length){
            spriteIndex = 0;
        }
        if (spriteIndex < sprites.Length && spriteIndex >= 0){
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Scoring")) {
            FindObjectOfType<Manager>().IncreaseScore();
        }
    }
    public void Flap(){
        direction = Vector3.up * strength;
    }
    public void Restart(){
        direction.y = 0f;
        bird.position = Vector3.zero;
        bird.Rotate(0.0f, 0.0f, 0.0f);
    }
}