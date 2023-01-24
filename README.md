<img src="https://github.com/emregulistan/aspnet-core-microservices/blob/master/sheme.png" width="auto">

#### Catalog microservice which includes; 
* ASP.NET Core Web API application 
* REST API principles, CRUD operations
* **MongoDB database** connection and containerization
* Repository Pattern Implementation
* Swagger Open API implementation	

#### Checkout microservice which includes;
* ASP.NET Core Web API application
* REST API principles, CRUD operations
* **Redis database** connection and containerization
* Publish BasketCheckout Queue with using **MassTransit and RabbitMQ**

#### Ordering Microservice
* Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices
* Developing **CQRS with using MediatR, and AutoMapper packages**
* Consuming **RabbitMQ** BasketCheckout event queue with using **MassTransit-RabbitMQ** Configuration
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup

#### Identity microservice which includes;
* .NET Core Identity Library
* JWT Token
* ASP.NET Core Web API application 
* REST API principles, CRUD operations
* **PostgreSql database** connection and containerization
* Repository Pattern Implementation
* Swagger Open API implementation	
	
#### API Gateway Ocelot Microservice
* Implement **API Gateways with Ocelot**
* Sample microservices/containers to reroute through the API Gateways
* Run multiple different **API Gateway/BFF** container types	
* The Gateway aggregation pattern in Shopping.Aggregator

#### Microservices Communication
* Async Microservices Communication with **RabbitMQ Message-Broker Service**
* Using **RabbitMQ Publish/Subscribe Topic** Exchange Model
* Using **MassTransit** for abstraction over RabbitMQ Message-Broker system
* Publishing BasketCheckout event queue from Checkout microservices and Subscribing this event from Ordering microservices	
* Create **RabbitMQ EventBus.Messages library** and add references Microservices

#### Docker Compose establishment with all microservices on docker;
* Containerization of microservices
* Containerization of databases
* Override Environment variables

### Installing
* **You can **launch microservices** as below urls:**

* **Catalog API -> http://host.docker.internal:8011/swagger/index.html**
* **Discount API -> http://host.docker.internal:8012/swagger/index.html**
* **Ordering API -> http://host.docker.internal:8013/swagger/index.html**
* **Identity API -> http://host.docker.internal:8014/swagger/index.html**
* **API Gateway -> http://host.docker.internal:8015/Catalog**
* **Rabbit Management Dashboard -> http://host.docker.internal:15672**   -- guest/guest
* **Portainer -> http://host.docker.internal:9001**   -- admin/admin1234
* **pgAdmin PostgreSQL -> http://host.docker.internal:5050**   -- admin@aspnetrun.com/admin1234



