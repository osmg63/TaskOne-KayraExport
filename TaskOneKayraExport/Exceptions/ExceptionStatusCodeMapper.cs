using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;

namespace TaskOneKayraExport.Exceptions
{
    public static class ExceptionStatusCodeMapper
    {
        public static int GetStatusCode(Exception ex) =>
           ex switch
           {
               BadRequestException => StatusCodes.Status400BadRequest,
               NotFoundException => StatusCodes.Status404NotFound,
               ValidationException => StatusCodes.Status422UnprocessableEntity,
               UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
               ForbiddenException => StatusCodes.Status403Forbidden,
               TimeoutException => StatusCodes.Status408RequestTimeout,
               NotImplementedException => StatusCodes.Status501NotImplemented,
               _ => StatusCodes.Status500InternalServerError
           };
    }
}
