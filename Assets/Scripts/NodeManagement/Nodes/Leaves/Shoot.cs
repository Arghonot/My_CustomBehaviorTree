﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BT.Leaves
{
    public class Shoot : BTNode
    {
        public override BTState Run()
        {
            return AIcontext.Get<GunBehavior>("Gun").Shoot() ?
                BTState.Success :
                BTState.Failure;
        }
    }
}