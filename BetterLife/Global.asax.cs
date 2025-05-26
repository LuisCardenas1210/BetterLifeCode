using System;
using System.Collections.Generic;
using System.Linq;
namespace BetterLife
{
using System.Web.UI;
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e) 		
		{
            // Mapear jQuery para validaciones unobtrusive
            ScriptResourceDefinition jqueryDef = new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-3.6.0.min.js",  // Asegúrate que este archivo existe
                DebugPath = "~/Scripts/jquery-3.6.0.js",
                CdnPath = "https://code.jquery.com/jquery-3.6.0.min.js",
                CdnDebugPath = "https://code.jquery.com/jquery-3.6.0.js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            };

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jqueryDef);
        }
		
		protected void Session_Start(object sender, EventArgs e) 
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_Error(object sender, EventArgs e) 
		{

		}

		protected void Session_End(object sender, EventArgs e) 
		{

		}

		protected void Application_End(object sender, EventArgs e) 
		{

		}
	}
}