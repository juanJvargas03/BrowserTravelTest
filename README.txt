# BrowserTravelTest

This project is a .NET Core web application that follows a hexagonal architecture and uses Entity Framework Core to communicate with a SQL Server database. It provides a REST API for managing books, authors, and editorials.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Installation

To install the project, follow these steps:

1. Clone the repository.
2. Open the project in Visual Studio.
3. Build the project.
4. Run the project.




## Database Creation

CREATE DATABASE BrowserTravelTestDB;
GO

USE BrowserTravelTestDB;
GO

CREATE TABLE authors (
   id INT identity(1,1) PRIMARY KEY,
   name VARCHAR(45),
   lastname VARCHAR(45)
);
GO

CREATE TABLE editorials (
   id INT identity(1,1) PRIMARY KEY,
   name VARCHAR(45),
   campus VARCHAR(45)
);
GO

CREATE TABLE books (
   ISBN BIGINT PRIMARY KEY,
   editorial_id INT FOREIGN KEY REFERENCES editorials(id),
   synopsis TEXT,
   n_pages VARCHAR(45)
);
GO

CREATE TABLE author_book (
   author_id INT FOREIGN KEY REFERENCES authors(id),
   book_ISBN BIGINT FOREIGN KEY REFERENCES books(ISBN),
   PRIMARY KEY (author_id, book_ISBN)
);
GO

## Usage

To use the project, you can make requests to the API endpoints using a tool like Postman or curl.

## API Endpoints

- `GET /api/books`: Returns a list of all books.
- `GET /api/books/{isbn}`: Returns a specific book by its ISBN.
- `POST /api/books`: Creates a new book.
- `PUT /api/books/{isbn}`: Updates an existing book.
- `DELETE /api/books/{isbn}`: Deletes a book.
- `GET /api/authors`: Returns a list of all authors.
- `GET /api/authors/{id}`: Returns a specific author by their ID.
- `POST /api/authors`: Creates a new author.
- `PUT /api/authors/{id}`: Updates an existing author.
- `DELETE /api/authors/{id}`: Deletes an author.
- `GET /api/editorials`: Returns a list of all editorials.
- `GET /api/editorials/{id}`: Returns a specific editorial by its ID.
- `POST /api/editorials`: Creates a new editorial.
- `PUT /api/editorials/{id}`: Updates an existing editorial.
- `DELETE /api/editorials/{id}`: Deletes an editorial.

## Contributing

To contribute to the project, follow these steps:

1. Fork the repository.
2. Create a new branch for your changes.
3. Make your changes.
4. Push your changes to your fork.
5. Create a pull request.

## License

This project is licensed under the MIT License.
