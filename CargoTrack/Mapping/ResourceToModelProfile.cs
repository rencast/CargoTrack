using AutoMapper;
using server.CargoTrack.Domain.Models;
using server.CargoTrack.Resources;

namespace server.CargoTrack.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveBrandVehicleResource, BrandVehicle>();
        CreateMap<SaveCourierResource, Courier>();
        CreateMap<SavePaymentMethodResource, PaymentMethod>();
        CreateMap<SavePaymentServiceResource, PaymentService>();
        CreateMap<SavePersonResource, Person>();
        CreateMap<SaveServiceResource, Service>();
        CreateMap<SaveUserResource, User>();
        CreateMap<SaveUserRequestResource, UserRequest>();
        CreateMap<SaveVehicleResource, Vehicle>();
        CreateMap<SaveLicenseResource, License>();
    }
}