---

## OGRIT-Database-Project

![logo](https://www.ogrit.net/sites/default/files/2024-03/logo%20%281%29.png)

#### This app is designed to connect to a main database, manage remote database connections, and execute stored procedures on those remote databases.

---

### Releases

[All releases](https://github.com/FP-Leo/OGRIT-Uygulama-Projesi/releases) and [Latest Release](https://github.com/FP-Leo/OGRIT-Uygulama-Projesi/releases/latest)

### Usage

To use the OGRIT Database Custom App, follow these steps:

1. **Setup**:
   - Ensure you have the required dependencies installed. Refer to the [Dependencies](#dependencies) section for a list of required packages.
   - Install the .NET SDK and any other necessary tools like Visual Studio and SQL Server Management Studio (SSMS).

2. **Configuration**:
   - **Main Database Connection**: Configure the connection to your main database where remote database connection strings will be stored. Set the Connection and Procedure tables names and schemas in the config.
   - **Remote Database Connections**: Use the application interface to add or update connection details for remote databases.
   - **Stored Procedures**: Ensure that the main database has the stored procedures you intend to execute. The procedures must return queries as strings so that they can get executed in remote databases.

3. **Running the Application**:
   - Launch the application from your development environment or executable.
   - Log in using your main database credentials.
   - Navigate to the Connection Management screen to add, update, or delete remote database connections.
   - Go to the Procedure Listing screen to view and select stored procedures.
   - Execute selected procedures on the chosen remote databases. 

4. **Example Usage**:
   - To execute a stored procedure, select the procedure from the list and choose the remote database connections where you want it executed.
   - The application will connect to each remote database, execute the procedure, and save the results if needed ( specified on OnReturnExecute ).

---

### Contributing

First Contributor:  Leonit Shabani

Second Contributor: Burak Efe Şişman

---

### License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

```
MIT License

Copyright (c) 2024 Leonit Shabani

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

---

### Dependencies

Certainly! Here is a detailed list of dependencies required for the OGRIT Database Project:

1. **.NET Framework/Core**
   - Ensure you have the appropriate version of .NET installed. You can download it from the [official .NET website](https://dotnet.microsoft.com/download).

2. **Entity Framework Core**
   - Used for database operations.
     ```sh
     dotnet add package Microsoft.EntityFrameworkCore
     dotnet add package Microsoft.EntityFrameworkCore.SqlServer
     ```

3. **Dapper**
   - A simple object mapper for .NET.
     ```sh
     dotnet add package Dapper
     ```

4. **Microsoft.Extensions.Configuration**
   - For handling configuration settings.
     ```sh
     dotnet add package Microsoft.Extensions.Configuration
     dotnet add package Microsoft.Extensions.Configuration.Json
     ```

5. **Microsoft.Extensions.DependencyInjection**
   - For dependency injection.
     ```sh
     dotnet add package Microsoft.Extensions.DependencyInjection
     ```

6. **Newtonsoft.Json**
   - For JSON serialization and deserialization.
     ```sh
     dotnet add package Newtonsoft.Json
     ```

7. **Xunit**
   - For unit testing.
     ```sh
     dotnet add package xunit
     dotnet add package xunit.runner.visualstudio
     ```

8. **Moq**
   - For mocking in unit tests.
     ```sh
     dotnet add package Moq
     ```

**Installation**

To install all dependencies, you can use the following command in the terminal:
```sh
dotnet restore
```

**Additional Tools**

- **Visual Studio**: Recommended IDE for development. You can download it from the [official Visual Studio website](https://visualstudio.microsoft.com/).
- **SQL Server Management Studio (SSMS)**: For managing your SQL Server databases. Download it from the [official SSMS website](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms).

---

### Class Diagram

![plantuml](https://www.plantuml.com/plantuml/png/hLDTZjD037wVKymRgT1UW0U4jh1LfQrOci8h6X8tEzfPJ-NnQ2iXpi8Lw1tAlKZ8pwHcu8NDInpxi_tP-Vmci26EZqwzqENvXEVJtXbIbJCXw8snkFJ8v9q3qb-LRf-NsuZ5GdrJ0wYi202NzmOReD5vwvirzf4nhNLPl8xC7ZyldQqUYaKVA867xEAYbgxwzwpN1Z2cgY8v1MM17henQ1fevq6esFeibqyMdkx8Lr17WXpWtH6goF1Fp8TeMVYd2QR4MnluZr5MVkUxCTuVEeAPYPe1a5QtXJr1k0Sg9alJQ0sm6-lSMyDcHROkEcDdlZZGzMZD-CdvmdDmxFgNja7ZYcJg_MJEX526qaUgO4Op_7OaJ7dtTqnIPIThYyqb_KxC5YFyfmoJXagcjideNsC0ue-7sZ3SU7gSBWO2y1eFaJll3ewScWg_BAtPNqDViHvoLi0ILIpqAosTYU-qfzdtrZ-fzkRFFvpz-Vt1EY0bpltgwlNyZZFXT8-vgFW7IisAzV7vccKqi-IkMmBaJab2icgMC4b4YS8JBAqnNrUYb11XffLKJ7xoNm00)

### OGRIT Database Custom App:

- **User Authentication**: Log in to your main database.
- **Connection Management**: Store remote database connection details in the main database.
- **Procedure Listing**: Display and manage lists of stored procedures.
- **Stored Procedures Execution**: Execute stored procedures from the main database to selected remote databases. The procedures must return results as strings, and the result table in the main database must match the structure of the data returned.

**Common Features:**

1. **User Authentication**: Implement a login system to authenticate users against their main database. Validation can be done using methods like Windows Authentication or SQL Server Authentication.

2. **Connection Management**: Store and manage remote database connection details in the main database. Users can add, update, or delete connection strings.

3. **Procedure Listing**: Provide an interface to list all available stored procedures in a selected database. Users can view details and select procedures to execute.

4. **Stored Procedures Execution**: Allow users to execute stored procedures on selected remote databases. Ensure that the procedures return their results as strings, and the result table in the main database matches the data structure returned.

5. **Menu Navigation**: Provide a centralized menu for navigating between screens, such as managing connections, viewing procedures, executing procedures, and logging out.

6. **Responsive UI Design**: Ensure the UI adapts to different screen sizes, keeping elements like buttons, forms, and tables usable across various display settings.

7. **Data Grid Management**: Use data grid views to display information about database connections and stored procedures. Allow sorting, filtering, and interaction with the grid data.

---
