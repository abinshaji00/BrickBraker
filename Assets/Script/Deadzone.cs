using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="ball")
        {
            FindObjectOfType<GameManager>().Miss();
        }
    }
}
