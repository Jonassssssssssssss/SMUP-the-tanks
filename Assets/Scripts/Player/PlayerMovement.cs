using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] GameObject _wheelsObject;
    [SerializeField] Animator _wheelsAnimator;

    float X;
    float Y;

    [SerializeField] Quaternion[] Rotations;

    void Update()
    {
        if (Input.GetKey("w")) Y = 1f;
        else if (Input.GetKey("s")) Y = -1f;
        else Y = 0f;

        if (Input.GetKey("d")) X = 1f;
        else if (Input.GetKey("a")) X = -1f;
        else X = 0f;

        if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d"))
        {
            _wheelsAnimator.SetBool("IsMoving", false);
        }
        else
        {
            _wheelsAnimator.SetBool("IsMoving", true);
        }

        Move(X, Y);

        if (Input.GetKey("b") && Input.GetKey("o") && Input.GetKey("s"))
        {
            transform.position = new Vector3(-51.6199989f, 198.300003f, 0f);
        }
    }

    void Move(float X, float Y)
    {
        transform.position = new Vector2(transform.position.x + X * _speed * Time.deltaTime, transform.position.y + Y * _speed * Time.deltaTime);

        
        if (X == 1f && Y == 0f) _wheelsObject.transform.rotation = Rotations[0];
        if (X == -1f && Y == 0f) _wheelsObject.transform.rotation = Rotations[1];

        if (X == 0f && Y == 1f) _wheelsObject.transform.rotation = Rotations[2];
        if (X == 0f && Y == -1f) _wheelsObject.transform.rotation = Rotations[3];

        if (X == 1f && Y == 1f) _wheelsObject.transform.rotation = Rotations[4];
        if (X == 1f && Y == -1f) _wheelsObject.transform.rotation = Rotations[5];

        if (X == -1f && Y == 1f) _wheelsObject.transform.rotation = Rotations[6];
        if (X == -1f && Y == -1f) _wheelsObject.transform.rotation = Rotations[7];
        
    }
}
