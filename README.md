# FlightsBackEnd
Flights Service
This repository contains the Flights service, which is built using clean architecture principles. The service is designed to provide information about flights and calculate the route based on user-provided origin and destination.

Architecture
The Flights service follows the clean architecture pattern, which promotes separation of concerns and maintainability. It consists of the following layers:

Presentation: Handles user interactions and input/output operations. This layer includes the Flights.WebApi project, which should be set as the startup project.

Application: Contains the application logic and orchestrates the flow of data between the presentation and domain layers.

Domain: Defines the core business logic and entities of the Flights service.

Infrastructure: Provides implementations for external dependencies, such as databases or external services.

Test: Includes unit tests to ensure the quality and correctness of the code.

Environment Variables
The following environment variables are used in the Flights service:

ASPNETCORE_ENVIRONMENT: Specifies the runtime environment for the service.
MULTIPLE_RETURN_ROUTES_URL: Defines the URL for a service that provides multiple return routes.
MAX_FLIGHT_COUNT: Specifies the maximum number of flights for the route calculation.

Features
The Flights service includes the following features:

Exception Filtering: Implements exception handling and filtering to improve error handling and user experience.
Logging: Incorporates logging mechanisms to capture relevant information and facilitate debugging and monitoring.
Unit Testing: Provides a suite of unit tests to validate the functionality and behavior of the service.
Getting Started
To run the Flights service, follow these steps:

Set the Flights.WebApi project as the startup project in your development environment.
Configure the required environment variables mentioned above.
Build and run the solution.
Feel free to explore the codebase and modify it according to your needs.

Please refer to the individual project documentation for more details and instructions.

License
This project is licensed under the MIT License.
