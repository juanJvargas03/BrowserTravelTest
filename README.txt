**Database Creation**

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
