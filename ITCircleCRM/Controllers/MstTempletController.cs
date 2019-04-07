using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationDTO;
using ITCircleBL;

namespace ITCircleCRM.Controllers
{
    public class MstTempletController : Controller
    {
        //
        // GET: /MstTemplet/

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult LogOut()
        {
            // FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login", "Account");
        }
        public ActionResult NewTicket(String Id = "", String CustomerId = "", String ProductId = "")
        {
            NewTicketDTO Ticketinfo = new NewTicketDTO();
            if (!String.IsNullOrEmpty(Id))
            {
                List<NewTicketDTO> TicketList = new ITCircleBL.AplicationBL().GetTicketInfo(new NewTicketDTO() { Id = Convert.ToInt32(Id) });
                if (TicketList != null && TicketList.Count == 1)
                    Ticketinfo = TicketList[0];//.Where(s => s.Id == Convert.ToInt32(Id)).FirstOrDefault();

                // return Content("Welcome " + Session["userid"]);
            }

            List<MasterRefundType> RefundeList = new ITCircleBL.AplicationBL().GetRefundeList(new MasterRefundType());
            List<SelectListItem> items7 = new List<SelectListItem>();
            foreach (var t in RefundeList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.RefundTypeName;
                s.Value = t.Id.ToString();
                items7.Add(s);
            }
            ViewBag.RefundeType = items7;

            List<UsersDTO> usrRolesList = new ITCircleBL.AplicationBL().GetAllUsersRoleInfo();
            List<SelectListItem> assignToList = new List<SelectListItem>();
            foreach (var t in usrRolesList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.UserRoleDesc;
                s.Value = t.userid.ToString();
                assignToList.Add(s);
            }
            ViewBag.AssignTo = assignToList;

            if (!String.IsNullOrEmpty(CustomerId))
            {
                List<CustomerDTO> CustomerList = new ITCircleBL.AplicationBL().GetCutomerInfo(new CustomerParamDTO() { CustomerID = Convert.ToInt16(CustomerId) });
                foreach (var item in CustomerList)
                {
                    item.ContanctNo = item.ContanctNo.Replace(item.ContanctNo.Substring(0, 7).ToString(), "xxxxxxx");
                    item.EmailId = item.EmailId.Replace(item.EmailId.Substring(3, item.EmailId.IndexOf('@') - 3).ToString(), "xxxxx");
                }

                ViewBag.CutomerList = CustomerList;
            }
            if (!String.IsNullOrEmpty(ProductId))
            {
                List<AddProduct> ProductList = new ITCircleBL.AplicationBL().GetProduct(new AddProduct() { ProductId = Convert.ToInt16(ProductId) });

                ViewBag.ProductList = ProductList;
            }


            return View(Ticketinfo);


        }
        public ActionResult CustomerRegistration(string CustomerId = "")
        {

            CustomerDTO customerInfo = new CustomerDTO();
            if (!string.IsNullOrEmpty(CustomerId))
            {
                List<CustomerDTO> customerList = new ITCircleBL.AplicationBL().GetCutomerInfo(new CustomerParamDTO());
                customerInfo = customerList.Where(s => s.CustomerId == Convert.ToInt32(CustomerId)).FirstOrDefault();
            }
            List<MasterState> StateList = new ITCircleBL.AplicationBL().GetState(new MasterState());
            List<SelectListItem> items5 = new List<SelectListItem>();
            foreach (var t in StateList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.Statename;
                s.Value = t.StateId.ToString();
                items5.Add(s);
            }
            ViewBag.State = items5;

            List<MasterCity> CityList = new ITCircleBL.AplicationBL().GetCity(new MasterCity());
            List<SelectListItem> items6 = new List<SelectListItem>();
            foreach (var t in CityList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.Cityname;
                s.Value = t.CityId.ToString();
                items6.Add(s);
            }
            ViewBag.City = items6;

            return View(customerInfo);

        }



        public ActionResult GetCustomer(String SearchValue = "")
        {
            CustomerParamDTO customerParamDTO = new CustomerParamDTO();
            List<CustomerDTO> customerList = new List<CustomerDTO>();
            customerParamDTO.CreatedBy = Convert.ToInt16(Session["userid"]);
            customerParamDTO.SearchValue = SearchValue;
            customerParamDTO.RoleID = Convert.ToInt32(Session["UserRole"]);

            if (string.IsNullOrEmpty(SearchValue))
                customerList = new ITCircleBL.AplicationBL().GetCutomerInfo(customerParamDTO);
            else
                customerList = new ITCircleBL.AplicationBL().GetCustomerSearch(customerParamDTO);
            return View(customerList);

        }

        public ActionResult DeleteCustomer(String CustomerId = "")
        {
            if (!String.IsNullOrEmpty(CustomerId))
            {
                CustomerDTO CustomerInfo = new CustomerDTO();
                CustomerInfo.CustomerId = Convert.ToInt32(CustomerId);
                new ITCircleBL.AplicationBL().deleteCustomerinfo(CustomerInfo);
            }
            List<CustomerDTO> customerList = new ITCircleBL.AplicationBL().GetCutomerInfo(new CustomerParamDTO());
            return View("GetCustomer", customerList);

        }


        public ActionResult UserRegistration(String userid = "")
        {
            UsersDTO UserInfo = new UsersDTO();
            if (!String.IsNullOrEmpty(userid))
            {
                List<UsersDTO> userlist = new ITCircleBL.AplicationBL().GetUserInfo1(new UsersDTO());
                UserInfo = userlist.Where(s => s.userid == Convert.ToInt32(userid)).FirstOrDefault();
            }
            List<MasterUserRole> userroleList = new ITCircleBL.AplicationBL().getUserRole(new MasterUserRole());
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var t in userroleList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.RoleName;
                s.Value = t.RoleId.ToString();
                items.Add(s);
            }

            ViewBag.Roles = items;
            return View(UserInfo);
        }
        [HttpPost]
        public ActionResult CustomerRegistration(FormCollection formvalue, String CustomerId = "", String Command = "")
        {

            if (Command == "AddCustomer")
            {

                try
                {
                    CustomerDTO customerDTO = new CustomerDTO();
                    customerDTO.CreatedBy = Convert.ToInt16(Session["userid"]);
                    customerDTO.CustomerName = formvalue["CustomerName"];
                    customerDTO.ContanctNo = formvalue["ContactNo"];
                    customerDTO.EmailId = formvalue["EmailId"];
                    customerDTO.State = formvalue["State"];
                    customerDTO.City = formvalue["City"];
                    customerDTO.AccountNo = formvalue["Accno"];


                    List<CustomerDTO> customerList = new List<CustomerDTO>();

                    customerList = new ITCircleBL.AplicationBL().InsertCustomerInfo(customerDTO);
                    TempData["DisplayMessage"] = "Customer Registered Successfully.";
                    return RedirectToAction("CustomerRegistration", "MstTemplet");
                }
                catch (Exception ex)
                {
                    if (((System.Data.SqlClient.SqlException)(ex)).Number == 2601)
                    {
                        TempData["DisplayMessage"] = "Account Number already exists.";
                        return RedirectToAction("CustomerRegistration", "MstTemplet");
                    }

                }
            }
            else if (Command == "UpdateCustomer")
            {
                if (!string.IsNullOrEmpty(CustomerId))
                {
                    CustomerDTO CustomerDTO = new CustomerDTO();
                    CustomerDTO.EditedBy = Convert.ToInt16(Session["userid"]);
                    CustomerDTO.CustomerName = formvalue["CustomerName"];
                    CustomerDTO.ContanctNo = formvalue["ContactNo"];
                    CustomerDTO.EmailId = formvalue["EmailId"];
                    CustomerDTO.State = formvalue["State"];
                    CustomerDTO.City = formvalue["City"];
                    CustomerDTO.AccountNo = formvalue["Accno"];

                    List<CustomerDTO> customerList = new List<CustomerDTO>();
                    CustomerDTO.CustomerId = Convert.ToInt32(CustomerId);

                    customerList = new ITCircleBL.AplicationBL().UpdateCustomerInfo(CustomerDTO);
                    List<CustomerDTO> CustomerList = new ITCircleBL.AplicationBL().GetCutomerInfo(new CustomerParamDTO());
                    return View("GetCustomer", CustomerList);
                }


            }
            return null;
        }

        [HttpPost]
        public ActionResult NewTicket(FormCollection formvalue, String Id = "", String Command = "")
        {
            if (Command == "AddTicket")
            {
                NewTicketDTO newticketDTO = new NewTicketDTO();
                newticketDTO.CreatedBy = Convert.ToInt16(Session["userid"]);
                newticketDTO.RefundReason = formvalue["RefundReason"];
                newticketDTO.RefundType = formvalue["CSRefundType"];
                newticketDTO.Solution = formvalue["Solution"];
                if (formvalue["CSAssignTo"] == null)
                {
                    newticketDTO.AssignTo = Session["userid"].ToString();
                }
                else
                {
                    newticketDTO.AssignTo = formvalue["CSAssignTo"];
                }
                newticketDTO.CustomerId = formvalue["CustomerID"];
                newticketDTO.ProductId = formvalue["ProductId"];
                List<NewTicketDTO> NewTicketList = new List<NewTicketDTO>();
                NewTicketList = new ITCircleBL.AplicationBL().InsertNewTicket(newticketDTO);
                return RedirectToAction("GetProduct", "MstTemplet");
            }
            else if (Command == "updateTicket")
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    NewTicketDTO newticketDTO = new NewTicketDTO();
                    newticketDTO.EditedBy = Convert.ToInt16(Session["userid"]);
                    newticketDTO.RefundReason = formvalue["RefundReason"];
                    newticketDTO.RefundType = formvalue["RefundType"];
                    newticketDTO.Solution = formvalue["Solution"];
                    newticketDTO.AssignTo = formvalue["AssignTo"];
                    List<NewTicketDTO> NewTicketList = new List<NewTicketDTO>();
                    newticketDTO.Id = Convert.ToInt32(Id);
                    NewTicketList = new ITCircleBL.AplicationBL().updateTicket(newticketDTO);
                    List<NewTicketDTO> newTicketList = new ITCircleBL.AplicationBL().GetTicketInfo(new NewTicketDTO());
                    return View("GetTicket", newTicketList);
                }
            }
            return null;
        }

        [HttpPost]
        public ActionResult UserRegistration(FormCollection formvalue, String userid = "", String Command = "")
        {
            if (Command == "AddNewUser")
            {
                UsersDTO userDTO = new UsersDTO();
                userDTO.CreatedBy = Convert.ToInt16(Session["userid"]);
                userDTO.name = formvalue["Name"];
                userDTO.username = formvalue["Username"];
                userDTO.password = formvalue["Password"];
                userDTO.IsActive = Convert.ToBoolean(formvalue["Status"]);
                userDTO.RoleId = formvalue["UserRole"];
                // userDTO.Solution = formvalue[""];
                List<UsersDTO> userDTOList = new List<UsersDTO>();

                userDTOList = new ITCircleBL.AplicationBL().Insertuser(userDTO);

                return RedirectToAction("UserRegistration", "MstTemplet");
            }
            else if (Command == "UpdateUser")
            {
                if (!string.IsNullOrEmpty(userid))
                {
                    UsersDTO userDTO = new UsersDTO();
                    userDTO.EditedBy = Convert.ToInt16(Session["userid"]);
                    userDTO.name = formvalue["Name"];
                    userDTO.username = formvalue["Username"];
                    userDTO.password = formvalue["Password"];
                    // userDTO.IsActive = formvalue["Status"];
                    userDTO.IsActive = Convert.ToBoolean(formvalue["Status"]);
                    userDTO.RoleId = formvalue["UserRole"];
                    // userDTO.Solution = formvalue[""];
                    List<UsersDTO> userDTOList = new List<UsersDTO>();
                    userDTO.userid = Convert.ToInt32(userid);
                    userDTOList = new ITCircleBL.AplicationBL().Updateuser(userDTO);
                    List<UsersDTO> newuserList = new ITCircleBL.AplicationBL().GetUserInfo1(new UsersDTO());
                    return View("getUsers", newuserList);
                }

            }
            return null;
        }

        //[HttpPost]
        //public ActionResult CustomerRegistration(FormCollection formvalue)
        //{
        //    CustomerDTO cutomerDTO = new CustomerDTO();
        //    cutomerDTO.CustomerName = formvalue[""];
        //    return null;
        //}

        public ActionResult GetTicket(String SearchValue = "")
        {
            NewTicketDTO NewticketDTO = new NewTicketDTO();
            List<NewTicketDTO> TicketList = new List<NewTicketDTO>();
            NewticketDTO.SearchValue = SearchValue;
            NewticketDTO.UserId = Convert.ToInt16(Session["userid"]);
            NewticketDTO.RoleID = Convert.ToInt32(Session["UserRole"]);
            if (string.IsNullOrEmpty(SearchValue))
                TicketList = new ITCircleBL.AplicationBL().GetTicketInfo(NewticketDTO);
            else
                TicketList = new ITCircleBL.AplicationBL().GetTicketSearch(NewticketDTO);
            return View(TicketList);
        }

        public ActionResult getUsers(String SearchValue = "")
        {
            List<UsersDTO> UserList = new List<UsersDTO>();
            if (String.IsNullOrEmpty(SearchValue))
            {
                UserList = new ITCircleBL.AplicationBL().GetUserInfo1(new UsersDTO());
            }
            else
            {
                UserList = new ITCircleBL.AplicationBL().GetUserSearch(SearchValue);
            }
            return View(UserList);
        }

        public ActionResult DeleteUser(String userid = "")
        {
            if (!String.IsNullOrEmpty(userid))
            {
                UsersDTO userInfo = new UsersDTO();
                userInfo.userid = Convert.ToInt32(userid);
                new ITCircleBL.AplicationBL().deleteUserinfo(userInfo);
            }
            List<UsersDTO> UserList = new ITCircleBL.AplicationBL().GetUserInfo1(new UsersDTO());
            return View("getUsers", UserList);

        }

        public ActionResult DeleteTicket(String Id = "")
        {
            if (!String.IsNullOrEmpty(Id))
            {
                NewTicketDTO TicketInfo = new NewTicketDTO();
                TicketInfo.Id = Convert.ToInt32(Id);
                new ITCircleBL.AplicationBL().deleteTicketinfo(TicketInfo);
            }
            List<UsersDTO> UserList = new ITCircleBL.AplicationBL().GetUserInfo1(new UsersDTO());
            return View("GetTicket", UserList);

        }
        //public ActionResult DropDownCustomerform()
        //{
        //    List<CustomerDTO> DropDownList = new ITCircleBL.AplicationBL().DropDownCustomer(new CustomerDTO());
        //    return View("UserRegistration.", DropDownList);
        //}
        [HttpPost]
        public ActionResult getUserRole1()
        {

            return View("UserRegistration");
        }

        public ActionResult AddProduct(String ProductId = "", String CustomerId = "", String AccountNo = "")
        {

            AddProduct ProductDTO = new AddProduct();

            if (!string.IsNullOrEmpty(ProductId))
            {
                List<AddProduct> ProductList = new ITCircleBL.AplicationBL().GetProduct(new AddProduct());
                ProductDTO = ProductList.Where(s => s.ProductId == Convert.ToInt32(ProductId)).FirstOrDefault();
            }
            List<MasterCallType> CallTypelist = new ITCircleBL.AplicationBL().getCallType(new MasterCallType());
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var t in CallTypelist)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.Name;
                s.Value = t.Id.ToString();
                items.Add(s);
            }

            ViewBag.CallType = items;


            List<MasterSubcallType> SubCallTypeList = new ITCircleBL.AplicationBL().getSubCallType(new MasterSubcallType());
            List<SelectListItem> items1 = new List<SelectListItem>();
            foreach (var t in SubCallTypeList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.SubCallName;
                s.Value = t.Id.ToString();
                items1.Add(s);
            }

            ViewBag.SubCallType = items1;

            List<MasterPayment> PaymentList = new ITCircleBL.AplicationBL().GetPaymentList(new MasterPayment());
            List<SelectListItem> items2 = new List<SelectListItem>();
            foreach (var t in PaymentList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.PaymentName;
                s.Value = t.Id.ToString();
                items2.Add(s);
            }

            ViewBag.Payment = items2;

            List<MasterSubcriptionType> SubcriptionTypeList = new ITCircleBL.AplicationBL().GetSubcriptionType(new MasterSubcriptionType());
            List<SelectListItem> items3 = new List<SelectListItem>();
            foreach (var t in SubcriptionTypeList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.SubcriptionName;
                s.Value = t.Id.ToString();
                items3.Add(s);
            }
            ViewBag.SubcriptionType = items3;

            List<MasterProduct> ProductList1 = new ITCircleBL.AplicationBL().GetProduct(new MasterProduct());
            List<SelectListItem> items4 = new List<SelectListItem>();
            foreach (var t in ProductList1)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.Productname;
                s.Value = t.ProductId.ToString();
                items4.Add(s);
            }
            ViewBag.Product = items4;

            List<MasterCallStatus> CallStatusList = new ITCircleBL.AplicationBL().getCallStatusList(new MasterCallStatus());
            List<SelectListItem> items8 = new List<SelectListItem>();
            foreach (var t in CallStatusList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.CallStatusName;
                s.Value = t.id.ToString();
                items8.Add(s);
            }
            ViewBag.CallStatus = items8;

            List<UsersDTO> usrRolesList = new ITCircleBL.AplicationBL().GetAllUsersRoleInfo();
            List<SelectListItem> assignToList = new List<SelectListItem>();
            foreach (var t in usrRolesList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.UserRoleDesc;
                s.Value = t.userid.ToString();
                assignToList.Add(s);
            }
            ViewBag.AssignTo = assignToList;
            if (!String.IsNullOrEmpty(CustomerId))
            {
                // ProductDTO.CustomerId = Convert.ToInt32(CustomerId);
                List<CustomerDTO> CustomerList = new ITCircleBL.AplicationBL().GetCutomerInfo(new CustomerParamDTO() { CustomerID = Convert.ToInt32(CustomerId) });
                ViewBag.CutomerList = CustomerList;
            }


            return View(ProductDTO);
        }
        [HttpPost]
        public ActionResult AddProduct(FormCollection formvalue, String ProductId = "", String Command = "", String AccountNo = "")
        {
            if (Command == "AddProduct")
            {
                AddProduct ProductDTO = new AddProduct();

                ProductDTO.Product = formvalue["Product"];
                ProductDTO.CallType = formvalue["CallType"];
                ProductDTO.SubCallType = formvalue["SubCallType"];
                ProductDTO.SubcriptionType = formvalue["SubscriptionType"];
                ProductDTO.NoOfSystem = formvalue["NoOfSystem"];
                ProductDTO.PaymentMode = formvalue["Payment"];
                ProductDTO.CallStatus = formvalue["CallStatus"];
                if (formvalue["AssignTo"] == null)
                {
                    ProductDTO.AssignTo = Convert.ToString(Session["userid"]);
                }
                else
                {
                    ProductDTO.AssignTo = formvalue["AssignTo"];
                }
                ProductDTO.Remark = formvalue["Remark"];
                ProductDTO.AccountNo = formvalue["AccountNo"];
                ProductDTO.CreatedBy = Convert.ToInt32(Session["userid"]);
                ProductDTO.CustomerId = Convert.ToInt16(formvalue["CustomerID"]);

                List<AddProduct> productList = new List<AddProduct>();

                productList = new ITCircleBL.AplicationBL().insertProduct(ProductDTO);

                return RedirectToAction("GetCustomer", "MstTemplet");
            }
            else if (Command == "UpdateProduct")
            {
                if (!string.IsNullOrEmpty(ProductId))
                {
                    AddProduct ProductDTO = new AddProduct();
                    ProductDTO.Product = formvalue["Product"];
                    ProductDTO.CallType = formvalue["CallType"];
                    ProductDTO.SubCallType = formvalue["SubCallType"];
                    ProductDTO.SubcriptionType = formvalue["SubscriptionType"];
                    ProductDTO.NoOfSystem = formvalue["NoOfSystem"];
                    ProductDTO.PaymentMode = formvalue["Payment"];
                    ProductDTO.CallStatus = formvalue["CallStatus"];
                    if ((formvalue["AssignTo"]) == null)
                    {
                        ProductDTO.AssignTo = Convert.ToString(Session["userid"]);
                    }
                    else
                    {
                        ProductDTO.AssignTo = formvalue["AssignTo"];
                    }
                    ProductDTO.Remark = formvalue["Remark"];
                    ProductDTO.EditedBy = Convert.ToInt32(Session["userid"]);

                    List<AddProduct> ProductList = new List<AddProduct>();
                    ProductDTO.ProductId = Convert.ToInt32(ProductId);

                    ProductList = new ITCircleBL.AplicationBL().UpdateProduct(ProductDTO);
                    List<AddProduct> Productlist = new ITCircleBL.AplicationBL().GetProduct(new AddProduct());
                    return View("GetProduct", Productlist);
                }


            }
            return null;
        }
        public ActionResult GetProduct(String SearchValue = "")
        {
            AddProduct AddProductDTO = new AddProduct();
            List<AddProduct> ProductList = new List<AddProduct>();
            AddProductDTO.SearchValue = SearchValue;
            AddProductDTO.UserId = Convert.ToInt16(Session["userid"]);
            AddProductDTO.RoleId = Convert.ToInt16(Session["UserRole"]);
            if (String.IsNullOrEmpty(SearchValue))

                ProductList = new ITCircleBL.AplicationBL().GetProduct(AddProductDTO);
            else
                ProductList = new ITCircleBL.AplicationBL().GetProductSearch(AddProductDTO);

            return View(ProductList);

        }

        //public ActionResult SearchCustomer(String SearchValue = "")
        //{
        //    CustomerDTO CustomerSearch = new CustomerDTO();

        //    List<CustomerDTO> CustomerListSearch = new ITCircleBL.AplicationBL().GetCustomerSearch(new CustomerDTO());

        //    return View(CustomerListSearch);

        //}

        public ActionResult TechComment(String TicketId = "", String CustomerId = "", String ProductId = "", string TechId = "", String FollowupId = "")
        {
            TechCommentDTO techinfo = new TechCommentDTO();

            if (!string.IsNullOrEmpty(TechId))
            {
                List<TechCommentDTO> TechCommentList = new ITCircleBL.AplicationBL().GetTechCommentInfo(new TechCommentDTO());
                techinfo = TechCommentList.Where(s => s.TechId == Convert.ToInt32(TechId)).FirstOrDefault();
            }
            List<UsersDTO> usrRolesList = new ITCircleBL.AplicationBL().GetAllUsersRoleInfo();
            List<SelectListItem> assignToList = new List<SelectListItem>();
            foreach (var t in usrRolesList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.UserRoleDesc;
                s.Value = t.userid.ToString();
                assignToList.Add(s);
            }
            ViewBag.AssignTo = assignToList;

            if (!String.IsNullOrEmpty(CustomerId))
            {
                List<CustomerDTO> CustomerList = new ITCircleBL.AplicationBL().GetCutomerInfo(new CustomerParamDTO() { CustomerID = Convert.ToInt16(CustomerId) });
                foreach (var item in CustomerList)
                {
                    item.ContanctNo = item.ContanctNo.Replace(item.ContanctNo.Substring(0, 7).ToString(), "xxxxxxx");
                    item.EmailId = item.EmailId.Replace(item.EmailId.Substring(3, item.EmailId.IndexOf('@') - 3).ToString(), "xxxxx");
                }

                ViewBag.CutomerList = CustomerList;
            }
            if (!String.IsNullOrEmpty(ProductId))
            {
                List<AddProduct> ProductList = new ITCircleBL.AplicationBL().GetProduct(new AddProduct() { ProductId = Convert.ToInt16(ProductId) });

                ViewBag.ProductList = ProductList;
            }
            if (!String.IsNullOrEmpty(TicketId))
            {
                List<NewTicketDTO> Ticketlist = new ITCircleBL.AplicationBL().GetTicketInfo(new NewTicketDTO() { TicketId = Convert.ToInt16(TicketId) });
                ViewBag.TicketList = Ticketlist;
            }
            if (!String.IsNullOrEmpty(TechId))
            {
                List<TechCommentDTO> TechCommList = new ITCircleBL.AplicationBL().GetTechCommentInfo(new TechCommentDTO() { TechId = Convert.ToInt32(TechId) });
                ViewBag.TechCommList = TechCommList;
            }
            if (!String.IsNullOrEmpty(FollowupId))
            {

            }

            List<MasterRefundType> RefundeList = new ITCircleBL.AplicationBL().GetRefundeList(new MasterRefundType());
            List<SelectListItem> items7 = new List<SelectListItem>();
            foreach (var t in RefundeList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.RefundTypeName;
                s.Value = t.Id.ToString();
                items7.Add(s);
            }
            ViewBag.RefundeType = items7;
            return View(techinfo);


        }
        [HttpPost]
        public ActionResult TechComment(FormCollection formvalue,String Command="")
        {
            if (Command == "AddComment")
            {
                TechCommentDTO techCommentDTO = new TechCommentDTO();
                techCommentDTO.CreatedBy = Convert.ToInt16(Session["userid"]);
                techCommentDTO.CustomerId =Convert.ToInt16(formvalue["CustomerID"]);
                techCommentDTO.ProductId = Convert.ToInt16(formvalue["ProductId"]);
                techCommentDTO.TicketId = Convert.ToInt32(formvalue["TicketId"]);
                techCommentDTO.AssingTo = formvalue["AssignTo"];
                techCommentDTO.TechDisposition = formvalue["RefundType"];
                techCommentDTO.TechSolution = formvalue["Solution1"];
                techCommentDTO.TechRemark = formvalue["Remark"];
                List<TechCommentDTO> techCommentDTOList = new List<TechCommentDTO>();

                techCommentDTOList = new ITCircleBL.AplicationBL().InserttechComment(techCommentDTO);

                return RedirectToAction("GetTicket", "MstTemplet");
            }
            else if (Command == "UpdateUser")
            {
                //if (!string.IsNullOrEmpty(userid))
                //{
                //    UsersDTO userDTO = new UsersDTO();
                //    userDTO.EditedBy = Convert.ToInt16(Session["userid"]);
                //    userDTO.name = formvalue["Name"];
                //    userDTO.username = formvalue["Username"];
                //    userDTO.password = formvalue["Password"];
                //    // userDTO.IsActive = formvalue["Status"];
                //    userDTO.IsActive = Convert.ToBoolean(formvalue["Status"]);
                //    userDTO.RoleId = formvalue["UserRole"];
                //    // userDTO.Solution = formvalue[""];
                //    List<UsersDTO> userDTOList = new List<UsersDTO>();
                //    userDTO.userid = Convert.ToInt32(userid);
                //    userDTOList = new ITCircleBL.AplicationBL().Updateuser(userDTO);
                //    List<UsersDTO> newuserList = new ITCircleBL.AplicationBL().GetUserInfo1(new UsersDTO());
                //    return View("getUsers", newuserList);
                //}

            }
            return null;
        }


        public ActionResult GetTechComment(String SearchValue = "")
        {
            TechCommentDTO techCommnetDTO = new TechCommentDTO();
            List<TechCommentDTO> techCommentList = new List<TechCommentDTO>();
            techCommnetDTO.UserId = Convert.ToInt16(Session["userid"]);
            techCommnetDTO.SearchValue = SearchValue;
            techCommnetDTO.RoleID = Convert.ToInt32(Session["UserRole"]);

            if (string.IsNullOrEmpty(SearchValue))
                techCommentList = new ITCircleBL.AplicationBL().GetTechCommentInfo(techCommnetDTO);
            else
                techCommentList = new ITCircleBL.AplicationBL().GetTechCommentSearch(techCommnetDTO);
            return View(techCommentList);
        }

        public ActionResult FollowupComment(String TicketId = "", String CustomerId = "", String ProductId = "", string TechId = "")
        {
            FollowupComDTO followupComDTO = new FollowupComDTO();
            if (!String.IsNullOrEmpty(CustomerId))
            {
                List<CustomerDTO> CustomerList = new ITCircleBL.AplicationBL().GetCutomerInfo(new CustomerParamDTO() { CustomerID = Convert.ToInt16(CustomerId) });
                foreach (var item in CustomerList)
                {
                    item.ContanctNo = item.ContanctNo.Replace(item.ContanctNo.Substring(0, 7).ToString(), "xxxxxxx");
                    item.EmailId = item.EmailId.Replace(item.EmailId.Substring(3, item.EmailId.IndexOf('@') - 3).ToString(), "xxxxx");
                }

                ViewBag.CutomerList = CustomerList;
            }
            List<UsersDTO> usrRolesList = new ITCircleBL.AplicationBL().GetAllUsersRoleInfo();
            List<SelectListItem> assignToList = new List<SelectListItem>();
            foreach (var t in usrRolesList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.UserRoleDesc;
                s.Value = t.userid.ToString();
                assignToList.Add(s);
            }
            ViewBag.AssignTo = assignToList;
            if (!String.IsNullOrEmpty(ProductId))
            {
                List<AddProduct> ProductList = new ITCircleBL.AplicationBL().GetProduct(new AddProduct() { ProductId = Convert.ToInt16(ProductId) });

                ViewBag.ProductList = ProductList;
            }
            if (!String.IsNullOrEmpty(TicketId))
            {
                List<NewTicketDTO> Ticketlist = new ITCircleBL.AplicationBL().GetTicketInfo(new NewTicketDTO() { TicketId = Convert.ToInt32(TicketId) });
                ViewBag.TicketList = Ticketlist;
            }
            if (!String.IsNullOrEmpty(TechId))
            {
                List<TechCommentDTO> TechComList = new ITCircleBL.AplicationBL().GetTechCommentInfo(new TechCommentDTO() { TechId = Convert.ToInt16(TechId) });
                ViewBag.TechComList = TechComList;
            }

            return View(followupComDTO);
        }

        [HttpPost]
        public ActionResult FollowupComment(FormCollection formvalue, String Command = "")
        {
            if (Command == "AddStatus")
            {
                FollowupComDTO followupComDTO = new FollowupComDTO();
                followupComDTO.CreatedBy = Convert.ToInt16(Session["userid"]);
                followupComDTO.CustomerId = Convert.ToInt16(formvalue["CustomerID"]);
                followupComDTO.ProductId = Convert.ToInt16(formvalue["ProductId"]);
                followupComDTO.TicketId = formvalue["TicketId"];
                followupComDTO.TechId = Convert.ToInt16(formvalue["TechId"]);
                followupComDTO.FollowupRemark = formvalue["FollowupRemark"];
                if(formvalue["AssignTo"] == null)
                {
                    followupComDTO.AssingTo = Convert.ToInt32(Session["userid"]);
                }
                else
                {
                    followupComDTO.AssingTo = Convert.ToInt32(formvalue["AssignTo"]);
                }
                followupComDTO.TicketStatus = Convert.ToBoolean(formvalue["TicketStatus"]);
                List<FollowupComDTO> FollowupComDTOList = new List<FollowupComDTO>();

                FollowupComDTOList = new ITCircleBL.AplicationBL().InsertFollowupCom(followupComDTO);

                return RedirectToAction("GetTechComment", "MstTemplet");
            }
            else if (Command == "UpdateUser")
            {
                //if (!string.IsNullOrEmpty(userid))
                //{
                //    UsersDTO userDTO = new UsersDTO();
                //    userDTO.EditedBy = Convert.ToInt16(Session["userid"]);
                //    userDTO.name = formvalue["Name"];
                //    userDTO.username = formvalue["Username"];
                //    userDTO.password = formvalue["Password"];
                //    // userDTO.IsActive = formvalue["Status"];
                //    userDTO.IsActive = Convert.ToBoolean(formvalue["Status"]);
                //    userDTO.RoleId = formvalue["UserRole"];
                //    // userDTO.Solution = formvalue[""];
                //    List<UsersDTO> userDTOList = new List<UsersDTO>();
                //    userDTO.userid = Convert.ToInt32(userid);
                //    userDTOList = new ITCircleBL.AplicationBL().Updateuser(userDTO);
                //    List<UsersDTO> newuserList = new ITCircleBL.AplicationBL().GetUserInfo1(new UsersDTO());
                //    return View("getUsers", newuserList);
                //}

            }
            return null;
        }

        public ActionResult TicketHistory(String TicketId = "")
        {
            TicketHistoryDTO ticketHistoryDTO = new TicketHistoryDTO();
            List<TicketHistoryDTO> tickethistoryList = new List<TicketHistoryDTO>();
            ticketHistoryDTO.TicketId = TicketId;
            if (!string.IsNullOrEmpty(TicketId))
            {
                tickethistoryList = new ITCircleBL.AplicationBL().GetTicketHistory(ticketHistoryDTO);
            }


            return View(tickethistoryList);
        }

        public ActionResult GetTicketHistory(String SearchValue="")
        {
            NewTicketDTO NewticketDTO = new NewTicketDTO();
            List<NewTicketDTO> TicketList = new List<NewTicketDTO>();
            NewticketDTO.SearchValue = SearchValue;
            NewticketDTO.UserId = Convert.ToInt16(Session["userid"]);
            NewticketDTO.RoleID = Convert.ToInt32(Session["UserRole"]);
            if (string.IsNullOrEmpty(SearchValue))
                TicketList = new ITCircleBL.AplicationBL().GetTicketInfo(NewticketDTO);
            else
                TicketList = new ITCircleBL.AplicationBL().GetTicketSearch(NewticketDTO);
            return View(TicketList);
        }

    }

}
