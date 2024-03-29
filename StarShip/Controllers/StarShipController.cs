﻿using Domain.Helpers;
using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarShip.Controllers
{
    [Route("api/[controller]")]
    public class StarShipController : BaseController
    {
     
        private readonly ILogger<StarShipController> _logger;
        private IStartShipService _startShipService;
        public StarShipController(ILogger<StarShipController> logger,
            IStartShipService startShipService)
        {
            _logger = logger;
            _startShipService=startShipService;
        }

        /// <summary>
        /// Get StarShips.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="paginationReqDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<BasicStarShipResponse> GetAsync([FromQuery] int distance,[FromQuery] PaginationReqDTO paginationReqDTO)
        {
            List<BasicStarShip> response= new List<BasicStarShip>();
            var starShips= await _startShipService.GetStarShipInfo(paginationReqDTO.Page,paginationReqDTO.Limit);
            foreach(var shipment in starShips.Results)
            {
                var starShipInfo = await _startShipService.GetStarShipInfoById(shipment.Uid);
                if(starShipInfo != null)
                {
                   var stops=Utilities.CalculateStops(starShipInfo, distance);
                    response.Add(new BasicStarShip { Name = shipment.Name, Stops = stops });
                }
            }
            BasicStarShipResponse basicStarShipResponse=new BasicStarShipResponse();
            basicStarShipResponse.TotalRecords = starShips.TotalRecords;
            basicStarShipResponse.BasicStarShips = response;
            return basicStarShipResponse;
        }
        /// <summary>
        /// Get StarShip By Id.
        /// </summary>
        /// <param name="starShipId"></param>
        /// <returns></returns>
        [HttpGet("{starShipId}")]
        public async Task<StarShipModel> GetAsync([FromRoute] string starShipId)
        {
            return await _startShipService.GetStarShipInfoById(starShipId);
        }
    }
}
