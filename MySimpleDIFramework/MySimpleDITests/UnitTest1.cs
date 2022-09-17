namespace MySimpleDITests;

using Microsoft.VisualStudio.TestPlatform.TestHost;
using MySimpleDI.Models.Collection;
using TestingModels;

public class Tests
{

    [Test]
    public void ShouldBeAbleToRegisterServiceCorrectly()
    {
        //Arrange


        var serviceCollection = new ServiceCollection();
        serviceCollection.Register<ISomething, SomeClass>();
        var serviceProvider = serviceCollection.BuildServices();

        //Act

        var data = serviceProvider.GetImplementation<ISomething>();

        //Assert

        Assert.That(data, Is.TypeOf<SomeClass>());

    }

    [Test]
    public void TryingToInstantiateNotRegisteredImplementationShouldThrowException()
    {
        var serviceCollection = new ServiceCollection();
        var serviceProvider = serviceCollection.BuildServices();

        Assert.Throws<InvalidOperationException>(() =>
        {
            serviceProvider.GetImplementation<ISomething>();
        }
        );
    }

    [Test]
    public void ResolvingShouldCreateObjectWithDependencies()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.Register<IBrain, Brain>();
        serviceCollection.Register<ISoul, Soul>();
        var serviceProvider = serviceCollection.BuildServices();


        var data = serviceProvider.Resolve<Person>();
        Assert.That(data, Is.TypeOf<Person>());
    }

    [Test]
    public void ResolveShouldWorkWithClassesAndInterfaces()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.Register<IBrain, Brain>();
        serviceCollection.Register(typeof(Weapon));
        var serviceProvider = serviceCollection.BuildServices();

        var data = serviceProvider.Resolve<Robot>();

        Assert.That(data, Is.TypeOf<Robot>());
    }

    [Test]
    public void ResolveShouldResolveNestedDependencies()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.Register<IBrain, Brain>();
        serviceCollection.Register<IPerson, Person>();
        serviceCollection.Register<ISoul, Soul>();
        var serviceProvider = serviceCollection.BuildServices();

        var data = serviceProvider.Resolve<Human>();

        Assert.That(data, Is.TypeOf<Human>());
    }

    [Test]
    public void ResolveShouldWorkWithValueTypes()
    {
        var serviceCollection = new ServiceCollection();
        var serviceProvider = serviceCollection.BuildServices();

        var data = serviceProvider.Resolve<ClassWithValueTypesConstructor>();

        Assert.That(data, Is.TypeOf<ClassWithValueTypesConstructor>());
    }

    [Test]
    public void AutoRegisterShouldRegisterAllDependenciesOfTheGivenAssembly()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.RegisterAll<Tests>();
        var serviceProvider = serviceCollection.BuildServices();

        var brain = serviceProvider.GetImplementation<IBrain>();
        var soul = serviceProvider.GetImplementation<ISoul>();
        var person = serviceProvider.GetImplementation<IPerson>();

        Assert.Multiple(() =>
        {
            Assert.That(brain, Is.TypeOf<Brain>());
            Assert.That(soul, Is.TypeOf<Soul>());
            Assert.That(person, Is.TypeOf<Person>());
        });
    }
}
