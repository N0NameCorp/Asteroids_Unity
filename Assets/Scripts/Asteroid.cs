using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSize = 0.5f;
    public float maxSize = 3.0f;
    public float speed = 10.0f;

    private float size;
    private float maxLifetime = 30.0f;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.size = Random.Range(minSize, maxSize);
        this.transform.localScale = Vector3.one * this.size;
        this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);

        rigidBody.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        rigidBody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }
}
