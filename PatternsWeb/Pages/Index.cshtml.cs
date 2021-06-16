using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PatternsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternsWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Algorythms PatternField { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PatternField = new Algorythms();
        }

        public string GetSquareImage(int row,int col)
        {
            if(PatternField == null)
            {
                return string.Empty;
            }

            var Box = PatternField.GetBoxValue(row, col);

            switch (Box)
            {
                case FillStatusEnum.BoxFilled:
                    return "<img src=\"/Images/FillBox.png\"/>";
                case FillStatusEnum.BoxEmpty:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }

        public void OnPostCheckers()
        {
            PatternField.FillCheckersPattern();

            RedirectToPage();
        }
    }
}
