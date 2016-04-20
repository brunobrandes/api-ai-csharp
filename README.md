# C# api.ai 

A C# wrapper for the [api.ai](https://api.ai/).</br>
This library is a very simple integrate your .NET application on the [api.ai](https://api.ai/)

## Installation

To install Api.Ai.Csharp, run the following command in the [Package Manager Console](https://docs.nuget.org/consume/package-manager-console)
>PM> Install-Package Api.Ai.Csharp

### Begin

"Api.ai provides developers and companies with the advanced tools they need to build conversational user interfaces for apps and 
hardware devices". To begin, you need to have an [api.ai](https://api.ai/) account.

See api.ai [documentation](https://docs.api.ai/docs) for more details.

### Structure 

Solution structure (.sln) is based in [The Onion Architecture](http://bit.ly/1r54LZv)

[DataTranferObject (DTO)](https://en.wikipedia.org/wiki/Data_transfer_object) project, contains the call parameters used as either
parameters in the URL or JSON keys in the POST body

* [query - submit voice or text queries](https://docs.api.ai/v12/docs/query)
    * [QueryRequest](http://bit.ly/1Sb1ljp)
    * [QueryResponse](http://bit.ly/23JTGQE)

* [tts - get text-to-speech](https://docs.api.ai/v12/docs/tts) </br>
	not implemented
	
* [entities - manage entities](https://docs.api.ai/v12/docs/entities) </br>
	not implemented
	
* [userEntities - manage user-level entities](https://docs.api.ai/v12/docs/userEntities) </br>
	not implemented
	
* [intents - manage intents](https://docs.api.ai/v12/docs/intents) </br>
	not implemented
	
[ApplicationService](http://bit.ly/1VEQrF6) project, have to implemented application services.

* [ApiAiAppService](http://bit.ly/240DPd4) </br>
  Base properties and methods of application service.

* [QueryAppService](http://bit.ly/1VC6qUT) </br>
  Query application service.</br>
  Process natural language, either in the form of text or a sound file.

* [TtsAppService]() </br>
  not implemented
  
* [EntitiesAppService]() </br>
  not implemented
  
* [UserEntitiesAppService]() </br>
  not implemented
  
* [IntentsAppService]() </br>
  not implemented
  
### Usage

1. Using [Dependency Injection](https://en.wikipedia.org/wiki/Dependency_injection), the configuration of the application with 
[Simple Injector](https://simpleinjector.org/index.html), might look something like this:

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

3. Create full contact app service  

  ```csharp
  var queryAppService = apiAiAppServiceFactory.CreateQueryAppService("https://api.api.ai/v1", 
    "YOUR_ACCESS_TOKEN");
  ```

4. Create query request

  ```csharp
  var queryRequest = new QueryRequest
  {
    Query = new string[] { "Hello, I want a pizza" },
    Lang = Domain.Enum.Language.English
  };
  ```

5. Call api.ai query by get

  ```csharp
  var queryResponse = await queryAppService.GetQueryAsync(queryRequest);
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

[Download the example console](http://bit.ly/1SwgSwj) for test your agent :)

### TODO

- [ ] Create tts DTO
- [ ] Implement TtsAppService
- [ ] Create entities DTO
- [ ] Implement EntitiesAppService
- [ ] Create userEntities DTO
- [ ] Implement UserEntitiesAppService
- [ ] Create intents DTO
- [ ] Implement IntentsAppService
- [ ] Write new unit tests

### License

This software is open source, licensed under the Apache License. </br>
See [LICENSE.me](https://github.com/brunobrandes/api-ai-csharp/blob/master/LICENSE.me) for details.
