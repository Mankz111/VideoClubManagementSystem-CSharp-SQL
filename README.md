# 🎬 Video Club Management System (C# / SQL Server)

A robust Windows desktop application for video rental store management, developed using **C# (Windows Forms)** and **SQL Server**, with seamless integration of the **TMDB API** for rich movie data. This project demonstrates full-stack development skills, efficient data handling, and a strong focus on software robustness and user experience.

---

## 🚀 Key Features

- **SQL Server Database**
  - Carefully modeled for data integrity and referential consistency.
  - Uses **Stored Procedures** and **Views** for optimized queries, encapsulated business logic, and enhanced security.

- **C# (Windows Forms)**
  - Modern, intuitive, and responsive desktop app interface.
  - Designed for smooth navigation and ease of use.

- **Robust Error Handling**
  - Try-catch blocks across all critical operations.
  - Prevents unexpected failures and improves system stability.

- **TMDB API Integration**
  - Automatic movie data population and suggestions.
  - Keeps your catalog accurate and up-to-date with minimal manual input.

- **Comprehensive Management Modules**
  - Manage clients, movies, rentals, returns, and view detailed client histories.
  - Full CRUD operations for all entities.

- **Powerful Reporting & Analytics**
  - Generate actionable reports such as:
    - **Top Rented Movies**
    - **Never Rented Movies**
    - **Rentals by Date Range**
    - **Overdue Rentals by Client**
    - **Clients with Overdue Rentals** (includes real-time monitoring & automated contact features)

---

## 🗄️ Database Structure

The system uses a SQL Server database designed for performance and reliability.

**Main Tables:**
- `Clientes`: Video store clients.
- `Filmes`: Movie catalog.
- `Alugueres`: Rental transactions (rental date, return date, status, etc.).

**Scripts:**  
All scripts for database creation (tables, views, stored procedures) are located in the [`Database/`](Database/) folder.

---

## 🛠️ Getting Started

### Prerequisites

- **Microsoft SQL Server** (Express edition is sufficient)
- **SQL Server Management Studio (SSMS)** or compatible tool
- **Visual Studio 2022** (or later)

---

### 1. Clone the Repository

```sh
git clone https://github.com/Mankz111/VideoClubManagementSystem-CSharp-SQL.git


