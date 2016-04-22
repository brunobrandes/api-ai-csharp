using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;
using Api.Ai.ApplicationService.Factories;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Domain.DataTransferObject.Request;

namespace Api.Ai.Example.Bot.Application
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        #region Private Fields

        private readonly IApiAiAppServiceFactory _apiAiAppServiceFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        #endregion

        #region Constructor

        public MessagesController(IApiAiAppServiceFactory apiAiAppServiceFactory, IHttpClientFactory httpClientFactory)
        {
            _apiAiAppServiceFactory = apiAiAppServiceFactory;
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region Private Methods

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }

        /// <summary>
        /// Call query api.ai
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task<string> GetSpeechAsync(Message message)
        {
            var result = "Oops! Something went wrong!";

            try
            {
                var queryAppService = _apiAiAppServiceFactory.CreateQueryAppService("https://api.api.ai/v1", "YOUR_ACCESS_TOKEN");

                var queryRequest = new QueryRequest
                {
                    Query = new string[] { message.Text },
                    Lang = Domain.Enum.Language.English,
                    SessionId = message.Id
                };

                var queryResponse = await queryAppService.GetQueryAsync(queryRequest);

                if (queryResponse != null && queryResponse.Result != null)
                {
                    if (queryResponse.Status != null)
                    {
                        if (queryResponse.Status.Code == (int)HttpStatusCode.OK)
                        {
                            result = queryResponse.Result.Fulfillment.Speech;
                        }
                    }
                }
            }
            catch { }

            return result;
        }

        #endregion

        #region Api Methods

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                var speech = await GetSpeechAsync(message);

                // return our reply to the user
                return message.CreateReplyMessage(speech);
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        #endregion
    }
}