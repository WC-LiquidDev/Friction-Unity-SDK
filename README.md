# Friction SDK for Unity

**Version:** 1.0  
**Language:** C#  
**Platform:** Unity

The **Friction SDK** provides an easy-to-use interface for Unity projects to interact with custom backend servers. It includes methods for handling authentication, sending HTTP requests, and managing sessions.

---

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Quick Start](#quick-start)
- [Core Components](#core-components)
  - [FrictionSDK](#frictionsdk)
  - [AuthService](#authservice)
  - [FrictionSDKHelpers](#frictionsdkhelpers)
  - [RequestHelper](#requesthelper)
- [Example Usage](#example-usage)
- [Error Handling](#error-handling)

---

## Features

- Simplified authentication with customizable headers.
- Basic HTTP POST requests.
- Session token management.
- Built-in error handling for smoother debugging.

---

## Installation

1. Clone or download the `Friction SDK` files into your Unity project’s `Assets` folder.
2. Import **Newtonsoft.Json** (or another JSON library) for JSON handling, as Unity’s built-in JSON utility doesn’t support dictionaries.
   - You can add Newtonsoft.Json via [NuGet](https://www.nuget.org/) or Unity’s Package Manager.

---

## Quick Start

### 1. Set Up Authentication and Session Management

Define your backend's `BaseURL` in the SDK if needed. Then, call `AuthService.Login` with user credentials and relevant tags (optional).

### 2. Handle Callbacks for Success and Error Responses

Provide success and error callbacks to handle the response and potential errors from the backend.

---

## Core Components

### FrictionSDK

- **Purpose**: Manages session-related information.
- **Methods**:
  - `SetSessionToken(string token)`: Sets the session token to be used for authenticated requests.

---

### AuthService

Handles user authentication and communication with the backend.

**Methods**:

- `Login(string authenticationId, List<string> tags = null, System.Action<string> onSuccess = null, System.Action<string> onError = null)`:  
  Initiates login by sending the `authenticationId` and optional `tags` to the backend.

  - **Parameters**:
    - `authenticationId`: User’s unique authentication ID.
    - `tags`: Optional tags for platform identification.
    - `onSuccess`: Callback function upon successful login.
    - `onError`: Callback function upon login failure.

---

### FrictionSDKHelpers

Contains helper methods for sending HTTP requests.

**Methods**:

- `PostRequest(string url, Dictionary<string, object> data, System.Action<string> onSuccess, System.Action<string> onError, string authHeader = null)`:  
  Sends a POST request with specified data.

  - **Parameters**:
    - `url`: API endpoint.
    - `data`: Data to send as JSON.
    - `onSuccess`: Callback function for a successful response.
    - `onError`: Callback function for an error response.
    - `authHeader`: Optional authorization header.

---

### RequestHelper

A MonoBehaviour that manages request lifecycles and handles HTTP request coroutine.

**Methods**:

- `SendPostRequest(string url, Dictionary<string, object> data, System.Action<string> onSuccess, System.Action<string> onError, string authHeader = null)`:  
  Initiates a coroutine to send the POST request.

---

## Example Usage

Here’s a sample usage of the SDK to perform a login request:

```csharp
private void Login()
{
    string userId = PlayerPrefs.GetString("UserID", System.Guid.NewGuid().ToString());
    PlayerPrefs.SetString("UserID", userId);

    var tags = new List<string> { "oculus" };

    AuthService.Login(userId, tags,
        result =>
        {
            Debug.Log("Login successful: " + result);
            FrictionSDK.SetSessionToken(result);
            // Proceed with logged-in logic
        },
        error =>
        {
            Debug.LogError("Login failed: " + error);
        }
    );
}
```

---

## Error Handling

- **Client-Side**: Error messages are logged to the console through `Debug.LogError`.
- **Server-Side**: Ensure the server returns informative error messages for debugging.
- **Common Issues**:
  - **400 Bad Request**: Ensure all required parameters (like `AuthenticationId` and `Tags`) are provided.
  - **500 Internal Server Error**: Check server logs for details on backend issues.

---

## Contributing

Feel free to contribute to this SDK by submitting issues or pull requests to improve functionality and add new features.

---

## License

MIT License
