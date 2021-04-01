using Core.Models;
using System;

namespace Core.ActionParam
{
    public class GetTextValue
    {
        public String WithExpression { get; set; }
        public String ToVariable { get; set; }

        public GetTextValue(String withExpression, String toVariable)
        {
            WithExpression = withExpression;
            ToVariable = toVariable;
        }
    }
}
