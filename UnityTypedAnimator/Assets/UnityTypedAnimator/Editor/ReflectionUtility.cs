namespace EgoParadise.UnityTypedAnimator.Editor
{
    public static class ReflectionUtility
    {
        public static string ToBackingField(string name)
        {
            return $"<{name}>k__BackingField";
        }
    }
}
