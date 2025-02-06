using MongoDB.Driver;
using System.Linq.Expressions;
using MaternityHospital.Api.Models.Fhir;

namespace MaternityHospital.Api.Infrastructure.Extensions;

public static class FilterDefinitionBuilderExtensions
{
    public static FilterDefinition<TResult> GetFhirFilterDefinition<TParam, TResult>(
        this FilterDefinitionBuilder<TResult> filterBuilder,
        Expression<Func<TResult, TParam>> func,
        IEnumerable<FhirQuery<TParam>> fhirParams)
        => filterBuilder
            .And(fhirParams
                .Where(_ => _.Value != null)
                .Select(param => param.Operator switch
                {
                    FhirOperator.EQ => filterBuilder.Eq(func, param.Value),
                    FhirOperator.NE => filterBuilder.Ne(func, param.Value),
                    FhirOperator.GT => filterBuilder.Gt(func, param.Value),
                    FhirOperator.LT => filterBuilder.Lt(func, param.Value),
                    FhirOperator.GE => filterBuilder.Gte(func, param.Value),
                    FhirOperator.LE => filterBuilder.Lte(func, param.Value),
                    FhirOperator.SA => filterBuilder.Gt(func, param.Value),
                    FhirOperator.EB => filterBuilder.Lt(func, param.Value),
                    _ => throw new InvalidDataException($"Invalid operator: {param.Operator}")
                }));
}
