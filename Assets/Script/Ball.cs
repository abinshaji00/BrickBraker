using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gm;
    public float speed = 500f;
    public Rigidbody2D rb1
    {
        get; private set;
    }
    private void Awake()
    {
        rb1 = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Resetball();
    }
    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        rb1.AddForce(force.normalized * this.speed);
    }
    public void Resetball()
    {
        Invoke(nameof(SetRandomTrajectory), 1f);
        transform.position = Vector2.zero;
        rb1.velocity = Vector2.zero;
    }
}
