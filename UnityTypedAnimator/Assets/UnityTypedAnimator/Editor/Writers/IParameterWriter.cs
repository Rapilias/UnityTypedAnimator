using System.Text;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public interface IParameterWriter
    {
        public void WriteGetParameterFunction(StringBuilder builder, string name, int baseIndent);
        public void WriteSetParameterFunction(StringBuilder builder, string name, int baseIndent);
        public void WriteOtherParameterFunction(StringBuilder builder, string name, int baseIndent);
    }
}
