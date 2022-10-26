using WebApi_Passenger.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI_Passenger.Models;
using WebAPI_Passenger.Services;
using WebAPI_Passenger.Util;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI_Passenger.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase {

        private readonly PassengerServices _passengerService;
       

        public PassengerController(PassengerServices passengerService) {

            _passengerService = passengerService;
           
        }

       [HttpGet]
        public ActionResult<List<Passenger>> Get() => _passengerService.Get();

        [HttpGet("Cpf", Name = "GetPassenger")]
        public ActionResult<Passenger> Get(string cpf) {
            var passenger = _passengerService.Get(cpf);
            if (passenger == null) {
                return NotFound();
            } else {
                return Ok(passenger);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Passenger>> Create(Passenger passenger) {

            passenger.Address =new AddressService().MainAsync(passenger.Address.ZipCode).Result;

            _passengerService.Create(passenger);

            return CreatedAtRoute("GetPassenger", new { cpf = passenger.Cpf.ToString() }, passenger);
            
        }

        [HttpPut]
        public ActionResult<Passenger> Update(string cpf, Passenger passengerIn) {

            var passenger = _passengerService.Get(cpf);
            if (passenger == null) {
                return NotFound();
            } else {
                _passengerService.Update(cpf, passengerIn);
                passenger = _passengerService.Get(cpf);
            }
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(string cpf) {

            var passenger = _passengerService.Get(cpf);
            if (passenger == null) {
                return NotFound();
            } else {
                _passengerService.Remove(passenger);
            }
            return NoContent();


        }


    }
}
