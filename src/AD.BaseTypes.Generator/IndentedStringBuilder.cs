using System;
using System.Text;

namespace AD.BaseTypes.Generator
{
    class IndentedStringBuilder
    {
        int indent = 0;
        readonly StringBuilder builder = new();

        public void IncreaseIndent() => indent++;

        public void DecreaseIndent() => indent = Math.Max(indent - 1, 0);

        void Indent() => builder.Append(' ', indent * 4);

        public void AppendLine(string text)
        {
            Indent();
            builder.AppendLine(text);
        }

        public override string ToString() => builder.ToString();
    }
}
