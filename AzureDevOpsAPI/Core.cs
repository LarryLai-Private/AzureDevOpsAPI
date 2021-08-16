using System;
using System.Text;

using Newtonsoft.Json;
using RestSharp;

namespace AzureDevOpsAPI
{
    public class Core
    {
        public class Projects
        {
            /// <summary>
            /// Represents a shallow reference to a TeamProject.
            /// https://docs.microsoft.com/en-us/rest/api/azure/devops/core/projects/list?view=azure-devops-rest-6.0#teamprojectreference
            /// </summary>
            public class TeamProjectReference
            {
                ///// <summary>
                ///// Project abbreviation.
                ///// </summary>
                //public string abbreviation { set; get; }
                ///// <summary>
                ///// Url to default team identity image.
                ///// </summary>
                //public string defaultTeamImageUrl { set; get; }


                /// <summary>
                /// Project identifier.
                /// </summary>
                public string id { set; get; }
                /// <summary>
                /// Project name.
                /// </summary>
                public string name { set; get; }
                /// <summary>
                /// The project's description (if any).
                /// </summary>
                public string description { set; get; }
                /// <summary>
                /// Url to the full version of the object.
                /// </summary>
                public string url { set; get; }

                /// <summary>
                /// Project last update time.
                /// </summary>
                public string lastUpdateTime { set; get; }
                /// <summary>
                /// Project revision.
                /// </summary>
                public int revision { set; get; }
                /// <summary>
                /// Project state.
                /// https://docs.microsoft.com/en-us/rest/api/azure/devops/core/projects/list?view=azure-devops-rest-6.0#projectstate
                /// </summary>
                public string state { set; get; }
                /// <summary>
                /// Project visibility.
                /// https://docs.microsoft.com/en-us/rest/api/azure/devops/core/projects/list?view=azure-devops-rest-6.0#projectvisibility
                /// </summary>
                public string visibility { set; get; }
            }
            public class Result
            {
                public int count { set; get; }
                public TeamProjectReference[] value { set; get; }
            }
            static public Result OrganizationProjectsList(string Organization, string Token)
            {
                Result result;

                RestRequest restRequest = new RestRequest("/_apis/projects?api-version=6.0");
                string pat = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", Token)));
                restRequest.AddHeader("Authorization", "Basic " + pat);
                restRequest.Method = Method.GET;

                RestClient restClient = new RestClient($"https://dev.azure.com/{Organization}");
                var response = restClient.Execute(restRequest);

                result = JsonConvert.DeserializeObject<Result>(response.Content);

                return result;
            }
        }
    }
}
