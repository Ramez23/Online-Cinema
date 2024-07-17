Online Cinema System
Overview:
Developed an advanced Online Cinema System using Node.js. This RESTful API provides a platform for users to browse and book movies, with a strong administrative backend for managing content. The system features secure user authentication and comprehensive functionalities for both users and administrators.

Key Features:

User Authentication: Ensures secure access using basic HTTP authentication with username and password.
Admin Role: Administrators have full control over the site, allowing them to add, update, and delete movies, manage categories, and oversee user activities.
Movie and Category Management:
Admins can create, read, update, and delete movies and categories.
Movies can be organized into categories for better browsing and management.
Booking System:
Users can book seats for movies, and admins can manage these bookings.
CRUD Operations: Full support for Create, Read, Update, and Delete operations for movies, categories, and bookings.
Advanced Functionalities:
Pagination: Efficiently handles large sets of movies and bookings by breaking them into pages.
Filtering and Sorting: Movies can be filtered and sorted based on various criteria such as category, rating, and release date.
Entities:

User Info: Stores basic user details such as name, email, and password.
Movies: Includes movie details like title, description, genre, rating, and category.
Categories: Each movie belongs to a category, which can be managed by admins.
Bookings: Users can book seats for movies, which include details like movie, showtime, and seat number.
API Functionalities:

CRUD Actions for Movies and Categories: Admins can perform all CRUD operations on movies and categories.
Booking Management: Users can book seats, and admins can manage these bookings.
Pagination and Filtering: Supports pagination, filtering, and sorting for efficient data handling.
