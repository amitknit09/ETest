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
        
        [HttpGet]
        public ActionResult<QuestionModel> Get(string id)
        {
            var questions = _questionHandlingService.RetrieveQuestion(id);

            if(questions == null)
            {
                return NotFound(); 
            }
            Console.WriteLine("hi");
            return questions;
        }

        [HttpPost]
        public ActionResult<QuestionModel> Post([FromForm] QuestionModel model)
        {
            model.DateCreated = DateTime.Now;
            model.LastModified = DateTime.Now;
            _questionHandlingService.InsertQuestion(model);
            return NoContent();
        }

        [HttpPut]
        public ActionResult<QuestionModel> Put(string id, [FromForm] QuestionModel model)
        {
            
            model.LastModified = DateTime.Now;
            model.QuestionId = id;
            var ModelId = _questionHandlingService.RetrieveQuestion(id).QuestionId;
            _questionHandlingService.UpdateQuestion(ModelId, model);
            return NoContent();
        }
    }
}
