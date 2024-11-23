using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Services.Choices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController(IChoiceServices choiceServices) : ControllerBase
    {
        private readonly IChoiceServices choiceServices = choiceServices;
        [HttpPost]
        public ApiResponseDto<int> Add(ChoiceCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                return choiceServices.Add(dto); 
            }
            return new(400,ModelState);
        }
        [HttpDelete]
        public ApiResponseDto<int> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return choiceServices.Delete(id); 
            }
            return new(400, ModelState);
        }
        [HttpPut]
        public ApiResponseDto<int> Update(int id,ChoiceUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                return choiceServices.Update(id,dto); 
            }
            return new(400, ModelState);
        }
    }
}
