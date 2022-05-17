using System;
using System.Text;

namespace EgoParadise.UnityTypedAnimator.Editor
{
    public struct BlockTextWriter : IDisposable
    {
        private StringBuilder builder;
        private readonly string endText;

        public BlockTextWriter(StringBuilder builder, string beginText, string endText)
        {
            this.builder = builder;
            this.endText = endText;

            this.builder.Append(beginText);
        }

        public void Dispose()
        {
            this.builder.Append(endText);
        }
    }

    public static class BlockTextWriterExtensions
    {
        public static BlockTextWriter Block(this StringBuilder builder, string beginText, string endText)
        {
            return new BlockTextWriter(builder, beginText, endText);
        }
    }
}
