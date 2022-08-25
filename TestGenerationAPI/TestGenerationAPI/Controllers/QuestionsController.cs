
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestGenerationAPI.Entity;
using TestGenerationAPI.services;


namespace TestGenerationAPI.Controllers
{
    public class FilterModel
    {
        public int numOfQuestions { get; set; }
        public RoleTypes role { get; set; }

        public DifficultyLevels difficulty { get; set; }
        public string skill { get; set; } = null!;
    }
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
        public ActionResult<List<GetQuestionModel>> Get()
        {
            var questions = _questionHandlingService.RetrieveAllQuestions();

            if (questions == null)
            {
                return NotFound();
            }

            return questions;
        }

        [HttpPost("GetQuestions")]
        public ActionResult<List<GetQuestionModel>> GetQuestions(FilterModel model)
        {
            var questions = _questionHandlingService.RetrieveAllQuestions();
            

            if (questions == null)
            {
                return NotFound();
            }
           
            var selectedQuestions = questions.Where(x => x.Skill == model.skill && x.RoleType == model.role && x.DifficultyLevel == model.difficulty).Take(model.numOfQuestions).ToList();
            return selectedQuestions;
        }

        [HttpGet("GetQuestion")]
        public ActionResult<GetQuestionModel> GetQuestion(string id)
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public ActionResult<PostQuestionModel> PostQuestion(PostQuestionModel model)
        {
            model.DateCreated = DateTime.Now;
            model.LastModified = DateTime.Now;
            _questionHandlingService.InsertQuestion(model);
            return NoContent();
        }

        [HttpPut("UpdateQuestion")]
        public ActionResult<PostQuestionModel> UpdateQuestion(string id, [FromForm] PostQuestionModel model)
        {   
            model.LastModified = DateTime.Now;
            model.QuestionId = id;
            var ModelId = _questionHandlingService.RetrieveQuestion(id).QuestionId;
            _questionHandlingService.UpdateQuestion(ModelId, model);
            return NoContent();
        }
    }
}
