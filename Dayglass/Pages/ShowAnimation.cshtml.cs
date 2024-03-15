using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Dayglass.Pages
{
    public class ShowAnimationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public TimeSpan DayStart { get; set; }

        [BindProperty(SupportsGet = true)]
        public TimeSpan DayEnd { get; set; }

        public double DayProgress { get; set; }

        public void OnGet()
        {
            var now = DateTime.Now.TimeOfDay;
            var totalDayLength = (DayEnd - DayStart).TotalMinutes;
            var elapsedTimeSinceStart = (now - DayStart).TotalMinutes;
            DayProgress = elapsedTimeSinceStart / totalDayLength * 100;
            DayProgress = Math.Max(0, Math.Min(100, DayProgress)); // Clamp between 0 and 100
            DayProgress = (int)Math.Round(DayProgress); // Round DayProgress to the nearest whole number and convert to integer
        }
    }
}
