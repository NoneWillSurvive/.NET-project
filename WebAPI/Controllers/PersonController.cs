using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Contracts;
using Client.DTO;
using Client.Requests.Create;
using Client.Requests.Update;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private ILogger<PersonController> Logger { get; }
        private IPersonCreateService PersonCreateService { get; }
        private IPersonGetService PersonGetService { get; }
        private IPersonUpdateService PersonUpdateService { get; }
        private IMapper Mapper { get; }

        public PersonController(ILogger<PersonController> logger, IMapper mapper,
            IPersonCreateService PersonCreateService, IPersonGetService PersonGetService,
            IPersonUpdateService PersonUpdateService)
        {
            this.Logger = logger;
            this.PersonCreateService = PersonCreateService;
            this.PersonGetService = PersonGetService;
            this.PersonUpdateService = PersonUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<PersonDTO> PutAsync(PersonCreateDTO Person)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.PersonCreateService.CreateAsync(this.Mapper.Map<PersonUpdateModel>(Person));

            return this.Mapper.Map<PersonDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<PersonDTO> PatchAsync(PersonUpdateDTO Person)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.PersonUpdateService.UpdateAsync(this.Mapper.Map<PersonUpdateModel>(Person));

            return this.Mapper.Map<PersonDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PersonDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<PersonDTO>>(await this.PersonGetService.GetAsync());
        }

        [HttpGet]
        [Route("{PersonId}")]
        public async Task<PersonDTO> GetAsync(int PersonId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {PersonId}");

            return this.Mapper.Map<PersonDTO>(
                await this.PersonGetService.GetAsync(new PersonIdentityModel(PersonId)));
        }
    }
}