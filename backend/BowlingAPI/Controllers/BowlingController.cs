using BowlingAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BowlingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private IBowlingRepository _bowlingRepository;
        public BowlingController(IBowlingRepository temp)
        {
            _bowlingRepository = temp;
        }


        [HttpGet]
        public IEnumerable<object> Get()
        {
            var bowlerData = from Bowlers in _bowlingRepository.Bowlers
                             join Teams in _bowlingRepository.Teams
                             on Bowlers.TeamId equals Teams.TeamId
                             where Teams.TeamName == "Marlins" || Teams.TeamName == "Sharks"
                             select new
                             {
                                 BowlerId = Bowlers.BowlerId,
                                 BowlerLastName = Bowlers.BowlerLastName,
                                 BowlerFirstName = Bowlers.BowlerFirstName,
                                 BowlerMiddleInit = Bowlers.BowlerMiddleInit,
                                 BowlerAddress =    Bowlers.BowlerAddress,
                                 BowlerCity = Bowlers.BowlerCity,
                                 BowlerState = Bowlers.BowlerState,
                                 BowlerZip = Bowlers.BowlerZip,
                                 BowlerPhoneNumber = Bowlers.BowlerPhoneNumber,
                                 TeamName = Teams.TeamName
                             };

            return bowlerData.ToList();
        }
    }
}
