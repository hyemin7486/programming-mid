using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            GameManager.Instance.GameOver();
        }
    }
}
