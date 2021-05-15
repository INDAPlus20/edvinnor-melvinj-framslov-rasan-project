using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoutine : MonoBehaviour
{
    private GameDataManager GDM;
    private int target;
    private int prevTarget;
    private int speed = 200;
    private float yrot;

    void Start() {
        GDM = GameObject.Find("Game Manager").GetComponent<GameDataManager>();
        target = 90 * GDM.getTurnIndex();
        prevTarget = target;
    }

    void Update()
    {
        target = 90 * GDM.getTurnIndex();
        if (target != prevTarget)
        {
            StopCoroutine("TurnToTurn");
            StartCoroutine("TurnToTurn");
            prevTarget = target;
        }
    }

    // Rotate camera around table until reaching the correct player, then lock
    private IEnumerator TurnToTurn()
    {
        yrot = transform.localEulerAngles.y;
        while (yrot != target)
        {
            yrot = transform.localEulerAngles.y;
            if (target != 0 && yrot < target && yrot + speed * Time.deltaTime > target)
            {
                transform.localEulerAngles = new Vector3(0.0f, target, 0.0f);
            }
            else if (target == 0 && yrot + speed * Time.deltaTime > 360)
            {
                transform.localEulerAngles = new Vector3(0.0f, target, 0.0f);
            }
            else {
                transform.localEulerAngles += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
                print(yrot + speed * Time.deltaTime);
                print(target);

                yield return null;
            }
        }
    }
}
