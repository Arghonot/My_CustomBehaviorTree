﻿using UnityEngine;
using UnityEditor;
using Graph;
using System;

namespace GraphEditor
{
    [CustomEditor(typeof(GraphRunner))]
    public class GraphRunnerEditor : Editor
    {
        GraphRunner runner;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            runner = target as GraphRunner;

            if (target == null) return;

            HandleNewGraph();
            HandleNewSo();

            serializedObject.ApplyModifiedProperties();
        }

        void HandleNewSo()
        {
            runner.So = (ScriptableObject)EditorGUILayout.ObjectField(runner.So, typeof(ScriptableObject), true);

            if (runner.So != null && runner.graph != null)
            {
                DrawValidity();
            }
        }

        void    HandleNewGraph()
        {
            var TmpGraph = runner.graph;
            TmpGraph = (Graph.TestGraph)EditorGUILayout.ObjectField(runner.graph, typeof(Graph.TestGraph), true);

            if (TmpGraph == null)
            {
                return;
            }
            else if (TmpGraph != runner.graph)
            {
                runner.graph = TmpGraph;
            }

            runner.BuildValueDictionnary();
        }

        void DrawValidity()
        {
            DrawValidityGraphSo();
        }

        void DrawValidityGraphSo()
        {
            foreach (var item in runner.values.Values)
            {
                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(item.Name);

                if (DoesSoContainsValue(item.Name, item.GetValueType()))
                {
                    EditorGUILayout.LabelField("    OK");
                }
                else
                {
                    EditorGUILayout.LabelField("    NOK");
                }

                GUILayout.EndHorizontal();
            }
        }

        bool DoesSoContainsValue(string name, Type valueType)
        {
            var properties = runner.So.GetType().GetProperties();

            foreach (var property in runner.So.GetType().GetFields())
            {
                if (property.Name == name && property.FieldType == valueType)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Display for each variable in the So if it is being used in the Graph.
        /// </summary>
        /// <param name="runner"></param>
        void DrawValiditySoGraph()
        {
            var properties = runner.So.GetType().GetProperties();

            foreach (var property in runner.So.GetType().GetFields())
            {
                GUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(property.Name);

                if (runner.ContainsValue(property.Name, property.FieldType))
                {
                    EditorGUILayout.LabelField("    OK");
                }
                else
                {
                    EditorGUILayout.LabelField("    NOK");
                }

                GUILayout.EndHorizontal();
            }
        }
    }
}