# ITI_System

**ITI_System** is a web application for managing students, courses, and departments within an educational institution. It provides role-based access to students, instructors, and administrators, ensuring that each user can access only the features allowed for their role.  

---

## Features

### Role-Based Access

- **Admin**
  - View, add, update, and delete **courses**.
  - View, add, update, and delete **departments**.
  - View, add, and delete **students**.
  - Add new users with roles (**Instructor**, **Admin**).  
  - **Note:** When a course is added to a department, all students in that department are automatically registered to the course. Instructors can then edit their marks.
  - Responsible for registering **Instructor** and **Admin** accounts.

- **Instructor**
  - View course details.
  - Update and manage students’ marks in courses.
  - View department details.
  - Account must be created by an **Admin**.

- **Student**
  - Self-register for an account.  
  - View course details.
  - View department details.

**UI adapts based on role:**  
For example, students only see buttons for viewing course and department details, whereas instructors and admins have additional buttons for updating or adding data.  

---

## Technology Stack

- **Backend:** .NET MVC Architecture (Code First approach)  
- **Frontend:** HTML, Bootstrap  
- **Database:** SQL Server (via Entity Framework Code First)  
- **Security:** Role-based authentication and authorization  

---

## Architecture

The project follows the **MVC (Model-View-Controller)** pattern:

- **Models:** Represent data structures such as Students, Courses, Departments, and Users  
- **Views:** Dynamic HTML pages styled with Bootstrap, adapting to the user's role  
- **Controllers:** Handle application logic and enforce role-based access  

---

## Usage

1. Create an account:  
   - **Students** can self-register.  
   - **Instructors** and **Admins** must be registered by an existing **Admin**.  
2. Log in with your account credentials.  
3. Depending on your role:  
   - **Admin:** Manage courses, departments, students, and user roles.  
   - **Instructor:** Manage student marks and view course/department info.  
   - **Student:** View course and department details.  
4. The UI dynamically displays only the actions your role is allowed to perform.  

---

## Special Notes

- Adding a course to a department automatically registers all students in that department to the course.  
- Instructors can edit student marks.  
- Each role sees a customized UI and can only access allowed features.  
