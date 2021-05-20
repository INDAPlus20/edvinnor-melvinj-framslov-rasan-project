using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardMovement : MonoBehaviour
{

    public string desiredPosition = "draw_deck";
    private string prevDesiredPosition = "draw_deck";
    private Transform desiredTransform;
    private Vector3 desiredTranslation;
    private Vector3 desiredRotation;
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (desiredPosition != prevDesiredPosition) {
            prevDesiredPosition = desiredPosition;
            switch (desiredPosition)
            {
                case "draw_deck":
                    desiredTranslation = new Vector3(0.25f, 1.02f, 0.8f);
                    desiredRotation = new Vector3(270.0f, 270.0f, 0.0f);
                    break;
                case "face":
                    desiredTranslation = new Vector3();
                    desiredRotation = new Vector3();
                    break;
                case "table":
                    desiredTranslation = new Vector3();
                    desiredRotation = new Vector3();
                    break;
                case "discard_deck":
                    desiredTranslation = new Vector3();
                    desiredRotation = new Vector3();
                    break;
                default:
                    Debug.Log("Invalid destination provided!");
                    break;
            }

            StopCoroutine("Transform");
            StartCoroutine("Transform");
        }
    }

    IEnumerator Transform()
    {
        Vector3 startPosition = transform.position;
        Vector3 startRotation = transform.eulerAngles;
        while (transform.position.x < (desiredTranslation.x * Math.Sign(desiredTranslation.x - startPosition.x)))
        {
            float xStepMove = (desiredTranslation.x - startPosition.x) * speed * Time.deltaTime;
            float yStepMove = (desiredTranslation.z - startPosition.y) * speed * Time.deltaTime;
            float zStepMove = (desiredTranslation.x - startPosition.z) * speed * Time.deltaTime;
            transform.position += new Vector3(xStepMove, yStepMove, zStepMove);
            yield return null;
        }
        transform.position = desiredTranslation;
        transform.eulerAngles = desiredRotation;
    }
}
