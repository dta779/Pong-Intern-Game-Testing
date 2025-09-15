using UnityEngine;
public class PlayerPad : MonoBehaviour
{
    public float boundary = 2.5f;
    public bool isPlayer2 = false;

    void Update()
    {
        if (!isPlayer2)
        {
            //bottom half (player1)
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.y < Screen.height / 2)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.position = new Vector3(Mathf.Clamp(touchPos.x, -boundary, boundary), transform.position.y, 0);
                }
            }
        }
        else
        {
            //top half (player2)
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.y > Screen.height / 2)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.position = new Vector3(Mathf.Clamp(touchPos.x, -boundary, boundary), transform.position.y, 0);
                }
            }
        }

        //clamp position
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -boundary, boundary);
        transform.position = pos;
    }
}