using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUnit : BaseUnit
{

    public static WallUnit Instance;

    private float timeUntilNextUse = 0;
    private float timeUntilFinished = 0;
    private float cooldownTime = 0;


    void Awake()
    {
        Instance = this;
    }

    public void SetWallHeight(float height)
    {
        transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
    }
    public void SetWallWidth(float width)
    {
        transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);
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
