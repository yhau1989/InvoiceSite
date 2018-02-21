﻿using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SiteInvoicer.Models;
using System.Web.Security;

namespace SiteInvoicer.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if ((Email.Text.Length > 0) && (Password.Text.Length > 0))
                {
                    FormsAuthentication.RedirectFromLoginPage(Email.Text, false);
                    var returnUrl = "~/";
                    Response.Redirect(returnUrl);
                }
                else
                {
                    //Session.Remove("logon");
                    FailureText.Text = "llenar los campos";
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}