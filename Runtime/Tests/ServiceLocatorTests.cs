using NSubstitute;
using NUnit.Framework;
using SL.Runtime.Core;

namespace SL.Runtime.Tests
{
    public class ServiceLocatorTests
    {
        [Test]
        public void Service_locator_instance_not_change()
        {
            //Arange
            IServiceLocator serviceLocator = ServiceLocator.Instance;

            //Act


            //Assert
            Assert.AreEqual(serviceLocator, ServiceLocator.Instance);
            
        }
        
        [Test]
        public void Return_the_same_service_which_added()
        {
            //Arange
            ITestService testService = Substitute.For<ITestService>();
            IServiceLocator serviceLocator = new ServiceLocator();

            //Act
            serviceLocator.Add(testService);

            //Assert
            Assert.AreSame(serviceLocator.Get<ITestService>(), testService);
        }
        
        [Test]
        public void Add_service_twice_overwrite_existing_service_with_same_type()
        {
            //Arange
            ITestService firstTestService = Substitute.For<ITestService>();
            ITestService secondTestService = Substitute.For<ITestService>();
            
            //Act
            ServiceLocator.Instance.Add(firstTestService);
            
            //Assert
            Assert.AreNotEqual(secondTestService, ServiceLocator.Instance.Get<ITestService>());
        }
    }
}