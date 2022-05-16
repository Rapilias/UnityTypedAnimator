using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    [CustomEditor(typeof(AnimatorCodeGenGlobalConfigureAsset))]
    public class AnimatorCodeGenGlobalConfigureAssetEditor : UnityEditor.Editor
    {
        private AnimatorCodeGenGlobalConfigureAsset targetAsset => this.target as AnimatorCodeGenGlobalConfigureAsset;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate"))
            {
                TypedAnimatorCodeGenerator.Generate(this.targetAsset);
            }
        }
    }
}
