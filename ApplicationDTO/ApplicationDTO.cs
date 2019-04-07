using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDTO
{
    public class ApplicationDTO
    {

    }
    public class UsersDTO
    {
        public int userid { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool IsActive { get; set; }
        public string RoleId { get; set; }
        public String UserRole { get; set; }
        public string UserRoleDesc { get; set; }
        public int CreatedBy { get; set; }
        public int EditedBy { get; set; }
        public DateTime UserRegDate { get; set; }
        public DateTime UserUpdDate { get; set; } 
    }
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContanctNo { get; set; }
        public String EmailId { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public String AccountNo { get; set; }
        public int  CreatedBy { get; set;}
        public int  EditedBy { get; set; }
        public string SearchValue { get; set;}
        public DateTime CutomerRegDate { get; set; }
        public DateTime CutomerUpdDate { get; set; }
        public string Username { get; set; }
        
    }

    public class CustomerParamDTO
    {
        public int CustomerID { get; set; }
        public int CreatedBy { get; set; }
        public int RoleID { get; set; }
        public string SearchValue { get; set; }

    }

    public class NewTicketDTO
    {
        public int Id { get; set; }
        public String TicketNo { get; set; }
        public DateTime CampaintDate { get; set; }
        public String RefundReason { get; set; }
        public String RefundType { get; set; }
        public String Solution { get; set; }
        public String CustomerId { get; set; }
        public String ProductId { get; set; }
        public String AssignTo { get; set; }
        public String AccountNo { get; set; }
        public String CustomerName { get; set;}
        public String ProductName { get; set; }
        public String ContanctNo { get; set; }
        public int UserId { get; set; }
        public String SearchValue { get; set; }
        public int CreatedBy { get; set; }
        public int EditedBy { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public int TicketId { get; set; }
    }
    public class MasterUserRole
    {
        public int RoleId { get; set; }
        public String RoleName { get; set; }
        public String RoleType { get; set; }
    }
    public class MasterCallType
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String  Description { get; set; }
    }
    public class MasterCallStatus
    {
        public int id { get; set; }
        public String CallStatusName { get; set; }
        public String Description { get; set; }
    }
    public class MasterPayment
    {
        public int Id { get; set;}
        public String PaymentName { get; set; }
        public String Description { get; set; }
    }
    public class MasterSubcallType
    {
        public int Id { get; set; }
        public String SubCallName { get; set; }
        public String Description { get; set; }
    }
    public class MasterSubcriptionType
    {
        public int Id { get; set; }
        public String SubcriptionName { get; set; }
        public String Description { get; set; }
    }
    public class MasterState
    {
        public int StateId { get; set; }
        public String Statename { get; set; }
        public String Description { get; set; }
        public int CountryId { get; set; }
    }
    public class MasterCity
    {
        public int CityId { get; set; }
        public String Cityname { get; set; }
        public String Description { get; set; }
        public int StateId { get; set; }
    }
    public class MasterRefundType
    {
        public int Id { get; set; }
        public String RefundTypeName { get; set; }
        public String Description { get; set; }
    }
    public class MasterProduct
    {
        public int ProductId { get; set; }
        public String Productname { get; set; }
        public String Description { get; set; }
        
    }
    public class AddProduct
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public String Product { get; set; }
        public String CallType { get; set; }
        public String SubCallType { get; set; }
        public String NoOfSystem { get; set; }
        public String SubcriptionType { get; set; }
        public String PaymentMode { get; set; }
        public String CallStatus { get; set; }
        public String AssignTo { get; set; }
        public String Remark { get; set; }
        public String WorkOrderNumber { get; set; }
        public String AccountNo { get; set; }
        public int UserId { get; set;}
        public String SearchValue { get; set; }
        public DateTime salesDate { get; set; }
        public DateTime ProductUpdDate { get; set; }
        public int CreatedBy { get; set; }
        public int EditedBy { get; set; }
        public int RoleId { get; set; }
        public String TicketNo { get; set; }
    }
    public class TechCommentDTO
    {
       public int TechId { get; set; }
        public int CreatedBy { get; set; }
        public int EditedBy { get; set; }
        public String TechDisposition { get; set; }
        public String AssingTo { get; set; }
      public  String TechSolution { get; set; }
       public String TechRemark { get; set; }
       public int TicketId { get; set; }
       public int CustomerId { get; set; }
       public int ProductId { get; set; }
       public String Username { get; set; }
       public String AccountNo { get; set; }
       public String ContanctNo { get; set; }
       public DateTime CampaintDate { get; set; }
       public int  UserId { get; set; }

       public string SearchValue { get; set; }

       public int RoleID { get; set; }

       public String CustomerName { get; set; }

       public String WorkOrderNumber { get; set; }

       public String TicketNo { get; set; }

       public int Id { get; set; }
    }


    public class FollowupComDTO
    {
        public int FollowupId { get; set; }
        public int CreatedBy { get; set; }
        public int EditedBy { get; set; }
        public int AssingTo { get; set; }
        public String FollowupRemark { get; set; }
        public String TicketId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int TechId { get; set; }
        public short UserId { get; set; }
        public string SearchValue { get; set; }
        public int RoleID { get; set; }
        public String CustomerName { get; set; }
        public String WorkOrderNumber { get; set; }
        public String TicketNo { get; set; }
        public bool TicketStatus { get; set; }
        

        
    }
    public class TicketHistoryDTO
    {
        public int  Id { get; set; }
        public String TicketId { get; set; }
        public String Name { get; set; }
        public String Remark { get; set;}
        public String Solution { get; set; }
        public String RefundReason { get; set; }
        public String DispositionType { get; set; }
        public String CreatedBy { get; set; }
    }
   
}
