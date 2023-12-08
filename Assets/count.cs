using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    public Text countText;
    public float total = 0;
    public void increment()
    {
        total= total +1;
        countText.text ="Count : " +total.ToString();
    }
    public void decrement()
    {
        total = total -1;
        countText.text = "Count : " + total.ToString();
    }
}
