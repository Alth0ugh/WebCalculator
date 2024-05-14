using Calculator;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WebCalculator.DatabaseConnections;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculator _calculator;
        private HistoryDatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger, ICalculator calculator, HistoryDatabaseContext historyDatabaseContext)
        {
            _logger = logger;
            _calculator = calculator;
            _databaseContext = historyDatabaseContext;
        }

        public IActionResult Index()
        {
            return View(new CalculatorViewModel() { History = _databaseContext.GetHistory() });
        }

        [HttpPost]
        public IActionResult Add([FromBody] NumberUpdateViewModel model)
        {
            var calculatorModel = new CalculatorModel(model.Display, _calculator, _logger);
            calculatorModel.AddDigit(model.Number);


            return Json(calculatorModel);
        }

        [HttpPost]
        public IActionResult Decimal([FromBody] CalculatorViewModel model)
        {
            var calculatorModel = new CalculatorModel(model.Display, _calculator, _logger);
            calculatorModel.AddDecimal();

            return Json(calculatorModel);
        }


        [HttpPost]
        public IActionResult Clear([FromBody] CalculatorViewModel model)
        {
            var calculatorModel = new CalculatorModel(model.Display, _calculator, _logger);
            calculatorModel.Clear();
            
            return Json(calculatorModel);
        }

        [HttpPost]
        public IActionResult Operator([FromBody] OperatorUpdateViewModel model)
        {
            var calculatorModel = new CalculatorModel(model.Display, _calculator, _logger);
            calculatorModel.AddOperator(model.Operator);

            return Json(calculatorModel);
        }

        [HttpPost]
        public IActionResult Equals([FromBody] ComputeViewModel model)
        {
            var calculatorModel = new CalculatorModel(model.Display, _calculator, _logger);
            calculatorModel.Whole = model.Whole;

            try
            {
                calculatorModel.Compute();
                var expression = new ExpressionModel();
                expression.Expression = model.Display;
                expression.Result = float.Parse(calculatorModel.Display);
                _databaseContext.Add(expression);
                _databaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { success = false, message = ex.Message });
            }

            var indexViewModel = new CalculatorViewModel()
            {
                Display = calculatorModel.Display,
                History = _databaseContext.GetHistory()
            };

            return Json(indexViewModel);
        }
    }
}