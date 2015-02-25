using BLL.Interface.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// Represents the entity of TestListQueryService that provides methods of accessing TestList which is situated on SharePoint server.
    /// Access to TestList is produced by using SharePoint REST API and System.Net.WebClient.
    /// </summary>
    public class TestListQueryService: ITestListQueryService
    {
        private string getTestListQuery = "/_api/web/Lists/GetByTitle('TestList')/Items?$Select=Title,Experience";
        private string host;
        private string userName;
        private WebClient client;

        /// <summary>
        /// Host url.
        /// </summary>
        public string Host
        {
            get
            {
                return this.host;
            }
        }

        /// <summary>
        /// User name.
        /// </summary>
        public string UserName
        {
            get
            {
                return this.userName;
            }
        }

        private void Initilize(string password)
        {
            this.client = new WebClient { Credentials = new NetworkCredential(this.userName, password) };
            this.client.Headers.Add(HttpRequestHeader.Accept, "application/json; odata=verbose");
        }

        /// <summary>
        /// Initializes a new instance of the BLL.Services.TestListQueryService class that has specified host url, user name and password for SharePoint server.
        /// </summary>
        /// <param name="host">Host url used by web client.</param>
        /// <param name="userName">User name passed to web client credentials.</param>
        /// <param name="password">Password passed to web client credentials.</param>
        /// <exception cref="System.ArgumentException">Host is null, empty, or consists only of white-space characters.</exception>
        /// <exception cref="System.ArgumentException">User is null, empty, or consists only of white-space characters.</exception>
        /// <exception cref="System.ArgumentException">Password is null, empty, or consists only of white-space characters.</exception>
        public TestListQueryService(string host, string userName, string password)
        {
            if (String.IsNullOrWhiteSpace(host))
            {
                throw new System.ArgumentException("Host url is null, empty, or consists only of white-space characters.");
            }
            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new System.ArgumentException("User name is null, empty, or consists only of white-space characters.");
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new System.ArgumentException("Password name is null, empty, or consists only of white-space characters.");
            }
            this.host = host;
            this.userName = userName;
            this.Initilize(password);
        }

        /// <summary>
        /// Downloads TestList from SharePoint server as json.
        /// </summary>
        /// <returns>TestList represented as json.</returns>
        public string GetTestList()
        {
            var result = string.Empty;
            result = this.client.DownloadString(this.host + getTestListQuery);
            return result;
        }

        /// <summary>
        /// Downloads TestList from SharePoint server as json. This method does not block the calling thred.
        /// </summary>
        /// <returns>TestList represented as json.</returns>
        public async Task<string> GetTestListAsync()
        {
            var result = string.Empty;
            result = await this.client.DownloadStringTaskAsync(new Uri(this.host + getTestListQuery));
            return result;
        }
    }
}
