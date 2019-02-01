using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.AdapterProxyInterfaces
{
    public interface IDataProvider
    {
        List<UserInfoAdapterProxy> FromFile(string fileSource);
        void AddUser(UserInfoAdapterProxy user,string fileSource);
    }
}
