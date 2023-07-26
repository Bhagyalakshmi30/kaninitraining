using AbstractFactory;

VehicleFamilyFactory vehicleFamilyFactory = new BikeFamilyFactory();

VehicleFactory carFactory = vehicleFamilyFactory. CreateCarFactory();
VehicleFactory bikeFactory = vehicleFamilyFactory. CreateBikeFactory();

Vehicle car = carFactory.CreateVehicle();
Vehicle bike = bikeFactory.CreateVehicle();

car.Drive();
bike.Drive();
