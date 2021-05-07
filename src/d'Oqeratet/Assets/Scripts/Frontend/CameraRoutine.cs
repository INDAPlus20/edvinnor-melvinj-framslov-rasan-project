using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoutine : MonoBehaviour
{
    private TurnManager tm;
    private int turn;
    private int speed = 200;

    void Start() {
        tm = GameObject.Find("Stage Hand").GetComponent<TurnManager>();
    }

    void Update()
    {
        // Rotate camera around table until reaching the correct player, then lock
        turn = tm.turn;
        if (Mathf.Abs(transform.localEulerAngles.y - turn * 90) > 1.0f)
        {
            transform.localEulerAngles += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0.0f, turn * 90, 0.0f);
        }
    }
}
