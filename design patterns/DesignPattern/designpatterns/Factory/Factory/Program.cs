using Factory;

VehicleFactory carFactory = new CarFactory();
VehicleFactory bikeFactory = new BikeFactory();

Vehicle car = carFactory.CreateVehicle();
Vehicle bike = bikeFactory.CreateVehicle();

car.Drive();
bike.Drive();