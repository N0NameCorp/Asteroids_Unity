using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    private Rigidbody2D rigidBody;
    public float thrustSpeed = 1.0f;
    private bool thrusting;
    public float turnSpeed = 1.0f;
    private float turning;
    private float timer = 0f;
    public float shootInterval = 1f;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turning = -1.0f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turning = 1.0f;
        }
        else
        {
            turning = 0;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (thrusting)
        {
            rigidBody.AddForce(this.transform.up * thrustSpeed);
        }

        if (turning != 0)
        {
            rigidBody.AddTorque(turning * turnSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (timer >= shootInterval) {
                Shoot();
                timer = 0f;
            }
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
}
