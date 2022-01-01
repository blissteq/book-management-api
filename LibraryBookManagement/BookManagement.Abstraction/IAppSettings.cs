using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Abstraction
{
    public interface IAppSettings
    {
        string CommandServerName { get; set; }
        string CommandDatabaseName { get; set; }
        string QueryServerName { get; set; }
        string QueryDatabaseName { get; set; }
        string ProjectsUrl { get; set; }
        string OrganisationUrl { get; set; }
        string UserManagement { get; set; }
        string DocumentsUrl { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public string ProjectsUrl { get; set; }

        public string CommandServerName { get; set; }
        public string CommandDatabaseName { get; set; }
        public string QueryServerName { get; set; }
        public string QueryDatabaseName { get; set; }
        public string OrganisationUrl { get; set; }
        public string UserManagement { get; set; }
        public string DocumentsUrl { get; set; }
    }
}
