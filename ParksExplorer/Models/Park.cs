using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ParksExplorer.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required(ErrorMessage = "Please enter a name when creating an entry.")]
    public string Name { get; set; }
    public string Classification { get; set; }
    public string Location { get; set; }
    public string MajorLandmarks { get; set; }
    public string Activities { get; set;}
    public string Facilities { get; set; }
    public int YearFounded { get; set; }

    public static List<Park> GetParks()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Park> parkList = JsonConvert.DeserializeObject<List<Park>>(jsonResponse.ToString());

      return parkList;
    }

    public static Park GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Park park = JsonConvert.DeserializeObject<Park>(jsonResponse.ToString());

      return park;
    }

    public static void Post(Park park)
    {
      string jsonPark = JsonConvert.SerializeObject(park);
      ApiHelper.Post(jsonPark);
    }

    public static void Put(Park park)
    {
      string jsonPark = JsonConvert.SerializeObject(park);
      ApiHelper.Put(park.ParkId, jsonPark);
    }

    public static void Delete (int id)
    {
      ApiHelper.Delete(id);
    }

// left over from Thursday attempts at pagination
    // public static List<Park> GetParks(int page)
    // {
    //   var apiCallTask = ApiHelper.GetParks(page);
    //   var result = apiCallTask.Result;

    //   JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    //   List<Park> parkList = JsonConvert.DeserializeObject<List<Park>>(jsonResponse.ToString());

    //   return parkList;
    // }
  }
}