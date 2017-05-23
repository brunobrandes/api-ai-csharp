using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.DataTransferObject.Response;
using System.Collections.Generic;
using Api.Ai.Domain.DataTransferObject.Parameters;
using Api.Ai.Domain.DataTransferObject;
using Api.Ai.Domain.DataTransferObject.Response.Message;
using Api.Ai.Domain.DataTransferObject.Serializer;

namespace Api.Ai.Test.Unit
{
    [TestClass]
    public class SerializerTest
    {
        #region Private Methods

        private QueryRequest GetQueryRequest()
        {
            return new QueryRequest
            {
                SessionId = "1",
                Query = new string[] { "Hello, I want a pizza" },
                Lang = Domain.Enum.Language.English
            };
        }

        private QueryResponse GetQueryResponse()
        {
            var queryResponse = new QueryResponse
            {
                Id = Guid.NewGuid().ToString(),
                SessionId = "1",
                Status = new StatusResponse { Code = 200 },
                Timestamp = DateTime.Now,
                Result = new QueryResult
                {
                    Fulfillment = new FulfillmentResponse
                    {
                        Speech = string.Empty,
                        Messages = new BaseMessageResponse[2]
                        {
                            new TextMessageResponse { Speech = "It's working." },
                            new CardMessageResponse { Title = "title", Subtitle = "subtitle", ImageUrl = "http://127.0.0.1"  }
                        }
                    },
                    Contexts = new Context[1]
                    {
                        new Context
                        {
                            Name = "context-1",
                            Parameters = new Dictionary<string, object>()
                            {
                                {  "parameter-key-1", "parameter-valeu-1" },
                                { "parameter-key-2",  new DatePeriod {  EndDate = new Date { Calendar = 1470841200000 }, StartDate = new Date { Calendar = 1470841200000 } } }
                            }
                        }
                    }
                }
            };

            return queryResponse;
        }

        private WebhookResponse GetWebhookResponse()
        {
            return new WebhookResponse
            {
                Speech = "Webhook response test.",
                Source = "unit-test"
            };
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void Serialize_Deserialize_QueryRequest()
        {
            var queryRequest = GetQueryRequest();

            var json = ApiAiJson<QueryRequest>.Serialize(queryRequest);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(json) && json.Contains("\"lang\": \"en\""));
            var deserializeQueryRequest = ApiAiJson<QueryRequest>.Deserialize(json);

            Assert.IsTrue(queryRequest.Query[0] == deserializeQueryRequest.Query[0]);
        }

        [TestMethod]
        public void Serialize_Deserialize_QueryResponse()
        {
            var queryResponse = GetQueryResponse();

            var datePeriod = queryResponse.Result.GetParameterValueByKey("parameter-key-2");

            var json = ApiAiJson<QueryResponse>.Serialize(queryResponse);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(json) && json.Contains("\"code\": 200"));

            var deserializeQueryResponse = ApiAiJson<QueryResponse>.Deserialize(json);

            json = ApiAiJson<QueryResponse>.Serialize(deserializeQueryResponse);

            Assert.IsTrue(deserializeQueryResponse.Result.Fulfillment.Messages.Length > 0 && json.Contains("\"title\": \"title\"") && json.Contains("\"subtitle\": \"subtitle\""));

            Assert.IsTrue(queryResponse.Id == deserializeQueryResponse.Id);
        }

        [TestMethod]
        public void Serialize_Deserialize_WebhookResponse()
        {
            var webhookResponse = GetWebhookResponse();

            var json = ApiAiJson<WebhookResponse>.Serialize(webhookResponse);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(json) && json.Contains("\"source\": \"unit-test\""));

            var deserializeWebhookResponse = ApiAiJson<WebhookResponse>.Deserialize(json);

            Assert.IsTrue(webhookResponse.Source == deserializeWebhookResponse.Source);
        }

        #endregion
    }
}
