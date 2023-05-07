using Microsoft.AspNetCore.Mvc;
using VirtualServiceWeb.Data.Models;
using VirtualServiceWeb.Repositories.Interfaces;
using VirtualServiceWeb.Services;

namespace VirtualServiceWeb.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InstanceController : ControllerBase
{
    private readonly IInstanceRepository _instanceRepository;
    private readonly CoreService _coreService;

    public InstanceController(IInstanceRepository instanceRepository, CoreService coreService)
    {
        _instanceRepository = instanceRepository;
        _coreService = coreService;
    }

    [HttpGet]
    public async Task<IEnumerable<InstanceModel>> Get()
    {
        var instances = await _instanceRepository.GetAllAsync();
        return instances;
    }

    [HttpGet]
    public IActionResult Genarate()
    {
        Task generationTask = new Task(() => _coreService.StartScript());
        generationTask.Start();
        
        return Ok();
    }
}