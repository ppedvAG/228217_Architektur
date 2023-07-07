using Microsoft.AspNetCore.Mvc;
using ppedv.BerlinBytes.API.Model;
using ppedv.BerlinBytes.Model.Contracts;
using ppedv.BerlinBytes.Model.DomainModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.BerlinBytes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public VersionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // GET: api/<VersionController>
        [HttpGet]
        public IEnumerable<VersionDTO> Get()
        {
            foreach (var item in uow.VersionRepo.Query())
            {
                yield return VersionMapper.MapToDTO(item);
            }
        }

        // GET api/<VersionController>/5
        [HttpGet("{id}")]
        public VersionDTO Get(int id)
        {
            return VersionMapper.MapToDTO(uow.VersionRepo.GetById(id));
        }

        // POST api/<VersionController>
        [HttpPost]
        public void Post([FromBody] VersionDTO value)
        {
            uow.VersionRepo.Add(VersionMapper.MapToEntity(value));
            uow.SaveAll();
        }

        // PUT api/<VersionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VersionDTO value)
        {
        }

        // DELETE api/<VersionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class VersionMapper
    {
        public static VersionDTO MapToDTO(ppedv.BerlinBytes.Model.DomainModel.Version version)
        {
            return new VersionDTO
            {
                Id = version.Id,
                VersionsNummer = version.Number,
                Stage = version.Stage.ToString(),
                ReleaseDate = version.ReleaseDate,
                EndOfSupportDate = version.EndOfSupportDate,
                Count = version.DownloadCount
            };
        }

        public static ppedv.BerlinBytes.Model.DomainModel.Version MapToEntity(VersionDTO dto)
        {
            return new ppedv.BerlinBytes.Model.DomainModel.Version
            {
                Id = dto.Id,
                Number = dto.VersionsNummer,
                Stage = Enum.Parse<AppStage>(dto.Stage),
                ReleaseDate = dto.ReleaseDate,
                EndOfSupportDate = dto.EndOfSupportDate,
                DownloadCount = dto.Count
            };
        }
    }
}
