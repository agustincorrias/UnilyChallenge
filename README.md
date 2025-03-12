# AutomationChallenge - Agustin Corrias

## 📌 Summary
Project with **Playwright automation framework** designed for [Unily](https://www.unily.com/) to test an **e-commerce website**, focusing on:  
✅ **Product Search & Navigation**  
✅ **Product Details Verification**  
✅ **Cart Functionality**  
✅ **Assertions & Validations**  

The project employs a **Page Object Model (POM)** to enhance maintainability and leverages **wrapped functions** to boost reusability and code clarity.  
Furthermore, **Allure Reporting** is integrated for **test analysis and reporting**.

---

## 🛠 FirstSteps

### Installing Allure Report

#### On macOS
1. Install **Homebrew** if you don't have it:  
   ```sh
   /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
   ```

2. Install Allure using Homebrew:  
   ```sh
   brew install allure
   ```

#### On Windows
1. Download the Allure ZIP file from [GitHub Releases](https://github.com/allure-framework/allure2/releases).
2. Extract the contents of the ZIP to a folder of your choice.
3. Add the `bin` folder path of Allure to the `PATH` environment variable.

### Installing Browsers for Playwright

#### On macOS
1. Compile the repository:
   ```sh
   dotnet build
   ```

2. Navigate to the directory containing the `playwright.ps1` script:
   ```sh
   cd bin/debug/net8.0/
   ```

3. Execute the `playwright.ps1` script:
   ```sh
   pwsh ./playwright.ps1
   ```

#### On Windows
1. Compile the repository:
   ```powershell
   dotnet build
   ```

2. Navigate to the directory containing the `playwright.ps1` script:
   ```powershell
   cd bin\debug\net8.0\
   ```

3. Execute the `playwright.ps1` script:
   ```powershell
   ./playwright.ps1
   ```

---

## 🔧 Technologies Used
- **[Playwright for .NET](https://playwright.dev/dotnet/)** → Automation framework  
- **C#** → Programming Language  
- **[Allure Reports](https://github.com/allure-framework/allure-csharp)** → Extended Report Framework
- **.NET Core** → Runtime for executing Playwright scripts  
- **[Serilog](https://github.com/serilog/serilog)** → Logging framework

---

## 🗂 Project Structure
```
/UnilyChallenge
├── /.github
│   ├── workflows
│   │   ├── dotnet.yml
├── /Base
│   ├── BaseTest.cs
│   ├── PlaywrightRunner.cs
├── /Enums
│   ├── EBrowser.cs
├── /Pages
│   ├── Common
│   │   ├── FooterPage.cs
│   │   ├── ModalProductAddedPage.cs
│   │   ├── ProductModalPage.cs
│   │   └── ProductPage.cs
│   ├── CartPage.cs
│   ├── HomePage.cs
│   ├── ProductsPage.cs
├── /Utils
│   └── LogHelper.cs
│   └── BaseOperations.cs
├── /Tests
│   ├── baseClasses
│   │   ├── BaseCartTests.cs
│   │   ├── BaseHomeTest.cs
│   │   └── BaseProductsPage.cs
│   ├── CartTests.cs
│   ├── HomeTests.cs
│   ├── ProductsTests.cs
├── UnilyChallenge.csproj
└── README.md
```

## 🚀 How to Run Tests
### 1️⃣ Install Dependencies
dotnet restore

### 2️⃣ Run Playwright Tests
dotnet test

### 3️⃣ View Allure Report
1. Navigate to the directory containing the test results, typically `/bin`:
   ```sh
   cd bin/Debug/net8.0 
   ```

2. Serve the Allure report:
   ```sh
   allure serve
   ```