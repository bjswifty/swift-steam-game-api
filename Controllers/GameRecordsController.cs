using Microsoft.AspNetCore.Mvc;
using SwiftSteamGameApi.Models;
using SwiftSteamGameApi.Services;

namespace SwiftSteamGameApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameRecordsController : ControllerBase
{
    private readonly IGameRecordService _gameRecordService;

    public GameRecordsController(IGameRecordService gameRecordService)
    {
        _gameRecordService = gameRecordService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameRecord>>> GetGameRecordList(CancellationToken cancellationToken)
    {
        var gameRecords = await _gameRecordService.GetGameRecordListAsync(cancellationToken);
        return Ok(gameRecords);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GameRecord>> GetGameRecord(Guid id, CancellationToken cancellationToken)
    {
        var gameRecord = await _gameRecordService.GetGameRecordAsync(id, cancellationToken);

        if (gameRecord is null)
        {
            return NotFound();
        }

        return Ok(gameRecord);
    }

    [HttpPost]
    public async Task<ActionResult<GameRecord>> CreateGameRecord(
        [FromBody] GameRecord gameRecord,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var createdGameRecord = await _gameRecordService.CreateGameRecordAsync(gameRecord, cancellationToken);
        return CreatedAtAction(nameof(GetGameRecord), new { id = createdGameRecord.Id }, createdGameRecord);
    }
}
