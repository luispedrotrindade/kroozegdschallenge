using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;

namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public class WebTest
    {
        public JObject GetAllMovies()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the films object

            string result = SubmitSwapiAPI("films", "GET", "application/json");

            return JObject.Parse(result);
        }

        public string GetDirector()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the name of person that directed the most star wars movies, based on the films object return
            string result = SubmitSwapiAPI("films", "GET", "application/json");

            JObject json = JObject.Parse(result);

            string director = "";

            List<Director> directors = new List<Director>();

            directors.Add(json["results"][0]["director"].ToString(), 1);

            foreach (JToken value in json["results"])
            {
                if (!directors.Any(x => x.Name == value["director"].ToString()))
                {
                    directors.Add(new Director {Name=value["director"].ToString(), Count = 1});
                }
                else
                {
                    directors.FirstOrDefault(x => x.Name == value["director"].ToString()).Count++;
                }
            }


            return directors.Where(x => x.Count == directors.Max()).First().Name;
        }



        public static string SubmitSwapiAPI(string request, string httpMethod, string contentType)
        {
            string remoteUrl = "https://swapi.co/api/" + request;

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);

            httpRequest.Method = httpMethod;
            httpRequest.ContentType = contentType;


            // Get the response from remote server
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream responseStream = httpWebResponse.GetResponseStream();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            using (StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.Append(line);
                }
            }

            string serverResponse = sb.ToString();

            return serverResponse;

        }
    }

public class Director {
public string Name {get; set;}
public int Count {get;set;}

}

}
