﻿using Api_TikTok.Dto;
using Api_TikTok.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/messages")]
[ApiController]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly MessageService _messageService;

    public MessageController(MessageService messageService)
    {
        _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
    }

    private int GetUserIdFromClaims()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            var userIdClaim = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
                return userId;
        }
        return 0;
    }

    [HttpPost("send")]
    [Authorize]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageDto request)
    {
        if (request == null)
        {
            return BadRequest("Request body cannot be null.");
        }

        var userId = GetUserIdFromClaims();
        if (userId == 0)
        {
            return Unauthorized("User ID not found in claims.");
        }

        request.SenderUserId = userId;

        var message = await _messageService.SendMessageAsync(request);
        if (message == null)
            return BadRequest("Message failed to send.");

        return Ok(message);
    }

    [HttpGet("history")]
    [Authorize]
    public async Task<IActionResult> GetChatHistory(int chatWithUserId)
    {
        var userId = GetUserIdFromClaims();
        if (userId == 0)
        {
            return Unauthorized("User ID not found in claims.");
        }

        var messages = await _messageService.GetChatHistoryAsync(userId, chatWithUserId);
        return Ok(messages);
    }

    [HttpDelete("{messageId}")]
    [Authorize]
    public async Task<IActionResult> DeleteMessage(int messageId)
    {
        var userId = GetUserIdFromClaims();  
        if (userId == 0)
        {
            return Unauthorized("User ID not found in claims.");
        }

        var result = await _messageService.DeleteMessageAsync(messageId, userId);
        if (result)
            return Ok(new { Message = "Deleted successfully" });

        return BadRequest(new { Message = "Failed to delete message" });
    }
}
