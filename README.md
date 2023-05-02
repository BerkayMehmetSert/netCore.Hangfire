# NetCore Hangfire Example Project

## Description

This is a sample project that showcases a simple product management system built using ASP.NET Core and Hangfire.

## Getting Started

### Prerequisites

- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository
```sh
   git clone https://github.com/BerkayMehmetSert/netCore.Hangfire.git
```

2. Install the dependencies
```sh
dotnet restore
```

3. Create a database in SQL Server

4. Update the connection string in `appsettings.json` to point to the database you created

5. Run the project
```sh
dotnet run
```

## Features

This project provides a RESTful API for managing products. It includes the following features:

- **Get all products**
- **Get a product by ID**
- **Create a new product**
- **Update an existing product**
- **Delete a product**

Whenever a new product is created or an existing product is updated with a different price, an email is sent to a pre-configured email address. This email is sent in the background using Hangfire to prevent delays in the API response.

## Project Structure

The project consists of the following components:

- **Product** : Entity class representing a product with a name, description, and price.
- **Productmanager** : Service class implementing the **IProductService** interface for managing products. It uses the **IProductRepository** and **IUnitOfWork** interfaces for database operations, and the **EmailBackgroundJob** class for sending emails.
- **ProductsController** : Controller class providing the RESTful API endpoints for managing products. It uses the **IProductService** interface to interact with the **ProductManager**.
- **IProductService** : Interface defining the operations for managing products.
- **IProductRepository** : Interface defining the database operations for products.
- **IUnitOfWork** : Interface defining the database transaction for products.
- **EmailBackgroundJob** : Class for sending emails in the background using Hangfire.
- **IEmailSender** : Interface defining the operations for sending emails.
- **EmailSender** : Class efining the operations for sending emails.

## Usage

The API allows you to manage products. You can create, update, delete, and retrieve products.

**Get all products**

```bash
Get /api/products
```

Response body:
```json
[
  {
    "name": "Product 1",
    "description": "Description 1",
    "price": 10,
    "id": "e8ac896b-ace9-47b0-8ac1-a495b16973f4"
  },
  {
    "name": "Product 2",
    "description": "Description 2",
    "price": 20,
    "id": "7a4f0629-8f8b-4c65-a430-801879db1363"
  }
]
```

**Get a product by ID**
```bash
Get /api/products/{id}
```

Response body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 10,
  "id": "e8ac896b-ace9-47b0-8ac1-a495b16973f4"
}
```

**Create a new product**
```bash
Post /api/products
```

Request body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 10
}
```

Response body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 10,
  "id": "e8ac896b-ace9-47b0-8ac1-a495b16973f4"
}
```

**Update a product**
```bash
Put /api/products/{id}
```

Request body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 20
}
```

Response body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 20,
  "id": "e8ac896b-ace9-47b0-8ac1-a495b16973f4"
}
```

**Delete a product**
```bash
Delete /api/products/{id}
```

Response body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 20,
  "id": "e8ac896b-ace9-47b0-8ac1-a495b16973f4"
}
```
