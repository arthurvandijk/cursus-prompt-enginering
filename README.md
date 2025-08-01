# Task Management API - GitHub Copilot Training Project

This repository contains a demo .NET Azure Functions project designed for learning GitHub Copilot instructions and custom prompts. The project represents a typical enterprise development environment with intentional areas for improvement.

## 🎯 Project Overview

A simple Task Management API built with:
- **.NET 8 Azure Functions** - HTTP triggered functions for CRUD operations
- **Terraform Infrastructure** - Infrastructure as Code for Azure deployment
- **GitHub Actions** - CI/CD pipeline (basic setup)

## 📁 Project Structure

```
├── api/                          # Azure Functions application
│   ├── Models/                   # Domain models
│   ├── DTOs/                     # Data Transfer Objects
│   ├── Services/                 # Business logic layer
│   ├── Functions/                # Additional Azure Functions
│   ├── Program.cs               # Application startup
│   └── ToDo.cs                  # Main HTTP functions
├── infrastructure/               # Terraform configuration
│   ├── main.tf                  # Main infrastructure resources
│   ├── variables.tf             # Input variables
│   └── outputs.tf               # Output values
├── .github/workflows/           # GitHub Actions workflows
└── README.md                    # This file
```

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- Azure Functions Core Tools
- Terraform (for infrastructure)
- Azure CLI
- Visual Studio Code with Azure Functions extension

### Local Development
1. Clone the repository
2. Navigate to the `api` folder
3. Run `dotnet restore`
4. Run `func start` to start the functions locally

## 🎓 Training Scenarios

This project is designed with intentional "junior-level" code that provides excellent opportunities for GitHub Copilot training:

### 1. **Code Quality Improvements**
- Missing error handling in HTTP functions
- No input validation
- Nullable reference type warnings
- Namespace conflicts (Task vs System.Threading.Tasks.Task)

**Training Prompts to Try:**
```
"Add comprehensive error handling to all HTTP functions"
"Fix all nullable reference type warnings"
"Add input validation to CreateTask function"
"Resolve namespace conflicts in TaskService"
```

### 2. **Missing Unit Tests**
The project has no tests - perfect for test generation practice.

**Training Prompts to Try:**
```
"Generate unit tests for TaskService class"
"Create integration tests for HTTP functions"
"Add test for edge cases in GetTaskById"
```

### 3. **Documentation Generation**
Missing XML documentation and inline comments.

**Training Prompts to Try:**
```
"Add XML documentation to all public methods"
"Generate API documentation for all endpoints"
"Add inline comments explaining business logic"
```

### 4. **Infrastructure Enhancements**
Basic Terraform setup with room for improvements.

**Training Prompts to Try:**
```
"Add Azure Key Vault to store secrets"
"Configure Application Insights monitoring"
"Add networking security with VNet integration"
"Implement blue-green deployment slots"
```

### 5. **Security Improvements**
**Training Prompts to Try:**
```
"Add authentication to Azure Functions"
"Implement API key validation"
"Add CORS configuration"
"Secure storage account with private endpoints"
```

## 📝 Sample Instructions for Trainees

Here are examples of the types of GitHub Copilot instructions trainees can create:

### Example 1: Error Handling Pattern
```
# Instruction: Azure Functions Error Handling
When writing Azure Functions HTTP triggers:
1. Always wrap business logic in try-catch blocks
2. Return appropriate HTTP status codes (400, 404, 500)
3. Log errors with correlation IDs
4. Return consistent error response format with message and timestamp
5. Never expose internal exception details to clients
```

### Example 2: Terraform Naming Convention
```
# Instruction: Azure Resource Naming
For Terraform resources in Azure:
1. Use kebab-case for resource names
2. Include environment prefix (dev-, test-, prod-)
3. Include resource type abbreviation (rg-, st-, func-, ai-)
4. Use consistent tagging with Environment, Project, Owner
5. Keep names under Azure character limits
```

## 🔧 Common Issues to Fix (Training Opportunities)

1. **Compile Errors**: The project has intentional compile errors for training
2. **Missing Dependencies**: Some services aren't properly registered
3. **Configuration Issues**: Missing app settings and connection strings
4. **Performance Issues**: In-memory storage isn't thread-safe
5. **Security Gaps**: No authentication or authorization

## 🎯 Learning Objectives

By working with this project, trainees will learn to:
- Write effective Copilot prompts for code generation
- Create reusable instruction sets for team standards
- Use Copilot for debugging and error resolution
- Generate comprehensive tests and documentation
- Enhance infrastructure code with best practices

## 🚀 Advanced Scenarios

Once comfortable with basics, try these advanced scenarios:
- Implement CQRS pattern with separate read/write models
- Add event-driven architecture with Service Bus
- Implement distributed caching with Redis
- Add health checks and monitoring
- Create load testing scenarios

## 📚 Resources

- [Azure Functions Documentation](https://docs.microsoft.com/en-us/azure/azure-functions/)
- [Terraform Azure Provider](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs)
- [GitHub Copilot Documentation](https://docs.github.com/en/copilot)

## 🤝 Contributing

This is a training project. Feel free to experiment, break things, and learn!

---
**Note**: This project is designed for learning purposes. The code intentionally contains areas for improvement to provide hands-on training opportunities with GitHub Copilot.
