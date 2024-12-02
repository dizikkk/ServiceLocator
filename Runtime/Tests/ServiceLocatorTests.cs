using NSubstitute;
using NUnit.Framework;
using ServiceLocator.Runtime.Core;

namespace ServiceLocator.Runtime.Tests
{
    public class ServiceLocatorTests
    {
        [Test]
        public void Return_the_same_service_which_added()
        {
            //Arange
            IServiceLocator serviceLocator = new Core.ServiceLocator();
            ITestService testService = Substitute.For<ITestService>();
            
            //Act
            serviceLocator.Add(testService);
            
            //Assert
            Assert.AreEqual(testService, serviceLocator.Get<ITestService>());
        }
        
        [Test]
        public void Add_service_twice_overwrite_existing_service_with_same_type()
        {
            //Arange
            IServiceLocator serviceLocator = new Core.ServiceLocator();
            ITestService firstTestService = Substitute.For<ITestService>();
            ITestService secondTestService = Substitute.For<ITestService>();
            
            //Act
            serviceLocator.Add(firstTestService);
            
            //Assert
            Assert.AreNotEqual(secondTestService, serviceLocator.Get<ITestService>());
        }
    }
}