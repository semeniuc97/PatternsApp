using Logic.AdapterProxyClasses;
using Logic.AdapterProxyInterfaces;
using Logic.FactoryClasses;
using Logic.FactoryInterfaces;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestPatterns
{
    public class AbstractFactoryXUnitTests
    {

        [Fact]
        public void TestingByAgeMethod()
        {
            Mock<FileReader> MockReader = new Mock<FileReader>(It.IsAny<string>()) { CallBase = true };
            MockReader.Setup(m => m.All())
                .Returns(new List<UserFactory>()
                {
                    new UserFactory()
                    {
                        Age=18,
                        Name="Mykola",
                        City="Edinburg",
                        Id=new Guid("11041444-996f-48b4-8b25-d52c5cf97e2e")
                    },
                    new UserFactory()
                    {
                        Age=19,
                        Name="Wasya",
                        City="Ankara",
                        Id=new Guid("11041444-996f-48b4-8b25-d52c5cf97e2f")
                    }
                });

            Mock<IFactory> FileFactoryMock = new Mock<IFactory>();
            FileFactoryMock.Setup(m => m.GetReader()).Returns(MockReader.Object);

            UserManagerFactory userManager = new UserManagerFactory(FileFactoryMock.Object);

            var result = userManager.ByAge(19).ToList();

            var expected = new List<UserFactory>()
                {
                    new UserFactory()
                    {
                        Age=18,
                        Name="Mykola",
                        City="Edinburg",
                        Id=new Guid("11041444-996f-48b4-8b25-d52c5cf97e2e")
                    },
                    new UserFactory()
                    {
                        Age=19,
                        Name="Wasya",
                        City="Ankara",
                        Id=new Guid("11041444-996f-48b4-8b25-d52c5cf97e2f")
                    }
                };

            for (int i = 0; i < expected.Count - 1; i++)
            {
                Assert.Equal(expected.Count, result.Count);
                Assert.Equal(expected[i].Age, result[i].Age);
                Assert.Equal(expected[i].Name, result[i].Name);
                Assert.Equal(expected[i].City, result[i].City);
                Assert.Equal(expected[i].Id, result[i].Id);
            }

        }

        [Fact]
        public void TestingDeleteMethod()
        {
            var id = new Guid("72004c9c-3587-49bd-bc5e-b0861c77a2b1");
            var mockDataWriter = new Mock<IDataWriter>();
            var mockFactory = new Mock<IFactory>();
            bool calledWithCorrectParam = false;
            mockDataWriter.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>((guid) =>
            {
                if (guid == id)
                {
                    calledWithCorrectParam = true;
                }
            });
            mockFactory.Setup(s => s.GetWriter()).Returns(mockDataWriter.Object);

            UserManagerFactory userManager = new UserManagerFactory(mockFactory.Object);
            userManager.Delete(id);


            Assert.True(calledWithCorrectParam);
        }



    }
}
