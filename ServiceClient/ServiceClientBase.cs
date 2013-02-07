using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BoothLeads.ServiceClient
{
    public abstract class ServiceClientBase
    {

        protected int GetErrorCode
        {
            get
            {
                return -1;
            }
        }

        protected int GetSuccessCode
        {
            get
            {
                return 1;
            }

        }

        protected string grant_type
        {
            get
            {
                return "password";
            }
        }

        protected string client_id
        {
            get
            {
                return "3MVG9Nvmjd9lcjRmgXI5Kypycu6m1Q1k1rGrW5gcKWzyYTAPsuGEU6YvI6ITL4Wt3AZoFktNmadpNLXlExiLO";
            }
        }

        protected string client_secret
        {
            get
            {
                return "4633981559206472014";
            }
        }

        public string ParseJSON(string data)
        {
            string json = string.Empty;
            json = data.Substring(data.IndexOf(":") + 1);
            json = json.Substring(0, json.LastIndexOf("}"));
            return json;
        }
    }
}
