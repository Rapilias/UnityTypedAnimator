using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    [CustomEditor(typeof(AnimatorCodeGenConfigureAsset))]
    public class AnimatorCodeGenConfigureAssetEditor : UnityEditor.Editor
    {
        private TemplateContainer container = null;
        private ScrollView parameterScrollView = null;
        private AnimatorCodeGenConfigureAsset targetAsset => this.target as AnimatorCodeGenConfigureAsset;
        private readonly GUID uxmlPath = new GUID("bad982d0cc0433248b6bc807423e4ce7");

        public override VisualElement CreateInspectorGUI()
        {
            var treeAssetPath = AssetDatabase.GUIDToAssetPath(uxmlPath);
            var treeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(treeAssetPath);
            this.container = treeAsset.Instantiate();

            var animatorContainer = this.container.Q<ObjectField>("AnimatorController");
            animatorContainer.RegisterValueChangedCallback(OnAnimatorControllerChanged);
            this.parameterScrollView = container.Q<ScrollView>("Parameters");
            var typeNameField = this.container.Q<TextField>("TypeName");
            typeNameField.RegisterValueChangedCallback(m =>
            {
                this.targetAsset.typeName = m.newValue;
            });

            animatorContainer.value = targetAsset.animator;
            typeNameField.value = targetAsset.typeName;
            
            var ev = ChangeEvent<Object>.GetPooled(null, targetAsset.animator);
            this.OnAnimatorControllerChanged(ev);
            return this.container;
        }

        public void OnEnable()
        {
            this.Repaint();
        }

        private void OnAnimatorControllerChanged(ChangeEvent<Object> callback)
        {
            var animatorController = callback.newValue as AnimatorController;
            targetAsset.animator = animatorController;

            if (animatorController == null)
            {
                this.UpdateContainer(Array.Empty<AnimatorControllerParameter>());
            }
            else
            {
                this.UpdateContainer(animatorController.parameters);
            }
        }

        private void UpdateContainer(IEnumerable<AnimatorControllerParameter> parameters)
        {
            this.parameterScrollView.contentContainer.Clear();
            foreach (var item in parameters)
            {
                var label = new Label($"{item.type.ToString()}: {item.name}");
                this.parameterScrollView.contentContainer.Add(label);
            }
        }
    }
}
