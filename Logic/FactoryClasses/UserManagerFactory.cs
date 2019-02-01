using Logic.FactoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FactoryClasses
{
    public class UserManagerFactory
    {
        IFactory factory;
        public UserManagerFactory(IFactory factory)
        {
            this.factory = factory;
        }

        public IEnumerable<UserFactory> All()
        {
            return factory.GetReader().All();
        }

        public IEnumerable<UserFactory> ByAge(int age)
        {
            return factory.GetReader().All().Where(x => x.Age <= age).ToList();
        }

        public IEnumerable<UserFactory> ByCity(string city)
        {
            return factory.GetReader().ByCity(city);
        }

        public UserFactory Add(string name, int age, string city)
        {
            return factory.GetWriter().Add(name, age, city);
        }

        public void Delete(Guid id)
        {
            factory.GetWriter().Delete(id);
        }

        public object Delete(object guidId)
        {
            throw new NotImplementedException();
        }
    }
}
