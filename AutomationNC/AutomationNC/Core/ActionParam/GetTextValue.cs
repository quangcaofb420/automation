using Core.Models;

namespace Core.ActionParam
{
    public class GetTextValue
    {
        public SlnControl Control { get; set; }
        public string WithExpression { get; set; }
        public string ToVariable { get; set; }

        public GetTextValue(SlnControl control, string withExpression, string toVariable)
        {
            Control = control;
            WithExpression = withExpression;
            ToVariable = toVariable;
        }
    }
}
