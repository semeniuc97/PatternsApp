using Logic.AdapterProxyInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.AdapterProxyClasses
{
    public class UserManagerAdapter
    {
        IDataProvider provider;
        string source;

        public UserManagerAdapter(IDataProvider provider,string source)
        {
            this.provider = provider;
            this.source = source;
        }

        public List<UserInfoAdapterProxy> GetAll()
        {
           return provider.FromFile(source);
        }

        public void AddUser(UserInfoAdapterProxy userInfo)
        {
            provider.AddUser(userInfo, source);
        }

    }
}
