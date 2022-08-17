
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestGenerationAPI.Entity;
using TestGenerationAPI.services;


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

        [HttpGet("GetQuestions")]
        public ActionResult<List<QuestionModel>> GetQuestions(int numOfQuestions)
        {
            var questions = _questionHandlingService.RetrieveAllQuestions();
            Random random = new Random();

            if (questions == null)
            {
                return NotFound();
            }
            int len = questions.Count;

            for(int i = 0; i < len - numOfQuestions; i++)
            {
                int num = random.Next() % questions.Count;
                questions.RemoveAt(num);
            }

            return questions;
        }

        [HttpGet("GetQuestion")]
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

        [HttpPost("CreateQuestion")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public ActionResult<QuestionModel> PostQuestion(QuestionModel model)
        {
            model.DateCreated = DateTime.Now;
            model.LastModified = DateTime.Now;
            _questionHandlingService.InsertQuestion(model);
            return NoContent();
        }

        [HttpPut("UpdateQuestion")]
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
