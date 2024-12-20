﻿using UdonSharp;
#if UNITY_EDITOR

using System;
using UnityEditor;
#endif
using UnityEngine;

namespace net.fushizen.attachable
{
    public class AttachablesPrefabFixerUpper : MonoBehaviour
    {
#if UNITY_EDITOR
        private bool IsUdonSharp10()
        {
            return typeof(UdonSharpEditor.UdonSharpEditorUtility)
                .GetMethod(nameof(UdonSharpEditor.UdonSharpEditorUtility.ConvertToUdonBehavioursWithUndo))
                ?.GetCustomAttributes(typeof(ObsoleteAttribute), false).Length > 0;
        }
        private void OnValidate()
        {
            if (PrefabUtility.IsPartOfPrefabAsset(this)
                || UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage() != null)
            {
                return;
            }

            EditorApplication.delayCall += () =>
            {
                if (this == null) return;

                if (IsUdonSharp10())
                {
                    DestroyImmediate(this);
                    return;
                }
                
                // If we're running on pre-1.0 UdonSharp, our prefabs are a bit busted, with proxy behaviours
                // disconnected from their backing udon behaviour. This code deletes the proxy components; pre-1.0
                // U# will automagically recreate them for us.
                foreach (var udonSharpBehaviour in GetComponentsInChildren<UdonSharpBehaviour>(true))
                {
                    DestroyImmediate(udonSharpBehaviour);
                }

                DestroyImmediate(this);
            };
        }

#endif
    }
}
