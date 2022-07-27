using Microsoft.AspNetCore.Mvc;
using TestGenerationAPI.Entity;

namespace TestGenerationAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class TestPaperController : Controller
    {

        private TestPaperHandlingService _testPaperHandlingService;

        private TestPaperQuestionAssociationHandlingService _testPaperQuestionAssociationHandling;

        public TestPaperController(TestPaperHandlingService testPaperHandlingService,
            TestPaperQuestionAssociationHandlingService testPaperQuestionAssociationHandling)
        {
            _testPaperHandlingService = testPaperHandlingService;
            _testPaperQuestionAssociationHandling = testPaperQuestionAssociationHandling;
        }

        [HttpGet("GetAllTest")]
        public ActionResult<List<TestPaperModel>> GetAllTestPaper()
        {
            var tests = _testPaperHandlingService.RetrieveAllTest();

            if(tests == null)
            {
                return NotFound();

            }

            return tests;
        }
        [HttpGet]
        public ActionResult<TestPaperModel> GetTestPaper(string id)
        {
            var test = _testPaperHandlingService.RetrieveTestPaper(id);
            if(test == null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public ActionResult PostTestPaper([FromForm] TestPaperModel model, [FromForm] List<string> questionIds)
        {
            model.DateCreated = DateTime.Now;
            model.LastModified = DateTime.Now;
            _testPaperHandlingService.SaveTestPaper(model);
            _testPaperQuestionAssociationHandling
                .AddEntry(new TestPaperQuestionAssociation 
                            { 
                                TestPaperId = model.TestPaperId,
                                QuestionIds = questionIds 
                            });

            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateTestPaper([FromForm] TestPaperModel model, [FromForm] List<string> questionIds)
        {
            model.LastModified = DateTime.Now;
            if (model.IsActive == false) model.DeactivatedOn = DateTime.Now;
            _testPaperHandlingService.UpdateTestPaper(model);
            _testPaperQuestionAssociationHandling
                .UpdateEntry(model.TestPaperId, new TestPaperQuestionAssociation 
                                                { 
                                                    TestPaperId = model.TestPaperId,
                                                    QuestionIds = questionIds 
                                                });
            return NoContent();
        }
    }
}
