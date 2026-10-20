<div align="center">

# 🏢 Company Management System

### A clean, layered **ASP.NET MVC** web application for managing company data

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET_MVC-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Entity Framework](https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge&logo=nuget&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)

</div>

---

## 📌 Overview

**Company Management System** is a web application built with the **MVC (Model–View–Controller)** pattern to manage the core data of a company, such as employees, departments, projects, and relatives, through a clean and maintainable codebase.

The project focuses on **separation of concerns**, **readable structure**, and **real-world CRUD workflows**, which are the foundations of any production-grade web application.

---

## 🎥 Demo Video

> 👇 Watch the project running end-to-end.

https://github.com/user-attachments/assets/4239ef08-590b-4375-a142-c8be15e0d0fa

---

## 🖼️ Screenshots

### 🗂️ Project Structure

<p align="center">
  <img src="https://github.com/user-attachments/assets/b1777619-1867-48e5-8cbc-cdf9fc6aed6f" alt="Project Structure" width="400"/>
</p>

### 🗄️ Database Schema (ERD)

<p align="center">
  <img src="https://github.com/user-attachments/assets/e4ccb854-29a3-47cb-b7f4-036e5b5c3c90" alt="Database Schema" width="400"/>
</p>

---

## ✨ Key Features

- ✅ **MVC architecture**: Models, Views, and Controllers cleanly separated
- ✅ **Full CRUD operations**: Create, Read, Update, Delete
- ✅ **Relational database** with proper relationships between entities
- ✅ **Server-side validation** using Data Annotations
- ✅ **Strongly-typed Views** with Razor syntax
- ✅ **Responsive UI**
- ✅ **Version controlled** with Git & GitHub

---

## 🧱 Architecture

```
┌──────────┐    request     ┌──────────────┐    data     ┌─────────┐
│   View   │ ─────────────▶ │  Controller  │ ──────────▶ │  Model  │
│ (Razor)  │ ◀───────────── │  (Actions)   │ ◀────────── │  + DB   │
└──────────┘    response    └──────────────┘             └─────────┘
```

| Layer | Responsibility |
|---|---|
| **Model** | Entities, validation rules, and database access |
| **View** | Razor pages that render the UI |
| **Controller** | Handles requests, talks to the model, returns views |

---

## 🛠️ Tech Stack

| Category | Technology |
|---|---|
| Language | C# |
| Framework | ASP.NET MVC |
| ORM | Entity Framework |
| Database | SQL Server |
| Front-end | Razor, HTML5, CSS3 |
| Tools | Visual Studio, Git, GitHub |

---

## 💡 Skills Demonstrated

- **Object-Oriented Programming**: encapsulation, abstraction, inheritance, and polymorphism
- **Design Patterns**: MVC and separation of concerns
- **Database Design**: relational modeling, keys, and relationships
- **Data Access**: working with an ORM instead of raw SQL
- **Input Validation**: protecting data integrity on the server side
- **Clean Code**: meaningful naming and organized folders
- **Version Control**: Git workflow and GitHub project management
- **Problem Solving**: translating business requirements into working software

---

## 🚀 Getting Started

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) (with the ASP.NET workload)
- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server (or SQL Server Express / LocalDB)

### Installation

```bash
# 1. Clone the repository
git clone https://github.com/ZIADTAHAGEMAIL/MVCPractice_CompanyManagmentSystem.git

# 2. Open the solution
cd MVCPractice_CompanyManagmentSystem
start MVCPracticeSoll.sln
```

3. Update the **connection string** in `appsettings.json` (or `Web.config`) to point to your SQL Server instance.
4. Apply the database migrations:
   ```bash
   dotnet ef database update
   ```
5. Press **F5** to run the project 🎉

---

## 🔮 Future Improvements

- [ ] Authentication & role-based authorization
- [ ] Search, sorting, and pagination
- [ ] Repository & Unit of Work patterns
- [ ] Unit tests
- [ ] REST API layer
- [ ] Dashboard with charts

---

## 👨‍💻 Author

**Ziad Taha**
Computer Science & AI Student at Benha University, Developer

[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/ZIADTAHAGEMAIL)

---

<div align="center">

⭐ If you like this project, give it a star!

</div>
