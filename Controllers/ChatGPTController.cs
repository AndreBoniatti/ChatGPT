using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PPI.Clients.Contracts;
using PPI.Models.Dtos;

namespace PPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatGPTController : ControllerBase
    {
        [HttpGet("ChatCompletion")]
        public async Task<IActionResult> CreateChatCompletion(
            [FromServices] IOpenAIClient openAIClient
        )
        {
            var chatCompletion = new ChatDto
            {
                Model = "gpt-3.5-turbo",
                Temperature = 1,
                Messages = new List<MessageDto>
                {
                    new MessageDto
                    {
                        Role = "system",
                        Content = "Você é um assistente de IA que ajuda professores a criar perguntas para provas. Cada pergunta deve ter cinco opções de resposta, sendo apenas uma a correta."
                    },
                    new MessageDto
                    {
                        Role = "user",
                        Content = "Por favor, crie 2 pergunta para uma prova de matemática de dificuldade fácil."
                    },
                    new MessageDto
                    {
                        Role = "assistant",
                        Content = "{ Questions: [ { Content: \"Qual é o único número primo par?\", Answers: [ { Content: \"Zero\", Correct: false }, { Content: \"Dois\", Correct: true }, { Content: \"Quatro\", Correct: false }, { Content: \"Seis\", Correct: false }, { Content: \"Nenhuma das Alternativas\", Correct: false } ] }, { Content: \"Qual é a raiz quadrada de 25?\", Answers: [ { Content: \"1\", Correct: false }, { Content: \"2\", Correct: false }, { Content: \"3\", Correct: false }, { Content: \"4\", Correct: false }, { Content: \"5\", Correct: true } ] } ] }"
                    },
                    new MessageDto
                    {
                        Role = "user",
                        Content = "Por favor, crie 2 perguntas para uma prova de química de dificuldade fácil."
                    }
                }
            };

            var response = await openAIClient.CreateChatCompletionAsync(chatCompletion);
            if (response == null)
                return BadRequest("Erro ao se comunicar com a API");

            try
            {
                string jsonPart = GetMessageContentAsJSON(response);

                var questions = JsonConvert.DeserializeObject<QuestionsDto>(jsonPart);
                return Ok(questions);
            }
            catch
            {
                return BadRequest("Erro ao converter resposta");
            }
        }

        private string GetMessageContentAsJSON(ChatResponseDto response)
        {
            var jsonPart = String.Empty;

            string messageContent = response.Choices?[0].Message?.Content ?? "";
            int firstBracket = messageContent.IndexOf('{');
            int lastBracket = messageContent.LastIndexOf('}');

            if (firstBracket >= 0 && lastBracket >= 0)
                jsonPart = messageContent.Substring(firstBracket, lastBracket - firstBracket + 1);

            return jsonPart;
        }
    }
}