using FluentValidation;

namespace MyFirstNetCoreAPI.WebAPI.Filters;

public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        T? dataToValidate = context.GetArgument<T>(0);
        IValidator<T>? validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

        if (validator is not null)
        {
            var validatorResult = validator.Validate(dataToValidate);
            if (!validatorResult.IsValid)
            {
                return Results.ValidationProblem(validatorResult.ToDictionary());
            }
        }

        return await next.Invoke(context);
    }
}
