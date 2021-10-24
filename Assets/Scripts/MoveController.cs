using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    [SerializeField] GameObject player;

    private Transform _transform;

    private int _laneNumber = 1;
    private int _lanesCount = 2;

    private bool _didChangeLastFrame = false;
    public static bool stop = false;

    public float speed = 15f;
    public float firstLanePos = 5f;
    public float laneDistance = -5f;
    public float sideSpeed = 3f;

    public Vector3 moveVector;

    void Start()
    {
        _transform = player.transform;
        moveVector = new Vector3(1, 0, 0);
    }

    void Update()
    {
        if (!stop)
        {
            _transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);


            float input = Input.GetAxis("Horizontal");

            if (Mathf.Abs(input) > 0f)
            {
                if (!_didChangeLastFrame)
                {
                    _didChangeLastFrame = true;
                    _laneNumber += (int)Mathf.Sign(input);
                    _laneNumber = Mathf.Clamp(_laneNumber, 0, _lanesCount);
                }
            }
            else
            {
                _didChangeLastFrame = false;
            }

            Vector3 newPos = _transform.position;
            newPos.z = Mathf.Lerp(newPos.z, -firstLanePos - (_laneNumber * laneDistance), Time.deltaTime * sideSpeed);
            _transform.position = newPos;
        }
    }
}
