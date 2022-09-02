using Facade.Models;

var car = new CarBuilderFacade()
    .Info
        .WithMake("Lamborghini")
        .WithModel("Aventador")
        .WithYear(2022)
        .WithKilometers(1000)
    .Build();

Console.WriteLine(car);