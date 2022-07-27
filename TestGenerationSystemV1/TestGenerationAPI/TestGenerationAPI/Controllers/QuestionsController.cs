using Microsoft.AspNetCore.Mvc;
using TestGenerationAPI.Entity;

namespace TestGenerationAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly QuestionHandlingService _questionHandlingService;

        public QuestionsController(QuestionHandlingService questionHandlingService)
        {
            _questionHandlingService = questionHandlingService;
        }


        [HttpGet("GetAllQuestions")]
        public ActionResult<List<QuestionModel>> Get()
        {
            var questions = _questionHandlingService.RetrieveAllQuestions();

            if (questions == null)
            {
                return NotFound();
            }

            return questions;
        }

        [HttpGet]
        public ActionResult<QuestionModel> GetQuestion(string id)
        {
            var question = _questionHandlingService.RetrieveQuestion(id);

            if(question == null)
            {
                return NotFound(); 
            }
            Console.WriteLine("hi");
            return question;
        }

        [HttpPost]
        public ActionResult<QuestionModel> PostQuestion([FromForm] QuestionModel model)
        {
            model.DateCreated = DateTime.Now;
            model.LastModified = DateTime.Now;
            _questionHandlingService.InsertQuestion(model);
            return NoContent();
        }

        [HttpPut]
        public ActionResult<QuestionModel> UpdateQuestion(string id, [FromForm] QuestionModel model)
        {   
            model.LastModified = DateTime.Now;
            model.QuestionId = id;
            var ModelId = _questionHandlingService.RetrieveQuestion(id).QuestionId;
            _questionHandlingService.UpdateQuestion(ModelId, model);
            return NoContent();
        }
    }
}
