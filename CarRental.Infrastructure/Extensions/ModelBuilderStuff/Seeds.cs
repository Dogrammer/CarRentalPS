using System;
using CarRental.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Extensions.ModelBuilderStuff
{
    public static class ModelBuilderSeedExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Cars(modelBuilder);
            CarCategories(modelBuilder);
            Cities(modelBuilder);
            Customers(modelBuilder);
            Locations(modelBuilder);
            Rentals(modelBuilder);
        }
        private static void Cities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Sisak",
                    Zip = "44000"
                },
                new City
                {
                    Id = 2,
                    Name = "Zagreb",
                    Zip = "10000"
                },
                 new City
                 {
                     Id = 3,
                     Name = "Velika Gorica",
                     Zip = "10410"
                 },
                new City
                {
                    Id = 4,
                    Name = "Osijek",
                    Zip = "31000"
                },
                new City
                {
                    Id = 5,
                    Name = "Slavonski Brod",
                    Zip = "35000"
                },
                new City
                {
                    Id = 6,
                    Name = "Rijeka",
                    Zip = "51000"
                },
                new City
                {
                    Id = 7,
                    Name = "Varaždin",
                    Zip = "42000"
                },
                new City
                {
                    Id = 8,
                    Name = "Krapina",
                    Zip = "49000"
                },
                new City
                {
                    Id = 9,
                    Name = "Split",
                    Zip = "21000"
                },
                new City
                {
                    Id = 10,
                    Name = "Dubrovnik",
                    Zip = "20000"
                },
                new City
                {
                    Id = 11,
                    Name = "Trogir",
                    Zip = "21220"
                },
                new City
                {
                    Id = 12,
                    Name = "Šibenik",
                    Zip = "22000"
                },
                new City
                {
                    Id = 13,
                    Name = "Vukovar",
                    Zip = "32000"
                },
                new City
                {
                    Id = 14,
                    Name = "Vinkovci",
                    Zip = "37000"
                });

        }

        private static void Customers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "Ivanovic",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "11111111"
                },

                new Customer
                {
                    Id = 2,
                    FirstName = "Marko",
                    LastName = "Marković",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "22222222"
                },


                new Customer
                {
                    Id = 3,
                    FirstName = "Josip",
                    LastName = "Josipović",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "33333333"
                },

                new Customer
                {
                    Id = 4,
                    FirstName = "Pero",
                    LastName = "Perić",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "44444444"
                },

                new Customer
                {
                    Id = 5,
                    FirstName = "Matko",
                    LastName = "Matković",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "55555555"
                },

                new Customer
                {
                    Id = 6,
                    FirstName = "Ivica",
                    LastName = "Ivić",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "88888888"
                },

                new Customer
                {
                    Id = 7,
                    FirstName = "Davor",
                    LastName = "Davorić",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "99999999"
                },

                new Customer
                {
                    Id = 8,
                    FirstName = "Dario",
                    LastName = "Dariović",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "12121212"
                },

                new Customer
                {
                    Id = 9,
                    FirstName = "Dorian",
                    LastName = "Dorianović",
                    DateOfBirth = new DateTime(1990, 5, 23, 0, 0, 0),
                    DrivingLicenceNumber = "12312312"
                });


        }

        private static void CarCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarCategory>().HasData(
            new CarCategory
            {
                Id = 1,
                Name = "van"
            },
            new CarCategory
            {
                Id = 2,
                Name = "mini-van"
            },
            new CarCategory
            {
                Id = 3,
                Name = "limousine"
            },
            new CarCategory
            {
                Id = 4,
                Name = "hatchback"
            },
            new CarCategory
            {
                Id = 5,
                Name = "coupe"
            });
        }

        private static void Locations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "Vukovarska 4c",
                    CityId = 1
                },
                new Location
                {
                    Id = 2,
                    Name = "Zagrebačka 5",
                    CityId = 2
                },
                new Location
                {
                    Id = 3,
                    Name = "Petrova 5",
                    CityId = 4
                },
                new Location
                {
                    Id = 4,
                    Name = "Sisačka 13",
                    CityId = 3
                },
                new Location
                {
                    Id = 5,
                    Name = "Slavonska 4c",
                    CityId = 7
                },
                new Location
                {
                    Id = 6,
                    Name = "Petrinjska 4c",
                    CityId = 8
                },
                new Location
                {
                    Id = 7,
                    Name = "Vukovarska 15c",
                    CityId = 1
                });

        }

        private static void Cars(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Brand = "Audi",
                    Model = "A4",
                    ProductionYear = 2018,
                    Mileage = 10500,
                    Color = "Black",
                    CarCategoryId = 4
                },
                new Car
                {
                    Id = 2,
                    Brand = "BMW",
                    Model = "320d",
                    ProductionYear = 2015,
                    Mileage = 100500,
                    Color = "Red",
                    CarCategoryId = 3
                },
                new Car
                {
                    Id = 3,
                    Brand = "Mazda",
                    Model = "3",
                    ProductionYear = 2014,
                    Mileage = 12500,
                    Color = "Black",
                    CarCategoryId = 3
                },
                new Car
                {
                    Id = 4,
                    Brand = "Audi",
                    Model = "A7",
                    ProductionYear = 2018,
                    Mileage = 25500,
                    Color = "Blue",
                    CarCategoryId = 4
                },
                new Car
                {
                    Id = 5,
                    Brand = "Mercedes",
                    Model = "c200",
                    ProductionYear = 2013,
                    Mileage = 150000,
                    Color = "Black",
                    CarCategoryId = 3
                },
                new Car
                {
                    Id = 6,
                    Brand = "Citroen",
                    Model = "c3",
                    ProductionYear = 2010,
                    Mileage = 107500,
                    Color = "Yellow",
                    CarCategoryId = 4
                },
                new Car
                {
                    Id = 7,
                    Brand = "Peugeot",
                    Model = "307",
                    ProductionYear = 2015,
                    Mileage = 100500,
                    Color = "Red",
                    CarCategoryId = 3
                });

        }

        private static void Rentals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasData(
                new Rental
                {
                    Id = 1,
                    StartDate = new DateTime(2015, 04, 04, 0, 0, 0),
                    EndDate = new DateTime(2015, 05, 04, 0, 0, 0),
                    Remarks = "blah blah",
                    PickUpLocationId = 2,
                    DropOffLocationId = 3,
                    CustomerId = 3,
                    CarId = 3,
                    Reserved = true
                },
                new Rental
                {
                    Id = 2,
                    StartDate = new DateTime(2016, 05, 30, 0, 0, 0),
                    EndDate = new DateTime(2016, 06, 30, 0, 0, 0),
                    Remarks = "blah blah",
                    PickUpLocationId = 1,
                    DropOffLocationId = 4,
                    CustomerId = 5,
                    CarId = 3,
                    Reserved = true
                },
                new Rental
                {
                    Id = 3,
                    StartDate = new DateTime(2018, 07, 30, 0, 0, 0),
                    EndDate = new DateTime(2018, 08, 30, 0, 0, 0),
                    Remarks = "blah blah",
                    PickUpLocationId = 1,
                    DropOffLocationId = 3,
                    CustomerId = 6,
                    CarId = 1,
                    Reserved = true
                },
                new Rental
                {
                    Id = 4,
                    StartDate = new DateTime(2019, 04, 30, 0, 0, 0),
                    EndDate = new DateTime(2019, 05, 30, 0, 0, 0),
                    Remarks = "blah blah",
                    PickUpLocationId = 1,
                    DropOffLocationId = 2,
                    CustomerId = 2,
                    CarId = 2,
                    Reserved = true
                },
                new Rental
                {
                    Id = 5,
                    StartDate = new DateTime(2019, 07, 30, 0, 0, 0),
                    EndDate = new DateTime(2019, 08, 30, 0, 0, 0),
                    Remarks = "blah blah",
                    PickUpLocationId = 1,
                    DropOffLocationId = 2,
                    CustomerId = 2,
                    CarId = 6,
                    Reserved = true
                },
                new Rental
                {
                    Id = 6,
                    StartDate = new DateTime(2019, 09, 30, 0, 0, 0),
                    EndDate = new DateTime(2019, 10, 30, 0, 0, 0),
                    Remarks = "blah blah",
                    PickUpLocationId = 1,
                    DropOffLocationId = 2,
                    CustomerId = 2,
                    CarId = 5,
                    Reserved = true
                },
                new Rental
                {
                    Id = 7,
                    StartDate = new DateTime(2019, 06, 15, 0, 0, 0),
                    EndDate = new DateTime(2019, 06, 25, 0, 0, 0),
                    Remarks = "blah blah",
                    PickUpLocationId = 1,
                    DropOffLocationId = 2,
                    CustomerId = 2,
                    CarId = 4,
                    Reserved = true
                });



        }
    }
}