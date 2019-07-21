using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
   public static class Extensions
    {
        public static List<ListItem> ToListItem(this Enum myEnum)
        {
            return ((Enum[])Enum.GetValues(myEnum.GetType())).Select(e => new ListItem
            {
                Text = e.ToString(),
                Value = Convert.ToInt32(e)
            }
            ).ToList();
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> initialExpresssion, Expression<Func<T, bool>> toAppendExpression)
        {
            if (initialExpresssion == null && toAppendExpression == null)
                return null;
            if (initialExpresssion == null)
                return toAppendExpression;
            if (toAppendExpression == null)
                return initialExpresssion;

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(initialExpresssion.Body, new ReplaceParameterExpressionVisitor(toAppendExpression.Parameters, initialExpresssion.Parameters).Visit(toAppendExpression.Body)), initialExpresssion.Parameters);
        }
    }
   internal sealed class ReplaceParameterExpressionVisitor : ExpressionVisitor
    {
        private readonly IDictionary<ParameterExpression, ParameterExpression> _parameterDictionary;

        public ReplaceParameterExpressionVisitor(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
        {
            _parameterDictionary = new Dictionary<ParameterExpression, ParameterExpression>();
            for (var i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                _parameterDictionary.Add(fromParameters[i], toParameters[i]);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (_parameterDictionary.TryGetValue(node, out replacement))
                node = replacement;
            return base.VisitParameter(node);
        }
    }


    public class ListItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
