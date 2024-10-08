Hotel Reservation Management API
This API is a RESTful service designed to manage hotel reservations. It offers functionality for booking rooms, managing guest details, and checking room availability and statuses. The API includes authentication and authorization using JWT tokens for secure access to protected endpoints.

Table of Contents
Features
Technologies Used
Setup
Authentication
Endpoints
Public Endpoints
Protected Endpoints
Database Setup
Testing
Swagger Documentation
Features
User Authentication: Employees can log in and receive JWT tokens for access.
Room Management: Endpoints to view room availability, types, and statuses.
Guest Management: Manage guest information including registration, search, and updates.
Booking Management: Endpoints to create, update, search, and delete bookings.
Technologies Used
.NET 6 for API development
Entity Framework Core for database interactions
MySQL for database management
JWT for secure authentication
Swagger for API documentation
Clever Cloud for deployment
Setup
Clone the repository:

bash
Copiar código
git clone https://github.com/yourusername/hotel-reservation-api.git
Navigate to the project directory:

bash
Copiar código
cd hotel-reservation-api
Install dependencies:

bash
Copiar código
dotnet restore
Set up the database connection in the appsettings.json file:


Apply migrations to set up the database:

bash
Copiar código
dotnet ef database update
Run the application:

bash
Copiar código
dotnet run
Authentication
This API uses JWT for authentication. Employees must log in using the /api/v1/auth/login endpoint to receive a token, which they need to access protected endpoints.

Endpoints
Public Endpoints
These endpoints do not require authentication.

POST /api/v1/auth/login

Allows employees to log in and receive a JWT.
Request body: { "email": "employee@example.com", "password": "yourpassword" }
GET /api/v1/rooms/available

Returns all available rooms.
GET /api/v1/room_types

Returns all room types.
GET /api/v1/room_types/{id}

Returns details for a specific room type.
GET /api/v1/rooms/status

Provides a summary of room statuses (occupied vs. available).
POST /api/v1/guest

Registers a new guest.
Request body: { "name": "John Doe", "email": "john.doe@example.com", "phone": "1234567890" }
Protected Endpoints
These endpoints require a JWT token.

GET /api/v1/bookings/search/{identification_number}

Searches for bookings by guest identification number.
GET /api/v1/bookings/{id}

Retrieves details of a specific booking.
POST /api/v1/bookings

Creates a new booking.
Request body: { "guestId": 1, "roomId": 2, "checkIn": "2024-10-07", "checkOut": "2024-10-09" }
DELETE /api/v1/bookings/{id}

Deletes a specific booking.
GET /api/v1/rooms

Retrieves all rooms.
GET /api/v1/rooms/{id}

Retrieves details of a specific room.
GET /api/v1/guests

Retrieves all registered guests.
GET /api/v1/guests/{id}

Retrieves details of a specific guest.
DELETE /api/v1/guests/{id}

Deletes a guest.
GET /api/v1/guests/search/{keyword}

Searches for guests using a keyword.
PUT /api/v1/guests/{id}

Updates guest details.
Request body: { "name": "Updated Name", "email": "updated.email@example.com" }
GET /api/v1/rooms/occupied

Returns only the occupied rooms.
Database Setup
Ensure MySQL is installed and running. Update the connection string in appsettings.json with your database credentials. Use migrations to set up the database structure.

Apply migrations:

bash
Copiar código
dotnet ef database update
Testing
The API can be tested using tools like Postman or by accessing the Swagger interface provided at /swagger.

Swagger Documentation
Swagger is integrated to provide interactive documentation for the API. Access it by running the application and navigating to:


http://localhost:5000/swagger
Here, you can see all endpoints, their expected inputs, and responses.