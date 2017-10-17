using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.Networking;
using ParadoxNotion.Design;

[Category("Unet Network")]
public class NetworkIdentityHasAuthority : ConditionTask<NetworkIdentity> {

    protected override bool OnCheck()
    {
        return agent.hasAuthority;
    }
}
