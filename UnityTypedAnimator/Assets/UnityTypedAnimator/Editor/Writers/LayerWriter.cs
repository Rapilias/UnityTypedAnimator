using System.Text;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public class LayerWriter : IParameterWriter
    {
        public void WriteGetParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public float Get{name}Weight() => this.animator.GetLayerWeight(this.{name}Id);\n");
        }

        public void WriteOtherParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
        }

        public void WriteSetParameterFunction(StringBuilder builder, string name, int baseIndent)
        {
            var indent = new string(' ', baseIndent);
            builder.Append($"{indent}public void Set{name}Weight(float {name}) => this.animator.SetLayerWeight(this.{name}Id, {name});\n");
        }
    }
}
