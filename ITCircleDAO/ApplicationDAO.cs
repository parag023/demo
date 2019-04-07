using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDTO;
using Dapper;

namespace ITCircleDAO
{
    public class ApplicationDAO
    {

        public List<UsersDTO> GetUserInfo(UsersDTO usersDTO)
        {
            List<UsersDTO> userList = new List<UsersDTO>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
            DynamicParameters p = new DynamicParameters();
            p.Add("@username", usersDTO.username);
            p.Add("@password", usersDTO.password);
            userList = con.Query<UsersDTO>("GetUsersInfo", p, commandType: CommandType.StoredProcedure).ToList();
            return userList;
        }

        public List<UsersDTO> GetUserInfo1(UsersDTO usersDTO)
        {
            List<UsersDTO> userList = new List<UsersDTO>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
            userList = con.Query<UsersDTO>("GetUsersInfo1", null, commandType: CommandType.StoredProcedure).ToList();
            // userList = userList.Where(s => s.username.Equals() && s.password.Equals(usersDTO.password)).FirstOrDefault();
            // usersDTO.userid = Convert.ToInt32(Id);
            return userList;
        }


        public List<CustomerDTO> InsertCustomerInfo(CustomerDTO CustomerDTO)
        {
            try
            {
                List<CustomerDTO> userList = new List<CustomerDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters P = new DynamicParameters();
                P.Add("@Customername", CustomerDTO.CustomerName);
                P.Add("@ContactNo", CustomerDTO.ContanctNo);
                P.Add("@EmailId", CustomerDTO.EmailId);
                P.Add("@State", CustomerDTO.State);
                P.Add("@City", CustomerDTO.City);
                P.Add("@AccountNo", CustomerDTO.AccountNo);
                P.Add("@CreatedBy", CustomerDTO.CreatedBy);

                //  P.Add("@Id", CustomerDTO.CustomerId.Equals(-1));
                con.Execute("insertCustomer", P, commandType: CommandType.StoredProcedure);
                return userList;
            }
            catch(SqlException sqex)
            {
                if (sqex.Number == 2601) {
                    throw sqex;
                }
                else {
                    return null;
                }
            }

        }
        public List<CustomerDTO> updateCustomer(CustomerDTO CustomerDTO)
        {
            try
            {
                List<CustomerDTO> userList = new List<CustomerDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters P = new DynamicParameters();
                P.Add("@Customername", CustomerDTO.CustomerName);
                P.Add("@ContactNo", CustomerDTO.ContanctNo);
                P.Add("@EmailId", CustomerDTO.EmailId);
                P.Add("@State", CustomerDTO.State);
                P.Add("@City", CustomerDTO.City);
                P.Add("@AccountNo", CustomerDTO.AccountNo);
                P.Add("@Customerid", CustomerDTO.CustomerId);
                P.Add("@EditedBy", CustomerDTO.EditedBy);
                con.Execute("updateCustomer", P, commandType: CommandType.StoredProcedure);
                return userList;
                // return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<CustomerDTO> GetCutomerInfo(CustomerParamDTO customerParamDTO)
        {
            try
            {
                List<CustomerDTO> GetCustomerInfo = new List<CustomerDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@CustomerID", value: customerParamDTO.CustomerID);
                p.Add("@RoleID", value: customerParamDTO.RoleID);
                p.Add("@CreatedBy", customerParamDTO.CreatedBy);
                GetCustomerInfo = con.Query<CustomerDTO>("GetCutomerInfo", p, commandType: CommandType.StoredProcedure).ToList();
                return GetCustomerInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<NewTicketDTO> InsertNewTicket(NewTicketDTO NewTicketDTO)
        {
            try
            {
                List<NewTicketDTO> ticketlist = new List<NewTicketDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters P = new DynamicParameters();

                P.Add("TicketId", NewTicketDTO.TicketId);
                P.Add("@TicketNo", NewTicketDTO.TicketNo);
                P.Add("@RefundReason", NewTicketDTO.RefundReason);
                P.Add("@RefundType", NewTicketDTO.RefundType);
                P.Add("@Solution", NewTicketDTO.Solution);
                P.Add("@AssignTo", NewTicketDTO.AssignTo);
                P.Add("@CustomerId", NewTicketDTO.CustomerId);
                P.Add("@ProductId", NewTicketDTO.ProductId);
                P.Add("@CreatedBy", NewTicketDTO.CreatedBy);
                con.Execute("NewTicket", P, commandType: CommandType.StoredProcedure);
                return ticketlist;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<UsersDTO> Insertuser(UsersDTO userDTO)
        {
            try
            {
                List<UsersDTO> userList = new List<UsersDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters P = new DynamicParameters();
                P.Add("@name", userDTO.name);
                P.Add("@username", userDTO.username);
                P.Add("@password", userDTO.password);
                P.Add("@status", userDTO.IsActive);
                P.Add("@Userrole", userDTO.RoleId);
                P.Add("@CreatedBy", userDTO.CreatedBy);
                con.Execute("InsertUser", P, commandType: CommandType.StoredProcedure);
                return userList;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<UsersDTO> updateuser(UsersDTO userDTO)
        {
            try
            {

                List<UsersDTO> userList = new List<UsersDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters P = new DynamicParameters();
                P.Add("@Name", userDTO.name);
                P.Add("@username", userDTO.username);
                P.Add("@password", userDTO.password);
                P.Add("@status", userDTO.IsActive);
                P.Add("@Role", userDTO.RoleId);
                P.Add("@userId", userDTO.userid);
                P.Add("@EditedBy", userDTO.EditedBy);
                con.Execute("updateuser", P, commandType: CommandType.StoredProcedure);
                return userList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<NewTicketDTO> GetTicketInfo(NewTicketDTO NewTicketDTO)
        {
            try
            {
                List<NewTicketDTO> GetTicketInfomation = new List<NewTicketDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@userid", NewTicketDTO.UserId);
                p.Add("@id",value:NewTicketDTO.TicketId);
                p.Add("@RoleID", NewTicketDTO.RoleID);

                GetTicketInfomation = con.Query<NewTicketDTO>("GetTicketInfo", p, commandType: CommandType.StoredProcedure).ToList();
                return GetTicketInfomation;
            }
            catch (Exception ex)
            {
                return new List<NewTicketDTO>();
            }

        }

        public List<CustomerDTO> deleteCustomerinfo(CustomerDTO CustomerDTO)
        {
            try
            {
                List<CustomerDTO> customerList = new List<CustomerDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@CustomerId", CustomerDTO.CustomerId);
                //customerList = con.Query<CustomerDTO>("deleteCustomer", p, commandType: CommandType.StoredProcedure).ToList();
                con.Execute("deleteCustomer", p, commandType: CommandType.StoredProcedure);
                return customerList;

            }
            catch (Exception ex)
            {
                return new List<CustomerDTO>();
            }
        }

        public List<UsersDTO> deleteUserinfo(UsersDTO UsersDTO)
        {
            try
            {
                List<UsersDTO> userList = new List<UsersDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@userid", UsersDTO.userid);
                //userList = con.Excute<CustomerDTO>("deleteCustomer", p, commandType: CommandType.StoredProcedure).ToList();
                con.Execute("deleteuser", p, commandType: CommandType.StoredProcedure);
                return userList;

            }
            catch (Exception ex)
            {
                return new List<UsersDTO>(); ;
            }
        }

        public List<NewTicketDTO> deleteTicketinfo(NewTicketDTO NewTicketDTO)
        {
            try
            {
                List<NewTicketDTO> TicketList = new List<NewTicketDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@id", NewTicketDTO.Id);
                //userList = con.Excute<CustomerDTO>("deleteCustomer", p, commandType: CommandType.StoredProcedure).ToList();
                con.Execute("deleteTicket", p, commandType: CommandType.StoredProcedure);
                return TicketList;
            }
            catch (Exception ex)
            {
                return new List<NewTicketDTO>();
            }
        }

        public List<NewTicketDTO> updateTicket(NewTicketDTO NewticketDTO)
        {
            try
            {
                List<NewTicketDTO> userList = new List<NewTicketDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters P = new DynamicParameters();
                P.Add("@RefundReason", NewticketDTO.RefundReason);
                P.Add("@RefundType", NewticketDTO.RefundType);
                P.Add("@Solution", NewticketDTO.Solution);
                P.Add("@AssignTo", NewticketDTO.AssignTo);
                P.Add("@Editedby", NewticketDTO.EditedBy);
                P.Add("@id", NewticketDTO.Id);
                con.Execute("updateTicket", P, commandType: CommandType.StoredProcedure);
                return userList;
            }
            catch (Exception ex)
            {
                return new List<NewTicketDTO>(); ;
            }
        }

        public List<CustomerDTO> getDropDownvalues(CustomerDTO customerDTO)
        {
            return null;
        }

        public List<MasterUserRole> GetUserRoleInfo(MasterUserRole masterUserRole)
        {
            try
            {
                List<MasterUserRole> userroleList = new List<MasterUserRole>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                userroleList = con.Query<MasterUserRole>("GetUserRoleInfo", null, commandType: CommandType.StoredProcedure).ToList();


                return userroleList;
            }
            catch (Exception ex)
            {
                return new List<MasterUserRole>(); ;
            }
        }


        public List<MasterCallType> GetCallTypeInfo(MasterCallType masterCallType)
        {
            try
            {
                List<MasterCallType> CalltypeList = new List<MasterCallType>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                CalltypeList = con.Query<MasterCallType>("GetCallTypeInfo", null, commandType: CommandType.StoredProcedure).ToList();


                return CalltypeList;
            }
            catch (Exception ex)
            {
                return new List<MasterCallType>(); ;
            }
        }

        public List<MasterSubcallType> GetSubCallType(MasterSubcallType masterSubcallType)
        {
            try
            {
                List<MasterSubcallType> SubCalltypeList = new List<MasterSubcallType>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                SubCalltypeList = con.Query<MasterSubcallType>("GetSubCallTypeInfo", null, commandType: CommandType.StoredProcedure).ToList();


                return SubCalltypeList;
            }
            catch (Exception ex)
            {
                return new List<MasterSubcallType>(); ;
            }
        }

        public List<MasterPayment> GetPaymentList(MasterPayment masterPayment)
        {
            try
            {
                List<MasterPayment> SubCalltypeList = new List<MasterPayment>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                SubCalltypeList = con.Query<MasterPayment>("GetPaymentInfo", null, commandType: CommandType.StoredProcedure).ToList();


                return SubCalltypeList;
            }
            catch (Exception ex)
            {
                return new List<MasterPayment>(); ;
            }

        }

        public List<MasterSubcriptionType> GetSubcriptionType(MasterSubcriptionType masterSubcriptionType)
        {
            try
            {
                List<MasterSubcriptionType> SubcriptionTypeList = new List<MasterSubcriptionType>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                SubcriptionTypeList = con.Query<MasterSubcriptionType>("GetSubcriptionTypeinfo", null, commandType: CommandType.StoredProcedure).ToList();


                return SubcriptionTypeList;
            }
            catch (Exception ex)
            {
                return new List<MasterSubcriptionType>(); ;
            }
        }

        public List<MasterProduct> GetProduct(MasterProduct materProduct)
        {
            try
            {
                List<MasterProduct> ProductList = new List<MasterProduct>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                ProductList = con.Query<MasterProduct>("GetProductList", null, commandType: CommandType.StoredProcedure).ToList();


                return ProductList;
            }
            catch (Exception ex)
            {
                return new List<MasterProduct>(); ;
            }
        }

        public List<MasterState> GetState(MasterState masterState)
        {
            try
            {
                List<MasterState> StateList = new List<MasterState>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                StateList = con.Query<MasterState>("GetStateList", null, commandType: CommandType.StoredProcedure).ToList();


                return StateList;
            }
            catch (Exception ex)
            {
                return new List<MasterState>(); ;
            }
        }

        public List<MasterCity> GetCity(MasterCity masterCity)
        {
            try
            {
                List<MasterCity> CityList = new List<MasterCity>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                CityList = con.Query<MasterCity>("GetCityList", null, commandType: CommandType.StoredProcedure).ToList();


                return CityList;
            }
            catch (Exception ex)
            {
                return new List<MasterCity>(); ;
            }
        }

        public List<MasterRefundType> GetRefundeList(MasterRefundType masterRefundType)
        {
            try
            {
                List<MasterRefundType> RefundeList = new List<MasterRefundType>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                RefundeList = con.Query<MasterRefundType>("GetRefundeList", null, commandType: CommandType.StoredProcedure).ToList();


                return RefundeList;
            }
            catch (Exception ex)
            {
                return new List<MasterRefundType>(); 
            }
        }

        public List<MasterCallStatus> GetCallStatus(MasterCallStatus masterCallStatus)
        {
            try
            {
                List<MasterCallStatus> CallStatusList = new List<MasterCallStatus>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                CallStatusList = con.Query<MasterCallStatus>("GetCallStatus", null, commandType: CommandType.StoredProcedure).ToList();


                return CallStatusList;
            }
            catch (Exception ex)
            {
                return new List<MasterCallStatus>();
            }
        }

        public List<UsersDTO> GetAllUsersRoleInfo()
        {
            try
            {
                List<UsersDTO> UsersDTOList = new List<UsersDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                //DynamicParameters p = new DynamicParameters();
                UsersDTOList = con.Query<UsersDTO>("GetAllUsersRoleInfo", null, commandType: CommandType.StoredProcedure).ToList();


                return UsersDTOList;
            }
            catch (Exception ex)
            {
                return new List<UsersDTO>();
            }
        }

        public List<AddProduct> insertProductInfo(AddProduct addProduct)
        {
            try
            {
                List<AddProduct> ProductList = new List<AddProduct>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters P = new DynamicParameters();
                P.Add("@Product", addProduct.Product);
                P.Add("@CallType", addProduct.CallType);
                P.Add("@SubCallType", addProduct.SubCallType);
                P.Add("@NoOfSystem", addProduct.NoOfSystem);
                P.Add("@SubcriptionType", addProduct.SubcriptionType);
                P.Add("@PaymentMode", addProduct.PaymentMode);
                P.Add("@CallStatus", addProduct.CallStatus);
                P.Add("@AssignTo", addProduct.AssignTo);
                P.Add("@remark", addProduct.Remark);
                P.Add("@WorkOrderNumber", addProduct.WorkOrderNumber);
                P.Add("@CustomerId", addProduct.CustomerId);
                P.Add("@AccountNo", addProduct.AccountNo);
                P.Add("@CreateBy", addProduct.CreatedBy);
                //  P.Add("@Id", CustomerDTO.CustomerId.Equals(-1));
                con.Execute("insertProduct", P, commandType: CommandType.StoredProcedure);
                return ProductList;
            }
            catch
            {
                return new List<AddProduct>();
            }
        }

        public List<AddProduct> GetProductInfo(AddProduct addProduct)
        {
            return null;
        }

        public List<AddProduct> getProductInfo(AddProduct addProduct)
        {
            try
            {
                List<AddProduct> Productlist = new List<AddProduct>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@userId", addProduct.UserId);
                p.Add("@Productid", value: addProduct.ProductId);
                p.Add("@RoleId", addProduct.RoleId);
                Productlist = con.Query<AddProduct>("GetProduct", p, commandType: CommandType.StoredProcedure).ToList();


                return Productlist;
            }
            catch (Exception ex)
            {
                return new List<AddProduct>(); ;
            }
        }

        public List<AddProduct> updateProduct(AddProduct ProductDTO)
        {
            try
            {
                List<AddProduct> productList = new List<AddProduct>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters P = new DynamicParameters();
                P.Add("@Product", ProductDTO.Product);
                P.Add("@CallType", ProductDTO.CallType);
                P.Add("@SubCallType", ProductDTO.SubCallType);
                P.Add("@NoOfSystem", ProductDTO.NoOfSystem);
                P.Add("@SubcriptionType", ProductDTO.SubcriptionType);
                P.Add("@PaymentMode", ProductDTO.PaymentMode);
                P.Add("@CallStatus", ProductDTO.CallStatus);
                P.Add("@remark", ProductDTO.Remark);
                P.Add("@AssignTo", ProductDTO.AssignTo);
                P.Add("@ProductId", ProductDTO.ProductId);
                P.Add("@EditedBy", ProductDTO.EditedBy);
                P.Add("@TicketNo", ProductDTO.TicketNo);
                con.Execute("updateProduct", P, commandType: CommandType.StoredProcedure);
                return productList;
                // return null;
            }
            catch (Exception ex)
            {
                return new List<AddProduct>();
            }
        }

        public List<CustomerDTO> CustomerSearch(CustomerParamDTO customerParamDTO)
        {
            try
            {
                List<CustomerDTO> CustomerList = new List<CustomerDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@SearchValue", customerParamDTO.SearchValue);
                p.Add("@CreatedBy", customerParamDTO.CreatedBy);
                CustomerList = con.Query<CustomerDTO>("Search_CustomerDetail", p, commandType: CommandType.StoredProcedure).ToList();


                return CustomerList;
            }
            catch (Exception ex)
            {
                return new List<CustomerDTO>();
            }
        }

        public List<AddProduct> ProductSearch(AddProduct AddProduct)
        {
            try
            {
                List<AddProduct> ProductList = new List<AddProduct>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@userid", AddProduct.UserId);
                p.Add("@SearchValue", AddProduct.SearchValue);
                p.Add("@RoleId", AddProduct.RoleId);
                ProductList = con.Query<AddProduct>("Search_SalesDetail", p, commandType: CommandType.StoredProcedure).ToList();


                return ProductList;
            }
            catch (Exception ex)
            {
                return new List<AddProduct>();
            }
        }

        public List<NewTicketDTO> TicketSearch(NewTicketDTO NewTicketDTO)
        {
            try
            {
                List<NewTicketDTO> TicketList = new List<NewTicketDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@SearchValue", NewTicketDTO.SearchValue);
                p.Add("@userid", NewTicketDTO.UserId);
                p.Add("@RoleId", NewTicketDTO.RoleID);
                TicketList = con.Query<NewTicketDTO>("Search_TicketDetail", p, commandType: CommandType.StoredProcedure).ToList();


                return TicketList;
            }
            catch (Exception ex)
            {
                return new List<NewTicketDTO>();
            }
        }

        public List<UsersDTO> UserSearch(string SearchValue)
        {
            try
            {
                List<UsersDTO> UserList = new List<UsersDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@SearchValue", SearchValue);

                UserList = con.Query<UsersDTO>("Search_UserDetail", p, commandType: CommandType.StoredProcedure).ToList();


                return UserList;
            }
            catch (Exception ex)
            {
                return new List<UsersDTO>(); 
            } 
        }

        public List<TechCommentDTO> techComment(TechCommentDTO techCommentDTO)
        {
            try
            {
                List<TechCommentDTO> techCommentList = new List<TechCommentDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@CreatedBy", techCommentDTO.CreatedBy);
                p.Add("@CustomerId", techCommentDTO.CustomerId);
                p.Add("@TicketId", techCommentDTO.TicketId);
                p.Add("@ProductId", techCommentDTO.ProductId);
                p.Add("@TechRemark", techCommentDTO.TechRemark);
                p.Add("@TechSolution",techCommentDTO.TechSolution);
                p.Add("@TechDisposition",techCommentDTO.TechDisposition);
                p.Add("@AssingTo", techCommentDTO.AssingTo);
                techCommentList = con.Query<TechCommentDTO>("InsertTechComment", p, commandType: CommandType.StoredProcedure).ToList();
                return techCommentList;
            }
            catch(Exception ex)
            {
                return new List<TechCommentDTO>();
            }
        }

        public List<TechCommentDTO> gettechComment(TechCommentDTO techCommnetDTO)
        {
            try
            {
                List<TechCommentDTO> GetTechComment = new List<TechCommentDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@userid", techCommnetDTO.UserId);
                p.Add("@TechId", value: techCommnetDTO.TechId);
                p.Add("@RoleID", techCommnetDTO.RoleID);

                GetTechComment = con.Query<TechCommentDTO>("gettechComment", p, commandType: CommandType.StoredProcedure).ToList();
                return GetTechComment;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
        }

        public List<TechCommentDTO> gettechCommentSearch(TechCommentDTO techCommnetDTO)
        {
            try
            {
                List<TechCommentDTO> TechCommentList = new List<TechCommentDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@SearchValue", techCommnetDTO.SearchValue);
                p.Add("@userid", techCommnetDTO.UserId);
                p.Add("@RoleId", techCommnetDTO.RoleID);
                TechCommentList = con.Query<TechCommentDTO>("Search_techComment", p, commandType: CommandType.StoredProcedure).ToList();


                return TechCommentList;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public List<FollowupComDTO> Followupcom(FollowupComDTO followupComDTO)
        {
            try
            {
                List<FollowupComDTO> FollowupcomList = new List<FollowupComDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@CreatedBy", followupComDTO.CreatedBy);
                p.Add("@CustomerId", followupComDTO.CustomerId);
                p.Add("@TicketId", followupComDTO.TicketId);
                p.Add("@ProductId", followupComDTO.ProductId);
                p.Add("@TechId", followupComDTO.TechId);
                p.Add("@FollowupRemark", followupComDTO.FollowupRemark);
                p.Add("@TicketStatus", followupComDTO.TicketStatus);
                p.Add("@AssignTo", followupComDTO.AssingTo);
                
                
                FollowupcomList = con.Query<FollowupComDTO>("InsertFollowupCom", p, commandType: CommandType.StoredProcedure).ToList();
                return FollowupcomList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TicketHistoryDTO> getTicketHistory(TicketHistoryDTO ticketHistoryDTO)
        {
            try
            {
                List<TicketHistoryDTO> TicketHistoyList = new List<TicketHistoryDTO>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConString"].ToString());
                DynamicParameters p = new DynamicParameters();
                p.Add("@Id", ticketHistoryDTO.TicketId);
                TicketHistoyList = con.Query<TicketHistoryDTO>("GetTicketHistoy", p, commandType: CommandType.StoredProcedure).ToList();
                return TicketHistoyList;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}

