using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDTO;

namespace ITCircleBL
{
    public class AplicationBL
    {
        public List<UsersDTO> GetUserInfo(UsersDTO usersDTO)
        {
             return new ITCircleDAO.ApplicationDAO().GetUserInfo(usersDTO);
           // return new ITCircleDAO.ApplicationDAO.GetUserInfo(usersDTO);
        }

        public List<UsersDTO> GetUserInfo1(UsersDTO usersDTO)
        {
            return new ITCircleDAO.ApplicationDAO().GetUserInfo1(usersDTO);
        }

        public List<CustomerDTO> InsertCustomerInfo(CustomerDTO CustomerDTO)
        {
            return new ITCircleDAO.ApplicationDAO().InsertCustomerInfo(CustomerDTO);
        }
        public List<CustomerDTO> GetCutomerInfo(CustomerParamDTO customerParamDTO)
        {
            return new ITCircleDAO.ApplicationDAO().GetCutomerInfo(customerParamDTO);
        }
        public List<NewTicketDTO> InsertNewTicket(NewTicketDTO NewTicketDTO)
        {
            return new ITCircleDAO.ApplicationDAO().InsertNewTicket(NewTicketDTO);
        }
        public List<UsersDTO> Insertuser(UsersDTO userDTO)
        {
            return new ITCircleDAO.ApplicationDAO().Insertuser(userDTO);
        }
        public List<NewTicketDTO> GetTicketInfo(NewTicketDTO NewTicketDTO)
        {
            return new ITCircleDAO.ApplicationDAO().GetTicketInfo(NewTicketDTO);
        }
        public List<CustomerDTO> updateCustomer(CustomerDTO CustomerDTO)
        {
            return new ITCircleDAO.ApplicationDAO().updateCustomer(CustomerDTO);
        }

        public List<UsersDTO> Updateuser(UsersDTO userDTO)
        {
            return new ITCircleDAO.ApplicationDAO().updateuser(userDTO);
        }
        public List<CustomerDTO> deleteCustomerinfo(CustomerDTO CustomerDTO)
        {
            return new ITCircleDAO.ApplicationDAO().deleteCustomerinfo(CustomerDTO);
        }

        public List<UsersDTO> deleteUserinfo(UsersDTO UsersDTO)
        {
            return new ITCircleDAO.ApplicationDAO().deleteUserinfo(UsersDTO);
        }
        public List<NewTicketDTO> deleteTicketinfo(NewTicketDTO NewTicketDTO)
        {
            return new ITCircleDAO.ApplicationDAO().deleteTicketinfo(NewTicketDTO);
        }

        public List<CustomerDTO> UpdateCustomerInfo(CustomerDTO CustomerDTO)
        {
            return new ITCircleDAO.ApplicationDAO().updateCustomer(CustomerDTO);
        }

        public List<NewTicketDTO> updateTicket(NewTicketDTO NewticketDTO)
        {
            return new ITCircleDAO.ApplicationDAO().updateTicket(NewticketDTO);
        }

        public List<CustomerDTO> DropDownCustomer(CustomerDTO customerDTO)
        {
            return new ITCircleDAO.ApplicationDAO().getDropDownvalues(customerDTO);
        }

        public List<MasterUserRole> getUserRole(MasterUserRole MasterUserRole)
        {
            return new ITCircleDAO.ApplicationDAO().GetUserRoleInfo(MasterUserRole);
        }

        public List<MasterCallType> getCallType(MasterCallType masterCallType)
        {
            return new ITCircleDAO.ApplicationDAO().GetCallTypeInfo(masterCallType);
        }

        public List<MasterSubcallType> getSubCallType(MasterSubcallType masterSubcallType)
        {
            return new ITCircleDAO.ApplicationDAO().GetSubCallType(masterSubcallType);
        }

        public List<MasterPayment> GetPaymentList(MasterPayment masterPayment)
        {
            return new ITCircleDAO.ApplicationDAO().GetPaymentList(masterPayment);
        }

        public List<MasterSubcriptionType> GetSubcriptionType(MasterSubcriptionType masterSubcriptionType)
        {
            return new ITCircleDAO.ApplicationDAO().GetSubcriptionType(masterSubcriptionType);
        }

        public List<MasterProduct> GetProduct(MasterProduct materProduct)
        {
            return new ITCircleDAO.ApplicationDAO().GetProduct(materProduct);
        }

        public List<MasterState> GetState(MasterState masterState)
        {
            return new ITCircleDAO.ApplicationDAO().GetState(masterState);
        }

        public List<MasterCity> GetCity(MasterCity masterCity)
        {
            return new ITCircleDAO.ApplicationDAO().GetCity(masterCity);
        }

        public List<MasterRefundType> GetRefundeList(MasterRefundType masterRefundType)
        {
            return new ITCircleDAO.ApplicationDAO().GetRefundeList(masterRefundType);
        }

        public List<MasterCallStatus> getCallStatusList(MasterCallStatus masterCallStatus)
        {
            return new ITCircleDAO.ApplicationDAO().GetCallStatus(masterCallStatus);
        }

        public List<UsersDTO> GetAllUsersRoleInfo()
        {
            return new ITCircleDAO.ApplicationDAO().GetAllUsersRoleInfo();
        }

        public List<AddProduct> GetProductInfo(AddProduct addProduct)
        {
            return new ITCircleDAO.ApplicationDAO().GetProductInfo(addProduct);
        }

        public List<AddProduct> insertProduct(AddProduct addProduct)
        {
            return new ITCircleDAO.ApplicationDAO().insertProductInfo(addProduct);
        }


        public List<AddProduct> GetProduct(AddProduct addProduct)
        {
            return new ITCircleDAO.ApplicationDAO().getProductInfo(addProduct);
        }

        public List<AddProduct> UpdateProduct(AddProduct ProductDTO)
        {
            return new ITCircleDAO.ApplicationDAO().updateProduct(ProductDTO);
        }



        public List<CustomerDTO> GetCustomerSearch(CustomerParamDTO CustomerParamDTO)
        {
            return new ITCircleDAO.ApplicationDAO().CustomerSearch(CustomerParamDTO);
        }

        public List<AddProduct> GetProductSearch(AddProduct AddProduct)
        {
            return new ITCircleDAO.ApplicationDAO().ProductSearch(AddProduct);
        }

        public List<NewTicketDTO> GetTicketSearch(NewTicketDTO NewTicketDTO)
        {
            return new ITCircleDAO.ApplicationDAO().TicketSearch(NewTicketDTO);
        }

        public List<UsersDTO> GetUserSearch(string SearchValue)
        {
            return new ITCircleDAO.ApplicationDAO().UserSearch(SearchValue);
        }

        public List<TechCommentDTO> InserttechComment(TechCommentDTO techCommentDTO)
        {
            return new ITCircleDAO.ApplicationDAO().techComment(techCommentDTO);
        }

        public List<TechCommentDTO> GetTechCommentInfo(TechCommentDTO techCommnetDTO)
        {
            return new ITCircleDAO.ApplicationDAO().gettechComment(techCommnetDTO);
        }

        public List<TechCommentDTO> GetTechCommentSearch(TechCommentDTO techCommnetDTO)
        {
            return new ITCircleDAO.ApplicationDAO().gettechCommentSearch(techCommnetDTO);
        }

        public List<FollowupComDTO> InsertFollowupCom(FollowupComDTO followupComDTO)
        {
            return new ITCircleDAO.ApplicationDAO().Followupcom(followupComDTO);
        }

        public List<TicketHistoryDTO> GetTicketHistory(TicketHistoryDTO ticketHistoryDTO)
        {
            return new ITCircleDAO.ApplicationDAO().getTicketHistory(ticketHistoryDTO);
        }
    }
}
