# GitHub Copilot Training Exercises

## 🎯 Exercise 1: Fix Compilation Errors
**Objective**: Use GitHub Copilot to resolve namespace conflicts and nullable reference warnings.

**Current Issues**:
- TaskService has namespace conflicts between `Task` (model) and `System.Threading.Tasks.Task`
- Multiple nullable reference warnings in DTOs
- Missing using statements

**Prompts to Try**:
```
"Fix namespace conflicts in TaskService.cs by using fully qualified names"
"Add required modifier to non-nullable properties in DTOs"
"Resolve all nullable reference warnings in this file"
```

**Success Criteria**: Project compiles without errors or warnings.

---

## 🎯 Exercise 2: Add Comprehensive Error Handling
**Objective**: Implement consistent error handling across all Azure Functions.

**Current State**: Functions have minimal error handling and can throw unhandled exceptions.

**Prompts to Try**:
```
"Add try-catch error handling to all HTTP functions with proper status codes"
"Create a middleware for global exception handling in Azure Functions"
"Add input validation to CreateTask function with detailed error messages"
```

**Success Criteria**: 
- All functions handle exceptions gracefully
- Appropriate HTTP status codes returned
- Consistent error response format

---

## 🎯 Exercise 3: Generate Unit Tests
**Objective**: Create comprehensive unit test suite for the TaskService class.

**Current State**: No unit tests exist.

**Prompts to Try**:
```
"Generate unit tests for TaskService class covering all methods"
"Create test cases for edge cases like null inputs and empty collections"
"Add integration tests for HTTP functions using TestHost"
"Generate test data factory for Task model"
```

**Success Criteria**: 
- 80%+ code coverage
- Both positive and negative test cases
- Proper mocking of dependencies

---

## 🎯 Exercise 4: Enhance Infrastructure Security
**Objective**: Improve Terraform configuration with security best practices.

**Current State**: Basic infrastructure without security considerations.

**Prompts to Try**:
```
"Add Azure Key Vault to Terraform configuration for storing secrets"
"Configure private endpoints for storage account"
"Add network security group rules for Function App"
"Implement managed identity for Function App authentication"
```

**Success Criteria**:
- Secrets stored in Key Vault
- Network security implemented
- Managed identity configured

---

## 🎯 Exercise 5: Add API Documentation
**Objective**: Generate comprehensive API documentation and code comments.

**Current State**: Missing XML documentation and API specs.

**Prompts to Try**:
```
"Add XML documentation to all public methods and classes"
"Generate OpenAPI/Swagger documentation for HTTP endpoints"
"Create README section with API endpoint examples"
"Add inline comments explaining business logic"
```

**Success Criteria**:
- Complete XML documentation
- API documentation with examples
- Clear code comments

---

## 🎯 Exercise 6: Implement Validation Layer
**Objective**: Add robust input validation using Data Annotations or custom validators.

**Current State**: Basic or missing validation.

**Prompts to Try**:
```
"Add Data Annotations validation to all DTO classes"
"Create custom validation attributes for business rules"
"Implement validation middleware for Azure Functions"
"Add fluent validation for complex validation scenarios"
```

**Success Criteria**:
- All inputs validated
- Custom validation rules implemented
- Proper validation error responses

---

## 🎯 Exercise 7: Performance Optimization
**Objective**: Identify and fix performance issues in the current implementation.

**Current Issues**: In-memory storage, potential thread safety issues, inefficient queries.

**Prompts to Try**:
```
"Make TaskService thread-safe for concurrent access"
"Add caching layer to improve read performance"
"Implement async/await pattern throughout the application"
"Add performance monitoring and logging"
```

**Success Criteria**:
- Thread-safe implementation
- Improved response times
- Async operations implemented

---

## 🎯 Exercise 8: Add Advanced Features
**Objective**: Extend the API with more sophisticated functionality.

**Prompts to Try**:
```
"Add search functionality to find tasks by title or description"
"Implement task assignment with user management"
"Add task categories and filtering capabilities"
"Create task analytics and reporting endpoints"
```

**Success Criteria**:
- New endpoints implemented
- Proper error handling maintained
- Tests added for new features

---

## 🎯 Exercise 9: Improve DevOps Pipeline
**Objective**: Enhance the GitHub Actions workflow with better practices.

**Current State**: Basic build and deploy workflow.

**Prompts to Try**:
```
"Add code quality checks to GitHub Actions workflow"
"Implement blue-green deployment strategy"
"Add automated testing stages to CI/CD pipeline"
"Configure environment-specific deployments"
```

**Success Criteria**:
- Quality gates implemented
- Multiple environment support
- Automated testing in pipeline

---

## 🎯 Exercise 10: Security Hardening
**Objective**: Implement comprehensive security measures.

**Prompts to Try**:
```
"Add JWT authentication to Azure Functions"
"Implement role-based authorization for different endpoints"
"Add rate limiting to prevent abuse"
"Configure CORS properly for production"
```

**Success Criteria**:
- Authentication implemented
- Authorization controls in place
- Security headers configured

---

## 📝 Instructions for Trainers

### Setting Up Exercises:
1. Start with Exercise 1 (compilation errors) as it's blocking
2. Exercises 2-5 can be done in any order
3. Exercises 6-10 are advanced and build on earlier work
4. Encourage experimentation with different prompt styles

### Evaluation Criteria:
- **Prompt Effectiveness**: How well did the prompts generate desired code?
- **Code Quality**: Is the generated code maintainable and follows best practices?
- **Learning**: Did the trainee understand what was generated and why?

### Common Prompt Patterns to Teach:
- **Specific Context**: "In this Azure Functions project..."
- **Pattern Following**: "Following the existing error handling pattern..."
- **Requirements Listing**: "Create a function that: 1) validates input, 2) logs operations, 3) returns proper status codes"
- **Example-based**: "Similar to the GetTaskById function, create..."

### Tips for Better Results:
- Be specific about the technology stack
- Reference existing patterns in the codebase
- Ask for specific coding standards to be followed
- Request both implementation and tests
- Ask for explanations of complex generated code

---

## 🚀 Advanced Challenges

Once basic exercises are complete, try these advanced scenarios:

1. **Microservices Architecture**: Split the monolithic function into separate services
2. **Event-Driven Design**: Implement with Azure Service Bus or Event Grid
3. **CQRS Pattern**: Separate read and write operations
4. **Database Integration**: Replace in-memory storage with Cosmos DB or SQL
5. **Monitoring & Observability**: Add comprehensive telemetry and monitoring
