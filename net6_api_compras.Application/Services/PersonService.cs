using AutoMapper;
using net6_api_compras.Application.DTOs;
using net6_api_compras.Application.DTOs.Validations;
using net6_api_compras.Application.Services.Interfaces;
using net6_api_compras.Domain.Entities;
using net6_api_compras.Domain.Repositories;

namespace net6_api_compras.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null) return ResultService.Fail<PersonDTO>("Objeto deve ser informado!");

            var result = new PersonDTOValidator().Validate(personDTO);

            if (!result.IsValid) return ResultService.RequestError<PersonDTO>("Problemas de validação!", result);

            var person = _mapper.Map<Person>(personDTO);

            var data = await _personRepository.CreateAsync(person);

            return ResultService.Ok(_mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var person = await _personRepository.GetAsync(id);

            if (person == null) return ResultService.Fail("Pessoa não encontrada.");

            await _personRepository.RemoveAsync(person);

            return ResultService.Ok($"Pessoa de id [{id}] foi removida com sucesso!");
        }

        public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
        {
            if (personDTO == null) return ResultService.Fail("Objeto deve ser informado!");

            var validation = new PersonDTOValidator().Validate(personDTO);

            if (!validation.IsValid) return ResultService.RequestError("Problemas com a validação dos campos", validation);

            var person = await _personRepository.GetAsync(personDTO.Id);

            if (person == null) return ResultService.Fail("Pessoa não encontrada.");

            // Para editar o map é diferente da inserção
            person = _mapper.Map(personDTO, person);

            await _personRepository.UpdateAsync(person);

            return ResultService.Ok("Pessoa editada.");
        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAllAsync()
        {
            var people = await _personRepository.GetAllAsync();

            return ResultService.Ok(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> GetAsync(int id)
        {
            var person = await _personRepository.GetAsync(id);

            if (person == null) return ResultService.Fail<PersonDTO>("Pessoa não encontrada");

            return ResultService.Ok(_mapper.Map<PersonDTO>(person));
        }
    }
}
