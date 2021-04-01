using Core.Models;
using System;

namespace Core.ActionParam
{
    public class GetLabel
    {
        public String WithExpression { get; set; }
        public String ToVariable { get; set; }

        public GetLabel( String withExpression, String toVariable)
        {
            WithExpression = withExpression;
            ToVariable = toVariable;
        }
    }
}
