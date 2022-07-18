using Newtonsoft.Json;
using System.Collections.Generic;


namespace Domain.Model
{
    public class BasicStarShipModel
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
    public class StarShipModel
    {
        public StarShipDetailModel Properties { get; set; }
        public string Description { get; set; }
      
    }
    public class StarShipDetailModel :BasicStarShipModel
    {
        public string model { get; set; }  
        public string manufacturer { get; set; }  
        public string cost_in_credits { get; set; }  
        public string length { get; set; }  
        public string max_atmosphering_speed { get; set; } 
        public string crew { get; set; } 
        public string passengers { get; set; }  
        public string cargo_capacity { get; set; }  
        public string consumables { get; set; } 
        public string hyperdrive_rating { get; set; }  
        public string MGLT { get; set; } 
        public string starship_class { get; set; } 
        public string[] pilots { get; set; } 
        public string[] films { get; set; } 
        public string created { get; set; }  
        public string edited { get; set; }  

    }
    public class BasicStarShipResponseModel
    {
        public string Name { get; set; }
        public int Stops { get; set; }
    }
    public class StarShipGetResponseModel : StarShipBaseResponseModel
    {
        [JsonProperty("result")]
        public StarShipModel Result { get; set; }
    }
    public class StarShipListingsGetResponseModel : StarShipBaseResponseModel
    {
        [JsonProperty("results")]
        public IEnumerable<BasicStarShipModel> Results { get; set; }
    }
    public class StarShipBaseResponseModel
    {

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
