using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Á¬·¢Ç¹
/// </summary>
public class AutoGun : Gun
{
    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            base.Firing(base.firePoint.forward);
            base.Firing(base.firePoint.forward);
            base.Firing(base.firePoint.forward);
        }
        if (Input.GetKeyDown(KeyCode.R))
            base.UpdateAmmo();
    }
}
