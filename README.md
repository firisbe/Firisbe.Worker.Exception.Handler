## 🛠 Worker Exception Handler

> A lightweight library to manage JetEMV worker exceptions and define custom post-error handling logic.

[![Version](https://img.shields.io/badge/version-1.0.0-green.svg)](https://github.com/orgs/firisbe/packages/nuget/package/Firisbe.Worker.Exception.Handler)

---

## 📦 Installation

Install the package via .NET CLI:

```bash
dotnet add package Firisbe.Worker.Exception.Handler --version 1.0.0
```

---

## 🚀 Getting Started

### 1. Extend `BaseWorkerProcessor`

Inherit from `BaseWorkerProcessor` to enable the built-in exception handling wrapper.

```csharp
public class BatchProcessService : BaseWorkerProcessor
{
    // Your implementation...
}
```

---

### 2. Create a Custom Error Policy

Define your own error handling logic by implementing `IErrorPolicy<T>`.

```csharp
public class ImportConsumerPolicy : IErrorPolicy<T>
{
    private readonly ILogger<BatchCreatedConsumer> _logger;
    private readonly ICustomHttpClient _httpClient;

    public ImportConsumerPolicy(
        ILogger<BatchCreatedConsumer> logger,
        ICustomHttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task ApplyAsync(T context)
    {
        // Custom error handling logic here
    }
}
```

---

### 3. Wrap Your Logic with `ExecuteBatchSafelyAsync`

This method wraps your business logic and applies your custom error policy when an exception occurs.

```csharp
await ExecuteBatchSafelyAsync(
    async () =>
    {
        // Your business logic
    },
    policy,
    (ex) => new ImportConsumerContext
    {
        BatchId = batchId,
        FilePath = batch.FilePath,
        Category = ResolveCategory(ex),
        Exception = ex,
        IsRetryable = false,
        WorkerSession = workerSession
    });
```

---

## 🧠 Exception Categorization

`ResolveCategory` helps classify exceptions so you can centralize handling strategies.

```csharp
protected virtual ErrorCategory ResolveCategory(Exception ex)
{
    return ex switch
    {
        FirisbeException => ((FirisbeException)ex).Category,
        HttpRequestException => ErrorCategory.Infrastructure,
        TimeoutException => ErrorCategory.Infrastructure,
        _ => ErrorCategory.Unknown
    };
}
```

---

## 💡 Why this matters

Instead of writing:

```csharp
ex is HttpRequestException || ex is TimeoutException
```

You can simply use:

```csharp
ErrorCategory.Infrastructure
```

This makes your error handling:
- cleaner
- reusable
- easier to maintain

---
