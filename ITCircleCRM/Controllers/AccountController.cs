using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationDTO;
using ITCircleBL;
namespace ITCircleCRM.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CustomerRegistration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection formValue )
        {
            UsersDTO usersDto = new UsersDTO();
            usersDto.username = formValue["username"];
            usersDto.password = formValue["password"];
            List<UsersDTO> userList = new List<UsersDTO>();
            userList = new ITCircleBL.AplicationBL().GetUserInfo(usersDto);
            //userList = userList.Where(s => s.userid== Convert.ToInt32()).FirstOrDefault();
            //userList = userList.Where(s => s.username.Equals(usersDto.username) && s.password.Equals(usersDto.password)).FirstOrDefault();
            if (userList != null && userList.Count>0)
            {
              
                System.Web.HttpContext.Current.Session["userid"] =userList[0].userid;
                System.Web.HttpContext.Current.Session["username"] = userList[0].username;
                System.Web.HttpContext.Current.Session["UserRole"] = userList[0].RoleId;
                //Session["username"] = usersDto.username;
                //Session["UserRole"] = userList;
                Session.Timeout = 10;
                //var v = (List<UsersDTO>)Session["userList"];
                if (userList[0].RoleId == "5")
                {
                    return RedirectToAction("GetTicket", "MstTemplet");
                }
                else if (userList[0].RoleId == "3")
                {
                    return RedirectToAction("GetProduct", "MstTemplet");
                }
                else if (userList[0].RoleId == "4")
                {
                    return RedirectToAction("GetTechComment", "MstTemplet");
                }
                else
                {
                    return RedirectToAction("GetCustomer", "MstTemplet");
                }
            }
            return RedirectToAction("Login", "Account");
        }

       
    }
}
