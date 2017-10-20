using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUnit : BaseUnit
{

    public static WallUnit Instance;

    private float timeUntilNextUse = 0;
    private float timeUntilFinished = 0;
    private float cooldownTime = 0;
    public GameObject wall; 

    void Awake()
    {
        Instance = this;
    }

    public void SetWallHeight(float height)
    {
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, height, wall.transform.localScale.z);
        wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + height / 2, wall.transform.position.z);
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
        if (IsSelected() && Input.GetMouseButtonDown(0)) {
            SetNewPosition(Input.mousePosition.x, Input.mousePosition.y);
            Rotate();
        }

        if (timeUntilNextUse <= 0)
        {
            //Can be used
        }

        //if (active)
        {
            timeUntilFinished -= 1 * Time.deltaTime;
        }

        timeUntilNextUse -= 1 * Time.deltaTime;

        
    }
}
