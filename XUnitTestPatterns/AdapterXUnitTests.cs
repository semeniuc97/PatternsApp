using Logic.AdapterProxyClasses;
using Logic.AdapterProxyInterfaces;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestPatterns
{
    public class AdapterXUnitTests
    {
        UsersFileReader fileReader = new UsersFileReader();

        Mock<UsersFileReader> mocker = new Mock<UsersFileReader>() { CallBase = true };

        [Fact]
        public void IsDerivedClass()
        {

            bool result = fileReader is IDataProvider ? true : false;

            Assert.True(result);
        }

        [Fact]
        public void CheckUsersFileReader()
        {
            mocker.Setup(m => m.ReadUsers("test"))
                .Returns(new List<UserAdapterProxy>()
                {
                   new UserAdapterProxy()
                {
                        Name = "Kolya",
                       Age = 18,
                       City = "New-York"
                   },
                   new UserAdapterProxy()
        {
            Name = "Valik",
                       Age = 23,
                       City = "Washington"
                   }
    });

            var expected = new List<UserInfoAdapterProxy>()
            {
                new UserInfoAdapterProxy()
                {
                    Age=18,
                    Name="Kolya"
                },

                new UserInfoAdapterProxy()
                {
                    Age=23,
                    Name="Valik"
                }
            };

            var result = mocker.Object.FromFile("test");

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.Equal(expected[i].Age, result[i].Age);
                Assert.Equal(expected[i].Name, result[i].Name);
            }

        }

        [Fact]
        public void IsReturnedTypeUserInfo()
        {
            mocker.Setup(m => m.ReadUsers("test"))
                .Returns(new List<UserAdapterProxy>()
                {
                   new UserAdapterProxy()
        {
            Name = "Kolya",
                       Age = 18,
                       City = "New-York"
                   },
                   new UserAdapterProxy()
        {
            Name = "Valik",
                       Age = 23,
                       City = "Washington"
                   }
    });

            UserManagerAdapter userManagerAdapter = new UserManagerAdapter(mocker.Object, "test");

            var result = userManagerAdapter.GetAll();

            var expected = new List<UserInfoAdapterProxy>()
            {
                new UserInfoAdapterProxy()
                {
                    Age=18,
                    Name="Kolya"
                },

                new UserInfoAdapterProxy()
                {
                    Age=23,
                    Name="Valik"
                }
            };

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.Equal(expected[i].Age, result[i].Age);
                Assert.Equal(expected[i].Name, result[i].Name);
            }
        }
    }
}
