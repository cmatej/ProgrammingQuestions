using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProgrammingQuestions.ErrorHandler
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        public string poruka = System.Diagnostics.Trace.CorrelationManager.ActivityId.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}