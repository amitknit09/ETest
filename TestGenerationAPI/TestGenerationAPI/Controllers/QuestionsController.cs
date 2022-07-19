using Microsoft.AspNetCore.Mvc;

namespace TestGenerationAPI.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly QuestionHandlingService _questionHandlingService;

        public QuestionsController(QuestionHandlingService questionHandlingService)
        {
            _questionHandlingService = questionHandlingService;
        }
        
        [HttpGet]
        public ActionResult<QuestionModel> Get(string id)
        {
            var questions = _questionHandlingService.RetrieveQuestion(id);

            if(questions == null)
            {
                return NotFound(); 
            }

            return questions;
        }
    }
}
