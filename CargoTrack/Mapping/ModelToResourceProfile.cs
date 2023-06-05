using AutoMapper;
using server.CargoTrack.Domain.Models;
using server.CargoTrack.Resources;

namespace server.CargoTrack.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<BrandVehicle, BrandVehicleResource>();
        CreateMap<Courier, CourierResource>();
        CreateMap<PaymentMethod, PaymentMethodResource>();
        CreateMap<PaymentService, PaymentServiceResource>();
        CreateMap<Person, PersonResource>();
        CreateMap<Service, ServiceResource>();
        CreateMap<User, UserResource>();
        CreateMap<UserRequest, UserRequestResource>();
        CreateMap<Vehicle, VehicleResource>();
        CreateMap<License, LicenseResource>();
    }
}