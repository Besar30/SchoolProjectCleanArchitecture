using Microsoft.AspNetCore.Mvc;
using SchoolProject.Shared.Absractions;

namespace SchoolProject.Api.Const
{
    public static class ResultExtention
    {
        public static ObjectResult ToProblem(this Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException("cannot convert success result to a problem");
            }
            var problem = Results.Problem(statusCode: result.error.StatusCode);
            var problemDetails = problem.GetType().GetProperty(nameof(ProblemDetails))!.GetValue(problem) as ProblemDetails;

            problemDetails!.Extensions = new Dictionary<string, object?>
            {
                        {
                            "errors",new[]
                            {
                                result.error.Code,
                                result.error.Discription
                            }
                        }
            };
            return new ObjectResult(problemDetails);
        }
    }
}
