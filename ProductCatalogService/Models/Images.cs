using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductCatalogService.Models
{
    public class Images
    {
        private static string URL;
        /// <summary>
        /// Returns a URL of an Image depending on the given string. If there is no results
        /// then the method returns a random Image
        /// </summary>
        /// <param name="name"></param>
        /// <returns>String URL of a web Image server</returns>
        public static string ByNameOrDefault(string name)
        {
            try
            {
                string ApiUrl = "https://api.unsplash.com/search/photos?query=" + name + "&client_id=RR8zTp6LTR2TmVYodb76GyD0Z5SaXaGUoYxX3lr4TJg";
                var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
                var content = string.Empty;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            content = sr.ReadToEnd();
                        }
                    }
                }
                JObject objs = JObject.Parse(content);
                int c = (Int32)objs["total"];
                if (c >= 1)
                {
                    URL = objs["results"][0]["urls"]["small"].ToString();
                }
                else
                {
                    URL = ByNameOrDefault("random");
                }

                return URL;
            }
            catch (WebException e)
            {
                return "https://images.unsplash.com/photo-1581338819396-3153302d7cd0?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=400&fit=max&ixid=eyJhcHBfaWQiOjExNjU4M30";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
