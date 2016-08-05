// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppNetA.Controllers
{
    class ClassificationActivity
    {
        public static int isWeekend(DateTime dtToValidate)
        {
            if (dtToValidate.DayOfWeek == DayOfWeek.Sunday || dtToValidate.DayOfWeek == DayOfWeek.Saturday)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static String Classify(Models.PredictModel model)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"SquareID", "CountryCode", "SMSInActivity", "SMSOutActivity", "CallInActivity", "CallOutActivity", "InternetTrafficActivity", "day", "hour", "DayOfWeek", "Weekday"},
                                Values = new string[,] {  { model.squareID.ToString(),model.countryCode.ToString(), model.smsInActivity.ToString(), model.smsOutActivity.ToString(), model.callInActivity.ToString(), model.callOutActivity.ToString(), model.internetTrafficActivity.ToString(), model.date.Day.ToString(), model.date.Hour.ToString(), ((int)model.date.DayOfWeek).ToString(), isWeekend(model.date).ToString() }  }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "s8MYd8qKR47LhrTvmF1vTh/a1VhhtyAE9pBN0n/hRhlXG88hCHgO8YnlgMMOl7N118XicbEWBCmeHxiTiQpxDA=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/27283ce47c2b45d4af792fcf22e0cedd/services/6ee781edc6fb402d9185a0462e380d03/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = client.PostAsJsonAsync("", scoreRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonDoc = response.Content.ReadAsStringAsync().Result;
                    var ResponseBody = JsonConvert.DeserializeObject<RRSResponse>(jsonDoc);
                    return ResponseBody.Results.output1.value.Values[0][11]+"-"+ ResponseBody.Results.output1.value.Values[0][12];
                }
                else
                {
                    return "Error";
                }
            }
        }

            #region Helper
        private class RRSResponse
        {
            public Results Results { get; set; }
        }

        private class Results
        {
            public Output1 output1 { get; set; }
        }

        private class Output1
        {
            public string type { get; set; }
            public Value value { get; set; }
        }

        private class Value
        {
            public string[] ColumnNames { get; set; }
            public string[] ColumnTypes { get; set; }
            public string[][] Values { get; set; }
        }
        #endregion
    }

}
