# Introduction
This repository represents a Business Process Management System (BPMS) solution that is architected upon a microservices framework. It is developed in C# utilizing the ASP.NET Core framework and comprises four distinct microservices.

The system is structured into four distinct microservices as follows:

* **BPMS Service:** This core microservice encapsulates the primary functionalities of the Business Process Management System. It is responsible for designing, handling process flows and monitoring business activities.

* **FormMaker Service:** This specialized microservice focuses on form creation and management. It allows users to design, customize, and implement forms that are essential for data collection within the various business processes. The FormMaker Service enhances user interaction and ensures that data entry is intuitive and seamless.

* **Identity Service:** The Identity Service is dedicated to managing user authentication and authorization, ensuring that only authorized individuals have access to specific functionalities and data within the BPMS. It supports a variety of authentication methods and facilitates user registration and profile management, contributing to the overall security of the system.

* **Shared Service:** This microservice acts as a common resource hub for shared functionalities and data that are needed across the other microservices. It includes shared entities such as variables, dtos, common methods and so on.
