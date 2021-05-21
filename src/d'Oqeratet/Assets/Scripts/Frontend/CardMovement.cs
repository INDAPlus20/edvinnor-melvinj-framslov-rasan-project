using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardMovement : MonoBehaviour
{

    public string desiredLocation = "draw_deck";
    private string prevDesiredLocation = "draw_deck";
    private Vector3 desiredPosition;
    private Vector3 desiredRotation;
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        (desiredPosition, desiredRotation) = LocationVectors(desiredLocation);
        transform.localPosition = desiredPosition;
        transform.rotation = Quaternion.Euler(desiredRotation.x, desiredRotation.y, desiredRotation.z);
        
        desiredLocation = "face";
    }

    // Update is called once per frame
    void Update()
    {
        if (desiredLocation != prevDesiredLocation) {
            prevDesiredLocation = desiredLocation;
            (desiredPosition, desiredRotation) = LocationVectors(desiredLocation);

            StopCoroutine("Transform");
            StartCoroutine("Transform");
        }
    }

    private (Vector3, Vector3) LocationVectors(string Location)
    {
        switch (Location)
        {
            case "draw_deck":
                return (new Vector3(0.25f, 1.02f, 0.8f), new Vector3(270.0f, 270.0f, 0.0f));
            case "face":
                return (new Vector3(0.0f, 1.35f, 0.1f), new Vector3(0.0f, 0.0f, 90.0f));
            case "table":
                return (new Vector3(-0.25f, 1.05f, 0.75f), new Vector3(270.0f, 270.0f, 0.0f));
            case "discard_deck":
                return (new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
            default:
                Debug.Log("Invalid destination provided!");
                return (desiredPosition = new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
        }
    }

    IEnumerator Transform()
    {
        Vector3 startPosition = transform.localPosition;
        Vector3 startRotation = transform.localEulerAngles;
        float xRotate = startRotation.x;
        float yRotate = startRotation.y;
        float zRotate = startRotation.z;
        float meter = 0.0f;
        while (meter < 1.0f)
        {
            meter += speed * Time.deltaTime;
            float xMove = (desiredPosition.x - startPosition.x) * speed * Time.deltaTime;
            float yMove = (desiredPosition.y - startPosition.y) * speed * Time.deltaTime;
            float zMove = (desiredPosition.z - startPosition.z) * speed * Time.deltaTime;
            xRotate += RotationDiff(desiredRotation.x, startRotation.x) * speed * Time.deltaTime;
            yRotate += RotationDiff(desiredRotation.y, startRotation.y) * speed * Time.deltaTime;
            zRotate += RotationDiff(desiredRotation.z, startRotation.z) * speed * Time.deltaTime;
            transform.localPosition += new Vector3(xMove, yMove, zMove);
            transform.localRotation = Quaternion.Euler(xRotate, yRotate, zRotate);
            yield return null;
        }
        transform.localPosition = desiredPosition;
        transform.localRotation = Quaternion.Euler(desiredRotation.x, desiredRotation.y, desiredRotation.z);
    }

    float RotationDiff(float desired, float start)
    {
        if (Math.Abs(desired - start) >= 180.0f)
        {
            return (360.0f - Math.Abs(desired - start)) * -Math.Sign(desired - start);
        }
        return desired - start;
    }
}
