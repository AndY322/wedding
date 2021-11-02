using AutoMapper;
using DomainModel.DTO;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Repository.Interfaces;

namespace WebApplication.Controllers
{
    [Route("survey")]
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;
        private readonly IAlcoholService _alcoholService;
        private readonly IMapper _mapper;
        private readonly IOvernightStayLookupService _overnightStayLookupService;
        public SurveyController(ISurveyService surveyService, IMapper mapper, IAlcoholService alcoholService, IOvernightStayLookupService overnightStayLookupService)
        {
            _surveyService = surveyService;
            _mapper = mapper;
            _alcoholService = alcoholService;
            _overnightStayLookupService = overnightStayLookupService;
        }
        
        [HttpGet]
        [Route("get")]
        public ActionResult GetSurvey(int accessCode)
        {
            var survey = _surveyService.GetSurveyByAccessCode(accessCode);
            if (survey == null)
            {
                return RedirectToAction("Index", "Home", new { accessMessageError = "Неверный код"});
            }

            var surveyDTO = _mapper.Map<Survey, SurveyDTO>(survey);
            surveyDTO.Alcohols = _alcoholService.GetAll();
            surveyDTO.OvernightStayLookups = _overnightStayLookupService.GetAll();
            
            return View("Survey", surveyDTO);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult SaveSurvey(SurveyDTO surveyDTO)
        {
            var survey = _surveyService.GetById(surveyDTO.SurveyId);
            survey = _mapper.Map(surveyDTO, survey);
            _surveyService.Save(survey);
            return RedirectToAction("Index", "Home");
        }
    }
}