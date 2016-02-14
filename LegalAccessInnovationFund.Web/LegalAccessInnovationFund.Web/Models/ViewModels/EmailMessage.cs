using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models.ViewModels
{
    public class EmailMessage
    {
        public string MessageToAdministratorOnSubmitApplication
        {
            get
            {
                return @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional //EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd""><html xmlns=""http://www.w3.org/1999/xhtml""><head>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <!--[if !mso]><!--><meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" /><!--<![endif]-->
    <meta name=""viewport"" content=""width=device-width"" />
    <title> </title>
    <style type=""text/css"">
.wrapper a:hover {
  text-decoration: none !important;
}
.btn a:hover,
.footer__links a:hover {
  opacity: 0.8;
}
.wrapper .footer__share-button:hover {
  color: #ffffff !important;
  opacity: 0.8;
}
a[x-apple-data-detectors] {
  color: inherit !important;
  text-decoration: none !important;
  font-size: inherit !important;
  font-family: inherit !important;
  font-weight: inherit !important;
  line-height: inherit !important;
}
.column {
  font-size: 14px;
  line-height: 21px;
  padding: 0;
  text-align: left;
  vertical-align: top;
}
.mso .font-avenir,
.mso .font-cabin,
.mso .font-open-sans,
.mso .font-ubuntu {
  font-family: sans-serif !important;
}
.mso .font-bitter,
.mso .font-merriweather,
.mso .font-pt-serif {
  font-family: Georgia, serif !important;
}
.mso .font-lato,
.mso .font-roboto {
  font-family: Tahoma, sans-serif !important;
}
.mso .font-pt-sans {
  font-family: ""Trebuchet MS"", sans-serif !important;
}
.mso .footer p {
  margin: 0;
}
@media only screen and (-webkit-min-device-pixel-ratio: 2), only screen and (min--moz-device-pixel-ratio: 2), only screen and (-o-min-device-pixel-ratio: 2/1), only screen and (min-device-pixel-ratio: 2), only screen and (min-resolution: 192dpi), only screen and (min-resolution: 2dppx) {
  .fblike {
    background-image: url(https://i7.createsend1.com/static/eb/master/13-the-blueprint-3/images/fblike@2x.png) !important;
  }
  .tweet {
    background-image: url(https://i8.createsend1.com/static/eb/master/13-the-blueprint-3/images/tweet@2x.png) !important;
  }
  .linkedinshare {
    background-image: url(https://i1.createsend1.com/static/eb/master/13-the-blueprint-3/images/lishare@2x.png) !important;
  }
  .forwardtoafriend {
    background-image: url(https://i9.createsend1.com/static/eb/master/13-the-blueprint-3/images/forward@2x.png) !important;
  }
}
@media only screen and (max-width: 620px) {
  .wrapper h2,
  .wrapper .size-18,
  .wrapper .size-20 {
    font-size: 17px !important;
    line-height: 26px !important;
  }
  .wrapper .size-22 {
    font-size: 18px !important;
    line-height: 26px !important;
  }
  .wrapper .size-24 {
    font-size: 20px !important;
    line-height: 28px !important;
  }
  .wrapper h1,
  .wrapper .size-26 {
    font-size: 22px !important;
    line-height: 31px !important;
  }
  .wrapper .size-28 {
    font-size: 24px !important;
    line-height: 32px !important;
  }
  .wrapper .size-30 {
    font-size: 26px !important;
    line-height: 34px !important;
  }
  .wrapper .size-32 {
    font-size: 28px !important;
    line-height: 36px !important;
  }
  .wrapper .size-34,
  .wrapper .size-36 {
    font-size: 30px !important;
    line-height: 38px !important;
  }
  .wrapper .size-40 {
    font-size: 32px !important;
    line-height: 40px !important;
  }
  .wrapper .size-44 {
    font-size: 34px !important;
    line-height: 43px !important;
  }
  .wrapper .size-48 {
    font-size: 36px !important;
    line-height: 43px !important;
  }
  .wrapper .size-56 {
    font-size: 40px !important;
    line-height: 47px !important;
  }
  .wrapper .size-64 {
    font-size: 44px !important;
    line-height: 50px !important;
  }
  .divider {
    Margin-left: auto !important;
    Margin-right: auto !important;
  }
  .btn a {
    display: block !important;
    font-size: 14px !important;
    line-height: 24px !important;
    padding: 12px 10px !important;
    width: auto !important;
  }
  .btn--shadow a {
    padding: 12px 10px 13px 10px !important;
  }
  .image img {
    height: auto;
    width: 100%;
  }
  .layout,
  .column,
  .preheader__webversion,
  .header td,
  .footer,
  .footer__left,
  .footer__right,
  .footer__inner {
    width: 320px !important;
  }
  .preheader__snippet,
  .layout__edges {
    display: none !important;
  }
  .preheader__webversion {
    text-align: center !important;
  }
  .header__logo {
    Margin-left: 20px;
    Margin-right: 20px;
  }
  .layout--full-width {
    width: 100% !important;
  }
  .layout--full-width tbody,
  .layout--full-width tr {
    display: table;
    Margin-left: auto;
    Margin-right: auto;
    width: 320px;
  }
  .column,
  .layout__gutter,
  .footer__left,
  .footer__right {
    display: block;
    Float: left;
  }
  .footer__inner {
    text-align: center;
  }
  .footer__links {
    Float: none;
    Margin-left: auto;
    Margin-right: auto;
  }
  .footer__right p,
  .footer__share-button {
    display: inline-block;
  }
  .layout__gutter {
    font-size: 20px;
    line-height: 20px;
  }
  .layout--no-gutter.layout--has-border:not(.layout--full-width),
  .layout--has-gutter.layout--has-border .column__background {
    width: 322px !important;
  }
  .layout--has-gutter.layout--has-border {
    left: -1px;
    position: relative;
  }
}
@media only screen and (max-width: 320px) {
  .border {
    display: none;
  }
  .layout--no-gutter.layout--has-border:not(.layout--full-width),
  .layout--has-gutter.layout--has-border .column__background {
    width: 320px !important;
  }
  .layout--has-gutter.layout--has-border {
    left: 0 !important;
  }
}
</style>
    
  <!--[if !mso]><!--><style type=""text/css"">
@import url(https://fonts.googleapis.com/css?family=PT+Sans:400,700,400italic,700italic|PT+Serif:400,700,400italic,700italic);
</style><link href=""https://fonts.googleapis.com/css?family=PT+Sans:400,700,400italic,700italic|PT+Serif:400,700,400italic,700italic"" rel=""stylesheet"" type=""text/css"" /><!--<![endif]--><style type=""text/css"">
body,.wrapper{background-color:#f6f6f6}.wrapper h1{color:#2f353e}.wrapper h1{}.wrapper h1{font-family:""PT Serif"",Georgia,serif}.mso .wrapper h1{font-family:Georgia,serif !important}.wrapper h2{color:#2f353e}.wrapper h3{color:#929292}.wrapper a{color:#b31b1b}.wrapper a:hover{color:#5a0e0e !important}.column,.column__background td{color:#8e8e8e}.column,.column__background td{font-family:""PT Sans"",""Trebuchet MS"",sans-serif}.mso .column,.mso .column__background td{font-family:""Trebuchet MS"",sans-serif !important}.border{background-color:#c3c3c3}.layout--no-gutter.layout--has-border:not(.layout--full-width),.layout--has-gutter.layout--has-border .column__background,.layout--full-width.layout--has-border{border-top:1px solid #c3c3c3;border-bottom:1px solid #c3c3c3}.wrapper blockquote{border-left:4px solid #c3c3c3}.divider{background-color:#c3c3c3}.wrapper .btn a{color:#fff}.wrapper .btn 
a{font-family:""PT Sans"",""Trebuchet MS"",sans-serif}.mso .wrapper .btn a{font-family:""Trebuchet MS"",sans-serif !important}.wrapper .btn a:hover{color:#fff !important}.btn--flat a,.btn--shadow a,.btn--depth a{background-color:#b31b1b}.btn--ghost a{border:1px solid #b31b1b}.preheader--inline,.footer__left{color:#8e8e8e}.preheader--inline,.footer__left{font-family:""PT Sans"",""Trebuchet MS"",sans-serif}.mso .preheader--inline,.mso .footer__left{font-family:""Trebuchet MS"",sans-serif !important}.wrapper .preheader--inline a,.wrapper .footer__left a{color:#8e8e8e}.wrapper .preheader--inline a:hover,.wrapper .footer__left a:hover{color:#8e8e8e !important}.header__logo{color:#c3ced9}.header__logo{font-family:Roboto,Tahoma,sans-serif}.mso .header__logo{font-family:Tahoma,sans-serif !important}.wrapper .header__logo a{color:#c3ced9}.wrapper .header__logo a:hover{color:#859bb1 
!important}.footer__share-button{background-color:#7b7b7b}.footer__share-button{font-family:""PT Sans"",""Trebuchet MS"",sans-serif}.mso .footer__share-button{font-family:""Trebuchet MS"",sans-serif !important}.layout__separator--inline{font-size:20px;line-height:20px;mso-line-height-rule:exactly}
</style><meta name=""robots"" content=""noindex,nofollow"" />
<meta property=""og:title"" content=""My First Campaign"" />
</head>
<!--[if mso]>
  <body class=""mso"">
<![endif]-->
<!--[if !mso]><!-->
  <body class=""full-padding"" style=""margin: 0;-webkit-text-size-adjust: 100%;background-color: #f6f6f6;"">
<!--<![endif]-->
    <div class=""wrapper"" style=""background-color: #f6f6f6;"">
      <table style='border-collapse: collapse;table-layout: fixed;color: #8e8e8e;font-family: ""PT Sans"",""Trebuchet MS"",sans-serif;' align=""center"">
        <tbody><tr>
          <td class=""preheader__snippet"" style=""padding: 10px 0 5px 0;vertical-align: top;"" width=""300"">
            
          </td>
          <td class=""preheader__webversion"" style=""text-align: right;padding: 10px 0 5px 0;vertical-align: top;"" width=""300"">
            
          </td>
        </tr>
      </tbody></table>
      
      <table class=""layout layout--no-gutter"" style=""border-collapse: collapse;table-layout: fixed;Margin-left: auto;Margin-right: auto;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"" align=""center"" emb-background-style>
        <tbody><tr>
          <td class=""column"" style='font-size: 14px;line-height: 21px;padding: 0;text-align: left;vertical-align: top;color: #8e8e8e;font-family: ""PT Sans"",""Trebuchet MS"",sans-serif;' width=""600"">
    
            <div style=""Margin-left: 20px;Margin-right: 20px;Margin-top: 24px;"">
      <div style=""line-height:20px;font-size:1px"">&nbsp;</div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <h1 class=""size-40"" style='Margin-top: 0;Margin-bottom: 0;font-style: normal;font-weight: normal;font-size: 40px;line-height: 47px;color: #2f353e;font-family: ""PT Serif"",Georgia,serif;text-align: center;'>&#183; You Have A New Applicant &#183;</h1><h3 style=""Margin-top: 20px;Margin-bottom: 12px;font-style: normal;font-weight: normal;font-size: 16px;line-height: 24px;color: #929292;text-align: center;""><strong>Click &quot;Approve Applicant&quot; To Approve The Applicant</strong></h3>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <div style=""line-height:25px;font-size:1px"">&nbsp;</div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <p class=""size-16"" style=""Margin-top: 0;Margin-bottom: 0;font-size: 16px;line-height: 24px;"">Applicant Name: Enter Name</p><p class=""size-16"" style=""Margin-top: 20px;Margin-bottom: 0;font-size: 16px;line-height: 24px;"">Location: Enter Location</p><p class=""size-16"" style=""Margin-top: 20px;Margin-bottom: 0;font-size: 16px;line-height: 24px;"">Phone Number: Enter Phonenumber</p><p class=""size-16"" style=""Margin-top: 20px;Margin-bottom: 0;font-size: 16px;line-height: 24px;"">Date Applied: Enter DateApplied</p><p class=""size-16"" style=""Margin-top: 20px;Margin-bottom: 20px;font-size: 16px;line-height: 24px;"">Email: Enter Email</p>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <div style=""line-height:20px;font-size:1px"">&nbsp;</div>
    </div>
    
        <div class=""image"" style=""font-size: 12px;font-style: normal;font-weight: 400;"" align=""center"">
          <img style=""display: block;border: 0;max-width: 174px;"" src=""images/divider5.png"" alt="""" width=""174"" height=""25"" />
        </div>
      
          </td>
        </tr>
      </tbody></table>
  
      <table class=""layout layout--no-gutter"" style=""border-collapse: collapse;table-layout: fixed;Margin-left: auto;Margin-right: auto;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"" align=""center"" emb-background-style>
        <tbody><tr>
          <td class=""column"" style='font-size: 14px;line-height: 21px;padding: 0;text-align: left;vertical-align: top;color: #8e8e8e;font-family: ""PT Sans"",""Trebuchet MS"",sans-serif;' width=""300"">
    
            <div style=""Margin-left: 20px;Margin-right: 20px;Margin-top: 24px;"">
      <div style=""line-height:15px;font-size:1px"">&nbsp;</div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <h1 style='Margin-top: 0;Margin-bottom: 0;font-style: normal;font-weight: normal;font-size: 26px;line-height: 34px;color: #2f353e;font-family: ""PT Serif"",Georgia,serif;text-align: center;'>&#183; Approve Applicant&#183;</h1><h3 style=""Margin-top: 20px;Margin-bottom: 12px;font-style: normal;font-weight: normal;font-size: 16px;line-height: 24px;color: #929292;text-align: center;"">&nbsp;</h3>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <div style=""line-height:15px;font-size:1px"">&nbsp;</div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <p class=""size-16"" style=""Margin-top: 0;Margin-bottom: 20px;font-size: 16px;line-height: 24px;text-align: center;""><span style=""color:#4d484d"">By clicking this button, you will approve this user's application. The user will automatically generate a username and password for this user. The system will also notify th</span><span style=""color:rgb(255, 255, 255)"">e user.</span></p>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <div style=""line-height:10px;font-size:1px"">&nbsp;</div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <div class=""btn btn--flat"" style=""Margin-bottom: 20px;text-align: center;"">
        <![if !mso]><a style=""border-radius: 4px;display: inline-block;font-weight: bold;text-align: center;text-decoration: none !important;transition: opacity 0.1s ease-in;color: #fff;background-color: #b31b1b;font-family: 'PT Sans', 'Trebuchet MS', sans-serif;font-size: 12px;line-height: 22px;padding: 10px 28px;"" href=""http://localhost:60115/account/confirmapplication/ApplicationId"" data-width=""112"">APPROVE APPLICANT</a><![endif]>
      <!--[if mso]><p style=""line-height:0;margin:0;"">&nbsp;</p><v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" href=""http://localhost:60115/account/confirmapplication/ApplicationId"" style=""width:168px"" arcsize=""10%"" fillcolor=""#B31B1B"" stroke=""f""><v:textbox style=""mso-fit-shape-to-text:t"" inset=""0px,9px,0px,9px""><center style=""font-size:12px;line-height:22px;color:#FFFFFF;font-family:sans-serif;font-weight:bold;mso-line-height-rule:exactly;mso-text-raise:4px"">APPROVE APPLICANT</center></v:textbox></v:roundrect><![endif]--></div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;Margin-bottom: 24px;"">
      <div style=""line-height:5px;font-size:1px"">&nbsp;</div>
    </div>
    
          </td>
          <td class=""column"" style='font-size: 14px;line-height: 21px;padding: 0;text-align: left;vertical-align: top;color: #8e8e8e;font-family: ""PT Sans"",""Trebuchet MS"",sans-serif;' width=""300"">
    
            <div style=""Margin-left: 20px;Margin-right: 20px;Margin-top: 24px;"">
      <div style=""line-height:15px;font-size:1px"">&nbsp;</div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <h1 style='Margin-top: 0;Margin-bottom: 0;font-style: normal;font-weight: normal;font-size: 26px;line-height: 34px;color: #2f353e;font-family: ""PT Serif"",Georgia,serif;text-align: center;'>&#183; Reject Applicant&#183;</h1><h3 style=""Margin-top: 20px;Margin-bottom: 12px;font-style: normal;font-weight: normal;font-size: 16px;line-height: 24px;color: #929292;text-align: center;""><strong>&nbsp;</strong></h3>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <div style=""line-height:15px;font-size:1px"">&nbsp;</div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <p class=""size-16"" style=""Margin-top: 0;Margin-bottom: 20px;font-size: 16px;line-height: 24px;text-align: center;"">B<span style=""color:rgb(153, 147, 153)"">y clicking this button, you will be redirected to a page where you can reject this user's application. The appilcation will still be pending once you reject this application.</span></p>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <div style=""line-height:10px;font-size:1px"">&nbsp;</div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;"">
      <div class=""btn btn--flat"" style=""Margin-bottom: 20px;text-align: center;"">
        <![if !mso]><a style=""border-radius: 4px;display: inline-block;font-weight: bold;text-align: center;text-decoration: none !important;transition: opacity 0.1s ease-in;color: #fff;background-color: #b31b1b;font-family: 'PT Sans', 'Trebuchet MS', sans-serif;font-size: 12px;line-height: 22px;padding: 10px 28px;"" href=""http://localhost:60115/account/rejectapplication/ApplicationId"" data-width=""100"">REJECT APPLICANT</a><![endif]>
      <!--[if mso]><p style=""line-height:0;margin:0;"">&nbsp;</p><v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" href=""http://localhost:60115/account/rejectapplication/ApplicationId"" style=""width:156px"" arcsize=""10%"" fillcolor=""#B31B1B"" stroke=""f""><v:textbox style=""mso-fit-shape-to-text:t"" inset=""0px,9px,0px,9px""><center style=""font-size:12px;line-height:22px;color:#FFFFFF;font-family:sans-serif;font-weight:bold;mso-line-height-rule:exactly;mso-text-raise:4px"">REJECT APPLICANT</center></v:textbox></v:roundrect><![endif]--></div>
    </div>
    
            <div style=""Margin-left: 20px;Margin-right: 20px;Margin-bottom: 24px;"">
      <div style=""line-height:5px;font-size:1px"">&nbsp;</div>
    </div>
    
          </td>
        </tr>
      </tbody></table>
  
      <div style=""font-size: 20px;line-height: 20px;mso-line-height-rule: exactly;"">&nbsp;</div>
    
      <table class=""footer"" style=""border-collapse: collapse;table-layout: fixed;Margin-right: auto;Margin-left: auto;border-spacing: 0;"" width=""600"" align=""center"">
        <tbody><tr>
          <td style=""padding: 0 0 40px 0;"">
            <table class=""footer__right"" style=""border-collapse: collapse;table-layout: auto;border-spacing: 0;"" align=""right"">
              <tbody><tr>
                <td class=""footer__inner"" style=""padding: 0;"">
                </td>
              </tr>
            </tbody></table>
            <table class=""footer__left"" style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;color: #8e8e8e;font-family: ""PT Sans"",""Trebuchet MS"",sans-serif;' width=""400"">
              <tbody><tr>
                <td class=""footer__inner"" style=""padding: 0;font-size: 12px;line-height: 19px;"">
                  
                  <div>
                    
                  </div>
                  <div class=""footer__permission"" style=""Margin-top: 18px;"">
                    
                  </div>
                  <div>
                  </div>
                </td>
              </tr>
            </tbody></table>
          </td>
        </tr>
      </tbody></table>
      <badge>
        
      </badge>
    </div>
  
</body></html>
";
            }
        }

        public string MessagToStudentOnSubmitApplication { get; set; }
        public string MessageToStudentOnApproveApplication { get; set; }
        public string MessageToAdministratorOnApproveApplication { get; set; }


    }
}