using MongoDB.Driver;
using System.Linq.Expressions;
using MaternityHospital.Api.Models.Fhir;

namespace MaternityHospital.Api.Infrastructure.Extensions;

public static class FilterDefinitionBuilderExtensions
{
    public static FilterDefinition<TResult> GetFhirFilterDefinition<TParam, TResult>(
        this FilterDefinitionBuilder<TResult> filterBuilder,
        Expression<Func<TResult, TParam>> func,
        FhirQuery<TParam> fhirParam)
        => filterBuilder.And(
            fhirParam.Operator switch
            {
                FhirOperator.EQ => filterBuilder.Eq(func, fhirParam.Value),
                FhirOperator.NE => filterBuilder.Ne(func, fhirParam.Value),
                FhirOperator.GT => filterBuilder.Gt(func, fhirParam.Value),
                FhirOperator.LT => filterBuilder.Lt(func, fhirParam.Value),
                FhirOperator.GE => filterBuilder.Gte(func, fhirParam.Value),
                FhirOperator.LE => filterBuilder.Lte(func, fhirParam.Value),
                FhirOperator.SA => filterBuilder.Gt(func, fhirParam.Value),
                FhirOperator.EB => filterBuilder.Lt(func, fhirParam.Value),
                _ => throw new InvalidDataException($"Invalid operator: {fhirParam.Operator}")
            });

    public static FilterDefinition<TResult> GetFhirDateOnlyFilterDefinition<TResult>(
        this FilterDefinitionBuilder<TResult> filterBuilder,
        Expression<Func<TResult, DateTime>> func,
        FhirQuery<DateTime> fhirParam)
    {
        switch (fhirParam.Operator)
        {
            case FhirOperator.EQ:
                return filterBuilder.Gte(func, fhirParam.Value) & 
                    filterBuilder.Lte(func, fhirParam.Value.AddHours(23).AddMinutes(59));
            case FhirOperator.NE:
                return filterBuilder.Lt(func, fhirParam.Value) |
                    filterBuilder.Gt(func, fhirParam.Value.AddHours(23).AddMinutes(59));
            default:
                return filterBuilder.GetFhirFilterDefinition(func, fhirParam);
        };
    }
}
