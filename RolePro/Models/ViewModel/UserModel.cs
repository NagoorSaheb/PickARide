using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace RolePro.Models.ViewModel
{
    public class UserSignUpView
    {
        [Key]
        public int SYSUserID { get; set; }
        public int LOOKUPRoleID { get; set; }
        public string RoleName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email Id")]
        public string emailId { get; set; }
        public string Gender { get; set; }
    }


    public class UserRequestRideView
    {
        [Key]

        [Required(ErrorMessage = "*")]
        public string SYSUserId { get; set; }
        public string loginName { get; set; }

        [Required(ErrorMessage = "*")]
        public string NumberOfPersons { get; set; }
        [Display(Name = "Additional Contact Number")]
        public string AddPhoneNumber { get; set; }
        [Display(Name = "Estimated Charge")]
        public string Charge{ get; set; }
        public string Comments { get; set; }
        [Display(Name = "Status")]
        public string RequestStatus { get; set; }
       
    }



    public class UserLoginView
    {
        [Key]
        public int SYSUserID { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class UserProfileView
    {
        [Key]
        public int SYSUserID { get; set; }
        public int LOOKUPRoleID { get; set; }
        public string RoleName { get; set; }
        public bool? IsRoleActive { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
          [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email Id")]
        public string emailId { get; set; }
        public string Gender { get; set; }
    }

    public class LOOKUPAvailableRole
    {
        [Key]
        public int LOOKUPRoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }

    public class Gender
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class UserRoles
    {
        public int? SelectedRoleID { get; set; }
        public IEnumerable<LOOKUPAvailableRole> UserRoleList { get; set; }
    }

    public class UserGender
    {
        public string SelectedGender { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
    }

    public class UserDataView
    {
        public IEnumerable<UserProfileView> UserProfile { get; set; }
        public UserRoles UserRoles { get; set; }
        public UserGender UserGender { get; set; }
    }

}