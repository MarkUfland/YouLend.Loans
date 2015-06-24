using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Common.Ports.Adapters.Persistence
{
    public class LambdaHelper
    {
        public ParameterExpression CreateLambdaObject<T>()
        {
            //The 'o =>' bit of the Lambda expression 
            ParameterExpression queryObject = Expression.Parameter(typeof(T), "o");

            return queryObject;
        }

        public Expression CreateLambdaPredicate<T>(string fieldName, Criteria criteria, object value)
        {
            var queryObject = CreateLambdaObject<T>();

            Expression queryParameterFieldName = queryObject;

            //The field name bit of the lambda expression e.g. o.PartyId
            foreach (var part in fieldName.Split('.'))
            {
                // We now want to combine the property name with the member expression to create the full expression i.e. o.Age. This is the left side element
                queryParameterFieldName = Expression.PropertyOrField(queryParameterFieldName, part);
            }

            
            //Expression queryParameterFieldName = Expression.PropertyOrField(queryObject, fieldName);

            //The value to search for bit of the lambda expression e.g. 1
            ConstantExpression queryParameterFieldValue = Expression.Constant(value, value.GetType());

            //The full query parameter of the lambda expression e.g. o.PartyId == 1
            Expression queryParameterFullExpression = Expression.Equal(queryParameterFieldName, queryParameterFieldValue);

            return queryParameterFullExpression;

        }

        public Expression CombineLambdaPredicatesWithAnd(Expression aPredicate, Expression anotherPredicate)
        {
            return Expression.AndAlso(aPredicate, anotherPredicate);
        }

        public Expression CombineLambdaPredicatesWithOr(Expression aPredicate, Expression anotherPredicate)
        {
            return Expression.OrElse(aPredicate, anotherPredicate);
        }

        public Expression<Func<T, bool>> CreateFullLambdaExpression<T>(ParameterExpression aLambdaObject, Expression aLambdaExpression)
        {
            //The full Lambda expression e.g. o => o.PartyID == 1
            return Expression.Lambda<Func<T, bool>>(aLambdaExpression, aLambdaObject);
        }
    }

    public enum Criteria
    {
        EqualTo,
        NotEqualTo,
        GreaterThan,
        LessThan
    }
}
