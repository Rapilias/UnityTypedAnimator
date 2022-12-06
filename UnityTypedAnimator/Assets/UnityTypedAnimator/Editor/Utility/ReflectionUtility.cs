namespace EgoParadise.UnityTypedAnimator.Editor
{
    internal static class ReflectionUtility
    {
        public static string ToBackingField(string name)
        {
            return $"<{name}>k__BackingField";
        }
    }
}
