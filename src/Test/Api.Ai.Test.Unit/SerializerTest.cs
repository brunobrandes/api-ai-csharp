using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.Service.Serializer;

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
            return new QueryResponse
            {
                Id = Guid.NewGuid().ToString(),
                SessionId = "1",
                Status = new StatusResponse { Code = 200 },
                Timestamp = DateTime.Now
            };
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
        public void SerializeDeserializeQueryRequest()
        {
            var queryRequest = GetQueryRequest();

            var json = ApiAiJson<QueryRequest>.Serialize(queryRequest);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(json) && json.Contains("\"lang\": \"en\""));

            var deserializeQueryRequest = ApiAiJson<QueryRequest>.Deserialize(json);

            Assert.IsTrue(queryRequest.Query[0] == deserializeQueryRequest.Query[0]);
        }

        [TestMethod]
        public void SerializeDeserializeQueryResponse()
        {
            var queryResponse = GetQueryResponse();

            var json = ApiAiJson<QueryResponse>.Serialize(queryResponse);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(json) && json.Contains("\"code\": 200"));

            var deserializeQueryResponse = ApiAiJson<QueryResponse>.Deserialize(json);

            Assert.IsTrue(queryResponse.Id == deserializeQueryResponse.Id);
        }

        [TestMethod]
        public void SerializeDeserializeWebhookResponse()
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
