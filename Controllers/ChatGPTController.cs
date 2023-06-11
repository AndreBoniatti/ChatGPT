using Microsoft.AspNetCore.Mvc;
using PPI.Clients.Contracts;
using PPI.Models.DTOS;

namespace PPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatGPTController : ControllerBase
    {
        [HttpPost("ChatCompletion")]
        public async Task<IActionResult> CreateChatCompletion(
            [FromServices] IOpenAIClient openAIClient
        )
        {
            var chatCompletion = new ChatDto
            {
                Model = "gpt-3.5-turbo",
                Messages = new List<MessageDto>
                {
                    new MessageDto
                    {
                        Role = "user",
                        Content = "Hello!"
                    }
                }
            };

            var response = await openAIClient.CreateChatCompletionAsync(chatCompletion);
            return Ok(response);
        }
    }
}