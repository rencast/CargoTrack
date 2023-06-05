using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;
using Shared.Domain.Repositories;


namespace server.CargoTrack.Services;

public class PersonService:IPersonService
{
    private readonly IPersonRepository _personRepository;

    private readonly IUnitOfWork _unitOfWork;
    public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Person>> ListAsync()
    {
        return await _personRepository.ListAsync();
    }

    public async Task<PersonResponse> SaveAsync(Person Person)
    {
        try
        {
            await _personRepository.AddAsync(Person);
            await _unitOfWork.CompleteAsync();

            return new PersonResponse(Person);
        }
        catch (Exception e)
        {
            return new PersonResponse($"An error occurred while saving the Person: {e.Message}");
        }
    }

    public async Task<PersonResponse> UpdateAsync(int id, Person Person)
    {
        var existingPerson = await _personRepository.FindByIdAsync(id);

        if (existingPerson == null)
            return new PersonResponse("Person not found.");

        existingPerson.Phone = Person.Phone;

        try
        {
            _personRepository.Update(existingPerson);
            await _unitOfWork.CompleteAsync();
            
            return new PersonResponse(existingPerson);
        }
        catch (Exception e)
        {
            return new PersonResponse($"An error occurred while updating the Person: {e.Message}");
        }
    }

    public async Task<PersonResponse> DeleteAsync(int id)
    {
        var existingPerson = await _personRepository.FindByIdAsync(id);

        if (existingPerson == null)
            return new PersonResponse("Person not found.");

        try
        {
            _personRepository.Remove(existingPerson);
            await _unitOfWork.CompleteAsync();

            return new PersonResponse(existingPerson);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new PersonResponse($"An error occurred while deleting the Person: {e.Message}");
        }
    }
}