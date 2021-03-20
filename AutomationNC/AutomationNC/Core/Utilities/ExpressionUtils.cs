
using Expressive;

namespace Core.Utilities
{
   public  class ExpressionUtils
    {
        public static object Evaluate(string expression)
        {
            Expression expr = new Expression("1+2");
            object result = expr.Evaluate();
            return result;
        }
    }
}
