﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Graph
{
    [CreateNodeMenu("Graph/SubGraph")]
    public class SubGraph : Node
    {
        public DefaultGraph TargetGraph;
    }
}