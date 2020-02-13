using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EFSample.Filters
{
    public class DurationHeaderFilter : IActionFilter
    {
        private Stopwatch stopWatch;
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var started = DateTime.Now;
            stopWatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //var duration = DateTime.Now.Subtract(started).TotalMilliseconds;
            stopWatch.Stop();

            //HttpContext.Response.Headers.Add("action-duration", duration+"ms");
            context.HttpContext.Response.Headers.Add(
                "action-duration",
                stopWatch.ElapsedMilliseconds.ToString("#,0") + "ms"
               );
        }
    }
}
