namespace Eskool.Code.SessionManager
{
    /// <summary>
    /// Summary description for SessionInfo
    /// </summary>
    public  class SessionInfo
    {
        


        string _userId;
        string _userSapId; 
        string _userCellPhone;
        string _userName;
        string _designationCode;
        int _roleId;
        string _roleName;
        




        public SessionInfo()
        {
        }


        #region Users
        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        } 
        
        public string UserCellPhone
        {
            get
            {
                return _userCellPhone;
            }
            set
            {
                _userCellPhone = value;
            }
        } 
        public string UserSAPId
        {
            get
            {
                return _userSapId;
            }
            set
            {
                _userSapId = value;
            }
        }

        

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        } 
        
        public string DesignationCode
        {
            get
            {
                return _designationCode;
            }
            set
            {
                _designationCode = value;
            }
        }

      

        public int RoleId
        {
            get
            {
                return _roleId;
            }
            set
            {
                _roleId = value;
            }
        }

        public string RoleName
        {
            get
            {
                return _roleName;
            }
            set
            {
                _roleName = value;
            }
        }

       
        #endregion

    }
}
