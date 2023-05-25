using Eskool.Code;
using Eskool.Helper;
using Eskool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Eskool.Code.SessionManager;
using Eskool.ViewModels;
using tik4net;

namespace Eskool.Controllers
{
 
    public class AccountController : Controller
    {

        private DatabaseContext context;

        public static  string sessionusername  { get; set; }

        public AccountController(DatabaseContext databaseContext)
        {
            this.context = databaseContext;
        }
  
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        } 
        
        
        public ActionResult Logout()
        {
            Sessions.Name = null;          
            return RedirectToAction("Login");

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel Login)
        {
            if (Login.UserName!=null && Login.Password!=null)
            {
                LoginInfo dt = await context.Database.SqlQuery<LoginInfo>($"Get_login '{Login.UserName.Trim()}','{Login.Password.Trim()}'").FirstOrDefaultAsync();
                //context.Set<LoginInfo>.s.GetLoginInfo(Login.UserName.Trim(), Login.Password.Trim());


                if (dt != null)
                {
                    MessageDisplay.RemoveAllCookies();
                    if (Sessions.Name == null)
                    {
                        Sessions.Name = new SessionInfo();
                    }

                    Sessions.Name.UserId = dt.LegacyID;
                    Sessions.Name.UserName = dt.UserName;
                    sessionusername = Sessions.Name.UserName;
                    Sessions.Name.DesignationCode = dt.DesignationCode;
                    Sessions.Name.UserSAPId = dt.UserName;
                    Sessions.Name.UserCellPhone = dt.CellPhone;
                    return RedirectToAction("OTP", "Account");
                }
                else
                {
                    ViewBag.Error = "Invalid User ID or password";
                }


                return View();

            }
            else
            {


                ViewBag.Error = "Invalid User ID or password";
                return View();
            }
            
        }

        [MsgAttribute]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePassword model)
        {
            string Query = $"SP_MARC_ChangePassword '{Sessions.Name.UserId}', '{model.NewPassword}', '{model.OldPassword}' ";
            int executed = await context.Database.ExecuteSqlCommandAsync(Query);

            if (executed > 0)
            {
                MessageDisplay.SetMassage("SuccessMsg", "Password changed successfully.");
            }
            else
            {
                MessageDisplay.SetMassage("ErrorMsg", "Incorrect old password.");
            }

            return RedirectToAction("ChangePassword");
        }


        public async Task<ActionResult> GetImage()
        {


            if (Sessions.Name != null)
            {
                int width = 240,  height = 250;

                string sql = $"SELECT * FROM IrisNetSD_HPL.dbo.VEmpPhotos where employeeCode = '{Sessions.Name.UserId}'";
                var dataResult = await context.Query(sql).ToDynamicListAsync();

                if (dataResult != null && dataResult.Count > 0)
                {
                    Byte[] imageFromDB = (byte[])dataResult[0]["Photo"];

                   // string data = "data:image/png;base64," + Convert.ToBase64String(imageFromDB);

                  //  return new JsonResult() { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = int.MaxValue };

                    //Debug.WriteLine("img is not null");
                 //   var imageFromDB = img.Photo;
                   // Debug.WriteLine("img is null");
                    return File(Thumbnail(ref imageFromDB, width, height), "image/png");

                }

            }

            return null;

        }

        public static byte[] Thumbnail(ref byte[] photo, int width, int height)
        {



            if (photo != null)
            {
                var base64 = Convert.ToBase64String(photo);
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);

                using (var newImage = new Bitmap(width, height))
                using (var graphics = Graphics.FromImage(newImage))
                using (var stream = new MemoryStream())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(image, new Rectangle(0, 0, width, height));
                    newImage.Save(stream, ImageFormat.Png);

                    return stream.ToArray();

                }

            }


            return null;


        }

        public ActionResult OTP()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OTP(OTPViewModel vmOtpViewModel)
        {
            try
            {
                string UserName = string.Empty;
                string Password = string.Empty;
                string Exception = "User name and password unavailable at this moment, contact with network person!";
                var InternetOTP = new Internet_Access_OTPGenerators();

                InternetOTP.EmployeeCode = vmOtpViewModel.EmployeeCode;
                InternetOTP.GuestName = vmOtpViewModel.GuestName;
                InternetOTP.CompanyName = vmOtpViewModel.CompanyName;
                InternetOTP.Address = vmOtpViewModel.Address;
                InternetOTP.Duration = vmOtpViewModel.Duration;
                InternetOTP.CreationTime = DateTime.Now;
                InternetOTP.Remarks = vmOtpViewModel.Remarks;
                InternetOTP.Remarks = vmOtpViewModel.Remarks;
                InternetOTP.GuestMobileNo = vmOtpViewModel.GuestMobileNo;
                InternetOTP.Creator = Sessions.Name.UserSAPId;

                context.Internet_Access_OTPGenerators.Add(InternetOTP);
                context.SaveChanges();
                var dataTable = GetHotspotUserDetails("10.10.10.2", "khalid", "khal!d");

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.Field<string>("Uptime") == "0s" &&
                            row.Field<string>("Profile") == vmOtpViewModel.Duration.ToString() + "Hours")
                        {
                            UserName = row.Field<string>("User Name");
                            Password = row.Field<string>("Password");
                            break;
                        }
                    }
                }

                string message = $"User Name: {UserName} Password: {Password}";
                if (UserName == "")
                {
                    TempData["SuccessMessage"] = Exception;
                }
                else
                {
                    TempData["SuccessMessage"] = message;
                }
               
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.SelectedDuration = vmOtpViewModel.Duration;
            return View(vmOtpViewModel);
        }

        #region GetHotspotUserDetails
        public DataTable GetHotspotUserDetails(string ipAddress, string UserName, string Password)
        {
            var connection = ConnectionFactory.OpenConnection(TikConnectionType.Api, ipAddress, UserName, Password);

            if (connection.IsOpened)
            {
                var queueList = connection.CallCommandSync("/ip/hotspot/user/print");
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("User Name");
                dataTable.Columns.Add("Password");
                dataTable.Columns.Add("Profile");
                dataTable.Columns.Add("Uptime");
               

                foreach (var sentence in queueList)
                {
                    if (sentence.Words.Count() != 0)
                    {
                        var id = sentence.Words[".id"];

                        if (!id.StartsWith("*0"))
                        {
                            var name = sentence.Words["name"];
                            var password = sentence.Words["password"];
                            var uptime = sentence.Words["uptime"];
                            var profile = sentence.Words["profile"];

                            DataRow row = dataTable.NewRow();
                            row["User Name"] = name;
                            row["Password"] = password;
                            row["Profile"] = profile;
                            row["Uptime"] = uptime;
                            dataTable.Rows.Add(row);
                        }

                    }
                }

                return dataTable;
            }

            return null;
        }
        #endregion
    }
}