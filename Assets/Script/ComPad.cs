using UnityEngine;
public class ComPad : MonoBehaviour
{
    public Transform ball;
    public float speed = 3f;
    public float boundary = 2.5f;

    void Start()
    {
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    void Update()
    {
        if (ball == null) return;

        //move if ball move towards pad
        if (ball.GetComponent<Rigidbody2D>().linearVelocity.y <= 0) return;

        float targetX = ball.position.x + Random.Range(-0.2f, 0.2f);
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(targetX, transform.position.y, 0), speed * Time.deltaTime);

        //clamp post
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -boundary, boundary);
        transform.position = pos;
    }
}