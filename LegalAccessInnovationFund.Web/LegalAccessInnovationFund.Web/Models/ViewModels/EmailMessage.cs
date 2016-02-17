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
                return @"""<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional //EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd""><html xmlns=""http://www.w3.org/1999/xhtml""><head>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <!--[if !mso]><!--><meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" /><!--<![endif]-->
    <meta name=""viewport"" content=""width=device-width"" />
<style>
.user-row {
    margin-bottom: 14px;
}

.user-row:last-child {
    margin-bottom: 0;
}

.dropdown-user {
    margin: 13px 0;
    padding: 5px;
    height: 100%;
}

.dropdown-user:hover {
    cursor: pointer;
}

.table-user-information > tbody > tr {
    border-top: 1px solid rgb(221, 221, 221);
}

.table-user-information > tbody > tr:first-child {
    border-top: 0;
}


.table-user-information > tbody > tr > td {
    border-top: 0;
}
.toppad
{margin-top:20px;
}

</style>
    <div class=""container"">
      <div class=""row"">
      <div class=""col-md-5  toppad  pull-right col-md-offset-3 "">
       <br>
<p class="" text-info""> Enter DateApplied </p>
      </div>
        <div class=""col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad"" >
   
          <div class=""panel panel-info"">
            <div class=""panel-heading"">
              <h3 class=""panel-title"">Enter Name</h3>
            </div>
            <div class=""panel-body"">
              <div class=""row"">
                <div class="" col-md-9 col-lg-9 ""> 
                  <table class=""table table-user-information"">
                    <tbody>
                        <tr>
                        <td>Date Applied</td>
                        <td>Enter Date Applied</td>
                        </tr>
                      <tr>
                        <td>School Year</td>
                        <td>Enter SchoolYear</td>
                      </tr>
                        <tr>
                        <td>Phone Number</td>
                        <td>Enter Phonenumber</td>
                      </tr>
                        <tr>
                        <td>Law School</td>
                        <td>Enter LawSchool</td>
                      </tr>
                      <tr>
                        <td>Email</td>
                        <td><a href=""Enter Email"">Enter Email</a></td>
                       </tr>
                    </tbody>
                  </table>
                  
                  <a href=""http://localhost:60115/account/rejectapplication/ApplicationId""class=""btn btn-danger"">Reject This Application</a>
                  <a href=""http://localhost:60115/account/confirmapplication/ApplicationId""class=""btn btn-success"">Approve This Application</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  
</body></html>""";
            }
        }

        public string MessagToStudentOnSubmitApplication { get; set; }
        public string MessageToStudentOnApproveApplication { get; set; }
        public string MessageToAdministratorOnApproveApplication { get; set; }


    }
}