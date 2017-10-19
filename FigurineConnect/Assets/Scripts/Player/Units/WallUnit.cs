using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUnit : BaseUnit
{

    private float timeUntilNextUse = 0;
    private float timeUntilFinished = 0;
    private float cooldownTime = 0;
    public GameObject wall;

    private void Start()
    {
        SetCamera();
    }

    public void SetWallHeight(float height)
    {
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, height, wall.transform.localScale.z);
    }
    public void SetWallWidth(float width)
    {
        wall.transform.localScale = new Vector3(width, wall.transform.localScale.y, wall.transform.localScale.z);
    }
    public void SetWallDuration(float duration)
    {
        timeUntilFinished = duration;
    }
    public void SetWallCooldown(float cooldown)
    {
        cooldownTime = cooldown;
    }

    void Update()
    {
        if (IsSelected() && Input.GetMouseButtonDown(0)) SetNewPosition(Input.mousePosition.x, Input.mousePosition.y);

        if (timeUntilNextUse <= 0)
        {
            //Can be used
        }

        //if (active)
        {
            timeUntilFinished -= 1 * Time.deltaTime;
        }

        timeUntilNextUse -= 1 * Time.deltaTime;

        Rotate();
    }
}
