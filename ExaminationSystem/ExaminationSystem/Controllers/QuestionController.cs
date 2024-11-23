using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Question;
using ExaminationSystem.Services.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController(IQuestionServices questionServices) : ControllerBase
    {
        private readonly IQuestionServices questionServices = questionServices;
        [HttpPost]
        public ApiResponseDto<int> Add(QuestionCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = questionServices.Add(dto);
                return result;
            }
            return new(400, ModelState);
        }
        [HttpPut]
        public ApiResponseDto<int> Update(int id,QuestionUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = questionServices.Update(id,dto);
                return result;
            }
            return new(400, ModelState);
        }
        [HttpDelete]
        public ApiResponseDto<int> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = questionServices.Delete(id);
                return result;
            }
            return new(400, ModelState);
        }

    }
}
