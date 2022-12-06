using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace EgoParadise.UnityTypedAnimator.Editor.Editor
{
    internal static class VisualElementExtensions
    {
        // InspectorElement.FillDefaultInspector generated field name.
        public static PropertyField QDefaultProperty(this VisualElement element, string propertyName)
        {
            return element.Q<PropertyField>($"PropertyField:{propertyName}");
        }
    }
}
