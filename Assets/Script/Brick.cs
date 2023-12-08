using UnityEngine;

public class Brick : MonoBehaviour
{
    public int helth { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states;
    public bool unbrakable;
    public int points = 100;
    public GameObject particle;
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        ResetBricks();
    }
    public void ResetBricks()
    {
        this.gameObject.SetActive(true);
        if (!unbrakable)
        {
            helth = states.Length;
            spriteRenderer.sprite = states[helth - 1];
        }
    }
    private void Hit()
    {
        if (unbrakable)
        {
            return;
        }
        helth--;
        if (helth <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
             spriteRenderer.sprite = states[helth - 1];
        }
        FindObjectOfType<GameManager>().Hit(this);
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ball")
        {
            Hit(); 
            GameObject x = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(x, 2);
        }

       
    }
}
