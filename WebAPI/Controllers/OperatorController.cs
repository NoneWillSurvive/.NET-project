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
    public class OperatorController : ControllerBase
    {
        private ILogger<OperatorController> Logger { get; }
        private IOperatorCreateService OperatorCreateService { get; }
        private IOperatorGetService OperatorGetService { get; }
        private IOperatorUpdateService OperatorUpdateService { get; }
        private IMapper Mapper { get; }

        public OperatorController(ILogger<OperatorController> logger, IMapper mapper,
            IOperatorCreateService OperatorCreateService, IOperatorGetService OperatorGetService,
            IOperatorUpdateService OperatorUpdateService)
        {
            this.Logger = logger;
            this.OperatorCreateService = OperatorCreateService;
            this.OperatorGetService = OperatorGetService;
            this.OperatorUpdateService = OperatorUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<OperatorDTO> PutAsync(OperatorCreateDTO Operator)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.OperatorCreateService.CreateAsync(this.Mapper.Map<OperatorUpdateModel>(Operator));

            return this.Mapper.Map<OperatorDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<OperatorDTO> PatchAsync(OperatorUpdateDTO Operator)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.OperatorUpdateService.UpdateAsync(this.Mapper.Map<OperatorUpdateModel>(Operator));

            return this.Mapper.Map<OperatorDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<OperatorDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<OperatorDTO>>(await this.OperatorGetService.GetAsync());
        }

        [HttpGet]
        [Route("{OperatorId}")]
        public async Task<OperatorDTO> GetAsync(int OperatorId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {OperatorId}");

            return this.Mapper.Map<OperatorDTO>(
                await this.OperatorGetService.GetAsync(new OperatorIdentityModel(OperatorId)));
        }
    }
}