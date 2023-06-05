using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using Valve.VR.InteractionSystem;


public class CancelTeleportHint: MonoBehaviour

{

    // Start is called before the first frame update

    void Start()

    {

        Teleport.instance.CancelTeleportHint();


    }

}