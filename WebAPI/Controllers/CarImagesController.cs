using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm]IFormFile file, [FromForm]CarImage carImage)
        {
            var result= _carImageService.Update(carImage, file);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("getall")]
        public IActionResult GetAll(CarImage carImage)
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = _carImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }


    }
}
