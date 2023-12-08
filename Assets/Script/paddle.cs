using UnityEngine;

public class paddle : MonoBehaviour
{
    public Rigidbody2D rb
    {
        get; private set;
    }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    public float maxBounceAngle = 75f;

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();   
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            this.direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            this.direction = Vector2.right;
        }
        else
            this.direction = Vector2.zero;
    }
    private void FixedUpdate()
    {
        if (this.direction!=Vector2.zero)
        {
            this.rb.AddForce(this.direction*this.speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball=collision.gameObject.GetComponent<Ball>();
        if (ball!=null)
        {
            Vector3 paddlepos=this.transform.position;
            Vector2 contactPint = collision.GetContact(0).point;
            float offset= paddlepos.x-contactPint.x;
            float width=collision.otherCollider.bounds.size.x/2;

            float CurrentAngle = Vector2.SignedAngle(Vector2.up, ball.rb1.velocity);
            float BounceAngle = (offset / width)*this.maxBounceAngle;
            float newAngle = Mathf.Clamp(CurrentAngle + BounceAngle, -maxBounceAngle, maxBounceAngle);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rb1.velocity = rotation * Vector2.up * ball.rb1.velocity.magnitude;
        }
    }
    public void Resetpaddle()
    {
        transform.position=new Vector2(0, transform.position.y);
        rb.velocity=Vector2.zero;
    }
}
