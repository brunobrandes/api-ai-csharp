# C# api.ai 

A C# wrapper for the [api.ai](https://api.ai/).</br>
This library makes very simple to integrate .NET applications with [api.ai](https://api.ai/)

## Installation

To install Api.Ai.Csharp, run the following command in the [Package Manager Console](https://docs.nuget.org/consume/package-manager-console)
>PM> Install-Package Api.Ai.Csharp

### Begin

"Api.ai provides developers and companies with the advanced tools they need to build conversational user interfaces for apps and 
hardware devices". To begin, you need to have an [api.ai](https://api.ai/) account.

See api.ai [documentation](https://docs.api.ai/docs) for more details.

### Structure 

The solution structure (.sln) is based in [The Onion Architecture](http://bit.ly/1r54LZv)

[DataTranferObject (DTO)](https://en.wikipedia.org/wiki/Data_transfer_object) project, contains the call parameters used as either parameters in the URL or JSON keys in the POST body

* [query - submit voice or text queries](https://docs.api.ai/v12/docs/query)
    * [QueryRequest](http://bit.ly/1Sb1ljp)
    * [QueryResponse](http://bit.ly/23JTGQE)

* [tts - get text-to-speech](https://docs.api.ai/v12/docs/tts) </br>
	* [TtsRequest](http://bit.ly/1XLjFjC)
	* [TtsResponse](http://bit.ly/1QqBNcy)
	
* [entities - manage entities](https://docs.api.ai/v12/docs/entities) </br>
	* [Entity](https://goo.gl/SbpzfL)
	* [Entry](https://goo.gl/5HyMo6)
	* [EntitiesResponse](https://goo.gl/u7lfXd)
	
* [userEntities - manage user-level entities](https://docs.api.ai/v12/docs/userEntities) </br>
	not implemented
	
* [intents - manage intents](https://docs.api.ai/v12/docs/intents) </br>
	not implemented
	
* [wehook - receiving](https://docs.api.ai/docs/webhook) </br>
	* [WebhookResponse](https://goo.gl/f3q2dr)
	
	
[ApplicationService](http://bit.ly/1VEQrF6) project implements the application services.

* [ApiAiAppService](http://bit.ly/240DPd4) </br>
  Base properties and methods of application service.

* [QueryAppService](http://bit.ly/1VC6qUT) </br>
  Query application service.</br>
  Process natural language in either text form or sound file.

* [TtsAppService](http://bit.ly/23MJUNG) </br>
  Tts application service.</br>
  Used to perform text-to-speech - generate speech (audio file) from text.
  
* [EntitiesAppService]() </br>
  Entitie application service
  The entities app service is used to create, retrieve, update and delete developer-defined entity objects.
  
* [UserEntitiesAppService]() </br>
  not implemented
  
* [IntentsAppService]() </br>
  not implemented
  
### Usage

1. Using [Dependency Injection](https://en.wikipedia.org/wiki/Dependency_injection), the configuration of the application with [Simple Injector](https://simpleinjector.org/index.html) might look something like this:

  ```csharp
    var container = new Container();
  
    container.RegisterSingleton<IServiceProvider>(container);
    container.Register<IApiAiAppServiceFactory, ApiAiAppServiceFactory>();
    container.Register<IHttpClientFactory, HttpClientFactory>();
  ```

2. Get container api.ai app service factory 

  ```csharp
  var apiAiAppServiceFactory = container.GetInstance<IApiAiAppServiceFactory>();
  ```

3. Create query app service  

  ```csharp
  var queryAppService = apiAiAppServiceFactory.CreateQueryAppService("https://api.api.ai/v1", 
    "YOUR_ACCESS_TOKEN");
  ```

4. Create query request

  ```csharp
  var queryRequest = new QueryRequest
  {
    SessionId = "1",
    Query = new string[] { "Hello, I want a pizza" },
    Lang = Domain.Enum.Language.English
  };
  ```

5. Call api.ai query by http get method

  ```csharp
  var queryResponse = await queryAppService.GetQueryAsync(queryRequest);
  ```
  
  5.1 Or call api.ai query by http post method (recommended)

  ```csharp
  var queryResponse = await queryAppService.PostQueryAsync(queryRequest);
  ```

Use [ApiAiJson](http://bit.ly/1Qo3h2F) to Serialize/Deserialize response.

```csharp
  var json = ApiAiJson<QueryResponse>.Serialize(queryResponse);
```

json property value:

```json
  {
    "result": {
      "source": "agent",
      "resolvedQuery": "Hello, I want a pizza",
      "score": 1.0,
      "action": "order.pizza",
      "parameters": {},
      "contexts": [
        {
          "name": "pizza",
          "lifespan": 5
        },
        {
          "name": "pizza-type",
          "lifespan": 5
        }
      ],
      "fulfillment": {
        "speech": "Sure, let me help you choose the best pizza for you! What flavor would you like?"
      },
      "metadata": {
        "intentId": "f5c9fb83-b99e-4af5-bae7-6405a6501d10",
        "webhookUsed": false,
        "intentName": "pizza"
      }
    },
    "id": "46ead378-2d8a-41cf-a876-eed8bb531dab",
    "timestamp": "2016-04-20T21:05:50.997Z",
    "status": {
      "code": 200,
      "errorType": "success"
    }
  }
```

[Download the examples](http://bit.ly/1SwgSwj) for test your agent :) </br>

See the [Bot Application Project](http://bit.ly/23MMcfx) sample which contains code of how to create</br>
and publish your bot in [Microsoft Bot Framework](https://dev.botframework.com/) </br>

[Download and install the Bot Application template](http://bit.ly/1TlTL4A)

### TODO

- [x] Create tts DataTranferObject
- [x] Implement TtsAppService
- [x] Create entities DataTranferObject
- [x] Implement EntitiesAppService
- [x] Create webhook DataTranferObject
- [ ] Create userEntities DataTranferObject
- [ ] Implement UserEntitiesAppService
- [ ] Create intents DataTranferObject
- [ ] Implement IntentsAppService
- [ ] Write unit tests

### License

This software is open source, licensed under the Apache License. </br>
See [LICENSE.me](https://github.com/brunobrandes/api-ai-csharp/blob/master/LICENSE.me) for details.
