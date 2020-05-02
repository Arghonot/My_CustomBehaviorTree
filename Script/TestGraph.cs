﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;


namespace BT
{
    [CreateAssetMenu]
    public class TestGraph : NodeGraph
    {
        public Blackboard blackboard;

        private void Awake()
        {
            Variable vari = new Blackboard_Int();

            blackboard = AddNode<Blackboard>();
            
            NodeEditorWindow.RepaintAll();
        }

        // TODO iterate through all the sub graphs and compile their blackboard with this current graph.
        // Also handle subgraph's subgraph -> call CompileAllBlackboard always
        Dictionary<string, BlackBoardGraphElement>   CompileAllBlackboard()
        {
            //Dictionary<string, BlackboardElement> elems =
            //    new Dictionary<string, BlackboardElement>();

            return blackboard.container;

            //return elems;
        }
    }
}